using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AElf.Common;
using AElf.Contracts.Genesis;
using AElf.Cryptography;
using AElf.Cryptography.ECDSA;
using AElf.Kernel;
using AElf.Kernel.Account.Application;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.Consensus.Application;
using AElf.Kernel.KernelAccount;
using AElf.Kernel.Miner.Application;
using AElf.Kernel.Node.Application;
using AElf.Kernel.Services;
using AElf.Kernel.SmartContractExecution.Application;
using AElf.Kernel.TransactionPool.Infrastructure;
using AElf.OS.Node.Application;
using AElf.Types.CSharp;
using DPoS = AElf.Contracts.Consensus.DPoS;
using Google.Protobuf;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace AElf.Contracts.TestBase
{
    public class ContractExecutor: ITransientDependency
    {
        private readonly int _chainId;

        private readonly IBlockchainService _blockchainService;
        private readonly ITransactionExecutingService _transactionExecutingService;
        private readonly IBlockchainNodeContextService _blockchainNodeContextService;
        private readonly IBlockGenerationService _blockGenerationService;
        private readonly ISystemTransactionGenerationService _systemTransactionGenerationService;
        private readonly IBlockExecutingService _blockExecutingService;
        private readonly IConsensusService _consensusService;

        private Address BasicContractZero { get; set; } =
            Address.BuildContractAddress(ChainHelpers.ConvertBase58ToChainId("AELF"), 0);

        public ECKeyPair CallerKeyPair { get; set; }

        public ContractExecutor(int chainId = 0)
        {
            _chainId = chainId == 0 ? ChainHelpers.ConvertBase58ToChainId("AELF"):chainId;

            var application =
                AbpApplicationFactory.Create<ContractTestAElfModule>(options => { options.UseAutofac(); });
            application.Initialize();

            _blockchainService = application.ServiceProvider.GetService<IBlockchainService>();
            _transactionExecutingService = application.ServiceProvider.GetService<ITransactionExecutingService>();
            _blockchainNodeContextService = application.ServiceProvider.GetService<IBlockchainNodeContextService>();
            _blockGenerationService = application.ServiceProvider.GetService<IBlockGenerationService>();
            _systemTransactionGenerationService = application.ServiceProvider.GetService<ISystemTransactionGenerationService>();
            _blockExecutingService = application.ServiceProvider.GetService<IBlockExecutingService>();
            _consensusService = application.ServiceProvider.GetService<IConsensusService>();

            CallerKeyPair = GenerateKeyPair();
        }

        public async Task InitialChainAsync()
        {
            var transactions = GetGenesisTransactions(_chainId);
            var dto = new OsBlockchainNodeContextStartDto
            {
                BlockchainNodeContextStartDto = new BlockchainNodeContextStartDto()
                {
                    ChainId = _chainId,
                    Transactions = transactions
                }
            };

            await _blockchainNodeContextService.StartAsync(dto.BlockchainNodeContextStartDto);
        }

        public async Task<Address> DeployContractTest(byte[] contractCode, ulong serialNumber)
        {
            await InitialChainAsync();

            var tx = GenerateTransaction(BasicContractZero, "DeploySmartContract",
                CryptoHelpers.GenerateKeyPair(), 2,
                contractCode);

            await MineABlockAsync(new List<Transaction> {tx});

            var chain = await GetChainAsync();

            return Address.BuildContractAddress(_chainId, serialNumber);
        }

        public Transaction GenerateTransaction(Address contractAddress, string methodName,
            params object[] objects)
        {
            var tx = new Transaction
            {
                From = GetAddress(CallerKeyPair),
                To = contractAddress,
                MethodName = methodName,
                Params = ByteString.CopyFrom(ParamsPacker.Pack(objects))
            };

            var signature = CryptoHelpers.SignWithPrivateKey(CallerKeyPair.PrivateKey, tx.GetHash().DumpByteArray());
            tx.Sigs.Add(ByteString.CopyFrom(signature));

            return tx;
        }

        public async Task<ByteString> ExecuteContractAsync(Address contractAddress, string methodName,
            params object[] objects)
        {
            var tx = new Transaction
            {
                From = GetAddress(CallerKeyPair),
                To = contractAddress,
                MethodName = methodName,
                Params = ByteString.CopyFrom(ParamsPacker.Pack(objects))
            };

            var signature = CryptoHelpers.SignWithPrivateKey(CallerKeyPair.PrivateKey, tx.GetHash().DumpByteArray());
            tx.Sigs.Add(ByteString.CopyFrom(signature));

            var preBlock = await _blockchainService.GetBestChainLastBlock(_chainId);
            var executionReturnSets = await _transactionExecutingService.ExecuteAsync(new ChainContext
                {
                    ChainId = _chainId,
                    BlockHash = preBlock.GetHash(),
                    BlockHeight = preBlock.Height
                },
                new List<Transaction> {tx},
                DateTime.UtcNow, new CancellationToken());

            return executionReturnSets.Any() ? executionReturnSets.Last().ReturnValue : null;
        }

        public async Task MineABlockAsync(List<Transaction> txs)
        {
            var preBlock = await _blockchainService.GetBestChainLastBlock(_chainId);
            var minerService = BuildMinerService(txs);
            await minerService.MineAsync(_chainId, preBlock.GetHash(), preBlock.Height,
                DateTime.UtcNow.AddMilliseconds(4000));
        }

        public async Task<Chain> GetChainAsync()
        {
            return await _blockchainService.GetChainAsync(_chainId);
        }

        public ECKeyPair GenerateKeyPair()
        {
            return CryptoHelpers.GenerateKeyPair();
        }

        public Address GetAddress(ECKeyPair keyPair)
        {
            return Address.FromPublicKey(keyPair.PublicKey);
        }

        public void SetContractCallOwner(ECKeyPair callerKeyPair)
        {
            CallerKeyPair = callerKeyPair;
        }

        private MinerService BuildMinerService(List<Transaction> txs)
        {
            var trs = new List<TransactionReceipt>();

            foreach (var transaction in txs)
            {
                var tr = new TransactionReceipt(transaction)
                {
                    SignatureStatus = SignatureStatus.SignatureValid, RefBlockStatus = RefBlockStatus.RefBlockValid
                };
                trs.Add(tr);
            }

            var mockTxHub = new Mock<ITxHub>();
            mockTxHub.Setup(h => h.GetReceiptsOfExecutablesAsync()).ReturnsAsync(trs);

            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetPublicKeyAsync())
                .ReturnsAsync(CryptoHelpers.GenerateKeyPair().PublicKey);
            return new MinerService(mockTxHub.Object, mockAccountService.Object, _blockGenerationService,
                _systemTransactionGenerationService, _blockchainService, _blockExecutingService, _consensusService);
        }

        private Transaction[] GetGenesisTransactions(int chainId)
        {
            var transactions = new List<Transaction>();
            transactions.Add(GetTransactionForDeployment(chainId, typeof(BasicContractZero)));
            transactions.Add(GetTransactionForDeployment(chainId, typeof(DPoS.Contract)));
            return transactions.ToArray();
        }

        private Transaction GetTransactionForDeployment(int chainId, Type contractType)
        {
            var zeroAddress = Address.BuildContractAddress(chainId, 0);

            var code = File.ReadAllBytes(contractType.Assembly.Location);
            return new Transaction
            {
                From = zeroAddress,
                To = zeroAddress,
                MethodName = nameof(ISmartContractZero.DeploySmartContract),
                Params = ByteString.CopyFrom(ParamsPacker.Pack(2, code))
            };
        }
    }
}
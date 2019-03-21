using System.Threading.Tasks;
using AElf.Common;
using AElf.Cryptography;
using AElf.Kernel.Account.Application;
using AElf.Kernel.Consensus.Application;
using AElf.Kernel.Consensus.DPoS.Application;
using AElf.Kernel.SmartContract.Application;
using AElf.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Volo.Abp.Modularity;

namespace AElf.Kernel.Consensus
{
    [DependsOn(
        typeof(KernelTestAElfModule),
        typeof(KernelCoreWithChainTestAElfModule)
        )]
    public class ConsensusTestAElfModule: AElfModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            
            //Account service
            var ecKeyPair = CryptoHelpers.GenerateKeyPair();
            services.AddTransient(o =>
            {
                var accountService = new Mock<IAccountService>();
                accountService.Setup(a => a.SignAsync(It.IsAny<byte[]>())).Returns<byte[]>(data =>
                    Task.FromResult(CryptoHelpers.SignWithPrivateKey(ecKeyPair.PrivateKey, data)));

                accountService.Setup(a => a.VerifySignatureAsync(It.IsAny<byte[]>(), It.IsAny<byte[]>(), It.IsAny<byte[]>()
                )).Returns<byte[], byte[], byte[]>((signature, data, publicKey) =>
                {
                    var recoverResult = CryptoHelpers.RecoverPublicKey(signature, data, out var recoverPublicKey);
                    return Task.FromResult(recoverResult && publicKey.BytesEqual(recoverPublicKey));
                });

                accountService.Setup(a => a.GetPublicKeyAsync()).ReturnsAsync(ecKeyPair.PublicKey);

                return accountService.Object;
            });
            services.AddTransient(o =>
            {
                var smartContractAddressService = new Mock<ISmartContractAddressService>();
                smartContractAddressService.Setup(m=>m.GetAddressByContractName(It.IsAny<Hash>())).Returns(Address.Genesis
                    );

                return smartContractAddressService.Object;
            });
            services.AddSingleton( o=> Mock.Of<IConsensusScheduler>());
            services.AddSingleton( o=> Mock.Of<IConsensusInformationGenerationService>());
            services.AddTransient<IConsensusService, ConsensusService>();
        }
    }
}
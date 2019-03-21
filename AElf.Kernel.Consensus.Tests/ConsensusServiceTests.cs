using System.Threading.Tasks;
using AElf.Consensus.DPoS;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.Consensus.Application;
using AElf.Types.CSharp;
using Google.Protobuf;
using Shouldly;
using Xunit;

namespace AElf.Kernel.Consensus
{
    public class ConsensusServiceTests: ConsensusTestBase
    {
        private readonly IConsensusService _consensusService;
        private readonly IBlockchainService _blockchainService;

        public ConsensusServiceTests()
        {
            _consensusService = GetRequiredService<IConsensusService>();
            _blockchainService = GetRequiredService<IBlockchainService>();
        }

        [Fact]
        public async Task Validate_Consensus_BeforeExecutionTest()
        {
            var chain = await _blockchainService.GetChainAsync();
            var hash = chain.LongestChainHash;
            var block = await _blockchainService.GetBlockByHashAsync(hash);
            var nextBlock = new Block()
            {
                Header = new BlockHeader{ Height = block.Height + 1, BlockExtraDatas = { ByteString.CopyFromUtf8("test1")}}
            };
            var result = await _consensusService.ValidateConsensusBeforeExecutionAsync(nextBlock.GetHash(), block.Height,
                nextBlock.Header.BlockExtraDatas[0].ToByteArray());
        }

        [Fact]
        public async Task Get_NewConsensusInformationTest()
        {
            var byteArray = await _consensusService.GetNewConsensusInformationAsync();
            byteArray.ShouldBeNull();
            var dposTriggerInformation = byteArray.DeserializeToPbMessage<DPoSTriggerInformation>();
        }
    }
}
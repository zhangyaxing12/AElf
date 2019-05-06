using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace AElf.Kernel.Blockchain.Infrastructure
{
    public interface IStaticChainInformationProvider
    {
        int ChainId { get; }
        Address ZeroSmartContractAddress { get; }
    }

    public class StaticChainInformationProvider : IStaticChainInformationProvider, ISingletonDependency
    {
        public int ChainId { get; }
        public Address ZeroSmartContractAddress { get; }

        public StaticChainInformationProvider(IOptionsSnapshot<ChainOptions> chainOptions)
        {
            ChainId = chainOptions.Value.ChainId;
            ZeroSmartContractAddress = BuildContractAddress(ChainId, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chainId"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        private static Address BuildContractAddress(Hash chainId, ulong serialNumber)
        {
            var hash = Hash.FromTwoHashes(chainId, Hash.FromRawBytes(serialNumber.ToBytes()));
            return Address.FromBytes(hash.DumpByteArray());
        }

        private static Address BuildContractAddress(int chainId, ulong serialNumber)
        {
            return BuildContractAddress(chainId.ComputeHash(), serialNumber);
        }
    }
}
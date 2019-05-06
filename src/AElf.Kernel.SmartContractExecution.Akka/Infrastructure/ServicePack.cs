using AElf.Kernel.SmartContract.Application;

namespace AElf.Kernel.SmartContractExecution.Application
{
    //TODO: maybe should change this class
    public class ServicePack
    {
        public IResourceUsageDetectionService ResourceDetectionService { get; set; }
        public ISmartContractService SmartContractService { get; set; }        
    }
}

using AElf.Contracts.TestBase;
using AElf.Kernel;
using AElf.Kernel.Consensus.Application;
using AElf.Modularity;
using AElf.Sdk.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace AElf.Contracts.Token
{
    [DependsOn(
        typeof(KernelAElfModule),
        typeof(ContractTestAElfModule)
    )]
    public class TokenContractTestAElfModule : AElfModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAssemblyOf<TokenContractTestAElfModule>();
        }
    }
}
using System.Threading.Tasks;
using AElf.Kernel.Blockchain.Events;
using AElf.OS.Network.Application;
using AElf.OS.Network.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Local;

namespace AElf.OS.Handlers
{
    namespace AElf.OS.Network.Handler
    {
        public class BlockAcceptedEventHandler : ILocalEventHandler<BlockAcceptedEvent>, ITransientDependency
        {
            public INetworkService NetworkService { get; set; }
            public ILocalEventBus EventBus { get; set; }
            
            public BlockAcceptedEventHandler()
            {
                EventBus = NullLocalEventBus.Instance;
            }

            public Task HandleEventAsync(BlockAcceptedEvent eventData)
            {
                NetworkService.BroadcastAnnounce(eventData.BlockHeader, eventData.HasFork);
                EventBus.PublishAsync(new PreLibConfirmAnnouncementReceivedEventData());
                return Task.CompletedTask;
            }
        }
    }
}
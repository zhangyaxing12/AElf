using System.Collections.Generic;
using System.Threading.Tasks;
using AElf.OS.Network.Types;
using AElf.Types;

namespace AElf.OS.Network.Infrastructure
{
    public interface IPeer
    {
        bool IsBest { get; set; }
        bool IsReady { get; }
        Hash CurrentBlockHash { get; }
        long CurrentBlockHeight { get; }
        
        string PeerIpAddress { get; }
        string PubKey { get; }
        int ProtocolVersion { get; }
        long ConnectionTime { get; }
        bool Inbound { get; }
        long StartHeight { get; }
        
        IReadOnlyDictionary<long, AcceptedBlockInfo> RecentBlockHeightAndHashMappings { get; }
        
        IReadOnlyDictionary<long, PreLibBlockInfo> PreLibBlockHeightAndHashMappings { get; }

        bool CanStreamTransactions { get; }
        bool CanStreamAnnounces { get; }

        void StartTransactionStreaming();
        void StartAnnouncementStreaming();

        Dictionary<string, List<RequestMetric>> GetRequestMetrics();

        void HandlerRemoteAnnounce(PeerNewBlockAnnouncement peerNewBlockAnnouncement);
        
        void HandlerRemotePreLibAnnounce(PeerPreLibAnnouncement peerPreLibAnnouncement);

        bool HasBlock(long blockHeight, Hash blockHash);

        bool HasPreLib(long blockHeight, Hash blockHash);

        Task<bool> TryWaitForStateChangedAsync();

        Task FinalizeConnectAsync();
        Task SendDisconnectAsync();
        Task StopAsync();

        Task AnnounceAsync(PeerNewBlockAnnouncement an);
        Task PreLibAnnounceAsync(PeerPreLibAnnouncement peerPreLibAnnouncement);
        Task PreLibConfirmAnnounceAsync(PeerPreLibConfirmAnnouncement peerPreLibConfirmAnnouncement);
        Task SendTransactionAsync(Transaction tx);
        Task<BlockWithTransactions> RequestBlockAsync(Hash hash);
        Task<List<BlockWithTransactions>> GetBlocksAsync(Hash previousHash, int count);
    }
}
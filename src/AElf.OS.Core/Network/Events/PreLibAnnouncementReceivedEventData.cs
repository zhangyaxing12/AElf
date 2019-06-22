namespace AElf.OS.Network.Events
{
    public class PreLibAnnouncementReceivedEventData
    {
        public PeerPreLibAnnouncement Announce { get; }
        public string SenderPubKey { get; }
        
        public PreLibAnnouncementReceivedEventData(PeerPreLibAnnouncement an, string senderPubKey)
        {
            SenderPubKey = senderPubKey;
            Announce = an;
        }
    }
}
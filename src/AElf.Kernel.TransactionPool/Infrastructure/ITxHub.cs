using System.Collections.Generic;
using System.Threading.Tasks;
using AElf.Kernel.Blockchain.Events;
using AElf.Kernel.EventMessages;

namespace AElf.Kernel.TransactionPool.Infrastructure
{
    public class ExecutableTransactionSet
    {
        public Hash PreviousBlockHash { get; set; }
        public long PreviousBlockHeight { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

    // TODO: Rename method name and params name of Handle**.
    public interface ITxHub
    {
        Task<ExecutableTransactionSet> GetExecutableTransactionSetAsync();
        Task HandleTransactionsReceivedAsync(TransactionsReceivedEvent eventData);
        Task HandleBlockAcceptedAsync(BlockAcceptedEvent eventData);
        Task HandleBestChainFoundAsync(BestChainFoundEventData eventData);
        Task HandleNewIrreversibleBlockFoundAsync(NewIrreversibleBlockFoundEvent eventData);
        Task HandleUnexecutableTransactionsFoundAsync(UnexecutableTransactionsFoundEvent eventData);
        Task<TransactionReceipt> GetTransactionReceiptAsync(Hash transactionId);
        Task<int> GetTransactionPoolSizeAsync();
    }
}
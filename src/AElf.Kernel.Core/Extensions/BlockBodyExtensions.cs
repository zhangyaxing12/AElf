using System.Collections.Generic;

namespace AElf.Kernel
{
    public static class BlockBodyExtensions
    {

        /// <summary>
        /// Calculate merkle tree root of transaction.
        /// </summary>
        /// <returns></returns>
        public static Hash CalculateMerkleTreeRoot(this BlockBody blockBody)
        {
            if (blockBody.TransactionsCount == 0)
                return Hash.Empty;
            if (blockBody.BinaryMerkleTree.Root != null)
                return blockBody.BinaryMerkleTree.Root;
            blockBody.BinaryMerkleTree.AddNodes(blockBody.Transactions);
            blockBody.BinaryMerkleTree.ComputeRootHash();

            return blockBody.BinaryMerkleTree.Root;
        }

        public static void AddTransaction(this BlockBody blockBody, Transaction tx)
        {
            blockBody.Transactions.Add(tx.GetHash());
            blockBody.TransactionList.Add(tx);// TODO: Remove
        }
    }
}
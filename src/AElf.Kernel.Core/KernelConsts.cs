using System;

namespace AElf.Kernel
{
    // TODO: KernelConsts -> KernelConstants (conflict currently)
    public static class KernelConsts
    {
        public const string MergeBlockStateQueueName = "MergeBlockStateQueue";
        public const string UpdateChainQueueName = "UpdateChainQueue";
        public const string StorageKeySeparator = ",";
        public static TimeSpan AllowedFutureBlockTimeSpan = TimeSpan.FromSeconds(4);
    }
}
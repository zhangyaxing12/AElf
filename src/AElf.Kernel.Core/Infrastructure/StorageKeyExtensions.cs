namespace AElf.Kernel.Infrastructure
{
    public static class StorageKeyExtensions
    {
        public static string ToStorageKey(this long n)
        {
            return n.ToString();
        }

        public static string ToStorageKey(this int n)
        {
            return n.ToString();
        }
        public static string ToStorageKey(this Hash hash)
        {
            return hash.Value.ToBase64();
        }

        public static string ToStorageKey(this Address address)
        {
            return address.Value.ToBase64();
        }
    }
}
using System;

namespace AElf.Kernel
{
    // TODO: Move to Types
    public static class HashExtensions
    {
        // TODO: Consider Span
        public static Hash Xor(this Hash hash, Hash another)
        {
            if (hash.Value.Length != another.Value.Length)
            {
                throw new InvalidOperationException("The two hashes don't have the same length");
            }

            var newBytes = new byte[hash.Value.Length];
            for (var i = 0; i < hash.Value.Length; ++i)
            {
                newBytes[i] = (byte) (hash.Value[i] ^ another.Value[i]);
            }

            return Hash.LoadByteArray(newBytes);
        }
    }
}
using System.Threading.Tasks;

namespace AElf.Kernel.Account.Application
{
    // TODO: Implement an in memory AccountService here.
    public interface IAccountService
    {
        Task<byte[]> SignAsync(byte[] data);
        Task<bool> VerifySignatureAsync(byte[] signature, byte[] data, byte[] publicKey);
        Task<byte[]> GetPublicKeyAsync();
        Task<byte[]> EncryptMessageAsync(byte[] receiverPublicKey, byte[] plainMessage);
        Task<byte[]> DecryptMessageAsync(byte[] senderPublicKey, byte[] cipherMessage);
    }

    public static class AccountServiceExtensions
    {
        public static async Task<Address> GetAccountAsync(this IAccountService accountService)
        {
            return Address.FromPublicKey(await accountService.GetPublicKeyAsync());
        }

    }
}
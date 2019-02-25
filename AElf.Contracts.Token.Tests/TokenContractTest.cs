using System;
using System.IO;
using AElf.Contracts.TestBase;
using Shouldly;
using Xunit;

namespace AElf.Contracts.Token
{
    public sealed class TokenContractTest : TokenContractTestBase
    {
        private byte[] _contractCode;
        private ContractExecutor _executor;

        public TokenContractTest()
        {
            _contractCode = File.ReadAllBytes(typeof(TokenContract).Assembly.Location);
            _executor = GetRequiredService<ContractExecutor>();
        }

        [Fact]
        public void Deploy_Contract()
        {
            var contractAddress = _executor.DeployContractTest(_contractCode, (ulong) new Random().Next()).Result;
            contractAddress.ShouldNotBe(null);
        }
    }
}
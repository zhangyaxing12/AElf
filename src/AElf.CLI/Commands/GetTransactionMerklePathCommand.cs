using Alba.CsConsoleFormat.Fluent;
using CommandLine;

namespace AElf.CLI.Commands
{
    public class GetTransactionMerklePathOption : BaseOption
    {
        [Value(0, HelpText = "The transaction hash to query.", Required = true)]
        public string TxId { get; set; } = "";
        
        [Value(0, HelpText = "The height of block in which transaction packed.", Required = true)]
        public long Height { get; set; }
    }
    
    public class GetTransactionMerklePathCommand : Command
    {
        private GetTransactionMerklePathOption _option;
        public GetTransactionMerklePathCommand(GetTransactionMerklePathOption option) : base(option)
        {
            _option = option;
        }

        public override void Execute()
        {
            if (string.IsNullOrEmpty(_option.Endpoint))
            {
                Colors.WriteLine("Endpoint is not provided. Cannot proceed.".DarkRed());
                return;
            }

            if (_option.Height == 0)
            {
                Colors.WriteLine("Invalid block height is provided.".DarkRed());
                return;
            }

            if (_option.TxId == "")
            {
                Colors.WriteLine("Transaction id id needed for merkle path.".DarkRed());
                return;
            }
            
            _engine.RunScript($@"
                    var res = aelf.chain.getMerklePath({_option.TxId}, {_option.Height});
                ");
            
            // print merkle path
            _engine.RunScript($@"
                    console.log(res.toString('hex'));
                    //res.forEach(function (path) {{console.log(path.toString('hex'));}});
                ");
            
        }
    }
}
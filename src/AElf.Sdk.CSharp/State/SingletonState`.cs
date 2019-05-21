using System.Text;
using AElf.Kernel;
using Google.Protobuf;

namespace AElf.Sdk.CSharp.State
{
    public class SingletonState : StateBase
    {
    }

    public class SingletonState<TEntity> : SingletonState
    {
        internal bool Loaded = false;
        internal bool Modified => Equals(_originalValue, _value);

        private TEntity _originalValue;
        private TEntity _value;

        public TEntity Value
        {
            get
            {
                if (!Loaded)
                {
                    Load();
                }

                return _value;
            }
            set
            {
                if (!Loaded)
                {
                    Load();
                }

                _value = value;
            }
        }

        internal override void Clear()
        {
            Loaded = false;
            if (typeof(TEntity) == typeof(byte[]))
            {
                _originalValue = (TEntity) (object) new byte[0];
            }
            else
            {
                _originalValue = default(TEntity);
            }

            _value = _originalValue;
        }

        internal override TransactionExecutingStateSet GetChanges()
        {
            var stateSet = new TransactionExecutingStateSet();
            if (!Equals(_originalValue, _value))
            {
                stateSet.Writes[Path.ToStateKey(Context.Self)] = ByteString.CopyFrom(SerializationHelper.Serialize(_value));
                Context.LogDebug(() =>$"Current block height: {Context.CurrentHeight}");     
                Context.LogDebug(() => $"SingletonState: {Path.Parts}");
                Context.LogDebug(() => $"SingletonState value type is: {_value.GetType()}");
                Context.LogDebug(()=>$"SingletonState: Original Value = {_originalValue}");
                Context.LogDebug(()=>$"SingletonState: Value = {_value}");
                var key = Path.ToStateKey(Context.Self);
                byte[] b=Encoding.Default.GetBytes(key);                 
                Context.LogDebug(()=>$"SingletonState key size is: {sizeof(byte)*b.Length}");
                
                if (_originalValue !=null )
                {
                    var originalvalue = ByteString.CopyFrom(SerializationHelper.Serialize(_originalValue));
                    Context.LogDebug(() =>$"SingletonState original value size is: {originalvalue.ToByteArray().Length}");
                }
                var value = ByteString.CopyFrom(SerializationHelper.Serialize(_value));;
                Context.LogDebug(()=>$"SingletonState current value size is: {value.ToByteArray().Length}");
            }

            return stateSet;
        }

        private void Load()
        {
            var bytes = Provider.GetAsync(Path).Result;
            _originalValue = SerializationHelper.Deserialize<TEntity>(bytes);
            _value = SerializationHelper.Deserialize<TEntity>(bytes);
            Loaded = true;
        }
    }
}
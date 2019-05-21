using System.Collections.Generic;
using System.Text;
using AElf.Kernel;
using Google.Protobuf;

namespace AElf.Sdk.CSharp.State
{
    public class MappedStateBase : StateBase
    {
        internal StatePath GetSubStatePath(string key)
        {
            var statePath = this.Path.Clone();
            statePath.Parts.Add(key);
            return statePath;
        }
    }

    public class MappedState<TKey, TEntity> : MappedStateBase
    {
        internal class ValuePair
        {
            internal TEntity OriginalValue;
            internal TEntity Value;
        }

        internal Dictionary<TKey, ValuePair> Cache = new Dictionary<TKey, ValuePair>();

        public TEntity this[TKey key]
        {
            get
            {
                if (!Cache.TryGetValue(key, out var valuePair))
                {
                    valuePair = LoadKey(key);
                }

                return valuePair.Value;
            }
            set
            {
                if (!Cache.TryGetValue(key, out var valuePair))
                {
                    valuePair = LoadKey(key);
                    Cache[key] = valuePair;
                }

                valuePair.Value = value;
            }
        }

        internal override void Clear()
        {
            Cache = new Dictionary<TKey, ValuePair>();
        }

        internal override TransactionExecutingStateSet GetChanges()
        {
            var stateSet = new TransactionExecutingStateSet();
            foreach (var kv in Cache)
            {
                if (!Equals(kv.Value.OriginalValue, kv.Value.Value))
                {
                    var key = GetSubStatePath(kv.Key.ToString()).ToStateKey(Context.Self);
                    
                    stateSet.Writes[key] = ByteString.CopyFrom(SerializationHelper.Serialize(kv.Value.Value));
                    var value = ByteString.CopyFrom(SerializationHelper.Serialize(kv.Value.Value));
                    Context.LogDebug(() =>$"Current block height: {Context.CurrentHeight}");
                    Context.LogDebug(() => $"MappedState: {Path.Parts}");
                    Context.LogDebug(() => $"MappedState value type is: {kv.Value.Value.GetType()}");
                    Context.LogDebug(() =>$"MappedState: Original Value = {kv.Value.OriginalValue}");
                    Context.LogDebug(() =>$"MappedState: Value = {kv.Value.Value}");
                    
                    byte[] b=Encoding.Default.GetBytes(key);        
                    Context.LogDebug(() =>$"MappedState key size is: {sizeof(byte)*b.Length}");
                    
                    if (kv.Value.OriginalValue !=null )
                    {
                        var originalval = ByteString.CopyFrom(SerializationHelper.Serialize(kv.Value.OriginalValue));
                        Context.LogDebug(() =>$"MappedState original value size is: {originalval.ToByteArray().Length}");
                    }

                    Context.LogDebug(() =>$"MappedState current value size is: {value.ToByteArray().Length}");
                }
            }

            return stateSet;
        }

        private ValuePair LoadKey(TKey key)
        {
            var path = GetSubStatePath(key.ToString());
            var bytes = Provider.GetAsync(path).Result;
            var value = SerializationHelper.Deserialize<TEntity>(bytes);

            return new ValuePair()
            {
                OriginalValue = value,
                Value = value
            };
        }
    }

    public class MappedState<TKey1, TKey2, TEntity> : MappedStateBase
    {
        internal Dictionary<TKey1, MappedState<TKey2, TEntity>> Cache =
            new Dictionary<TKey1, MappedState<TKey2, TEntity>>();

        public MappedState<TKey2, TEntity> this[TKey1 key1]
        {
            get
            {
                if (!Cache.TryGetValue(key1, out var child))
                {
                    child = new MappedState<TKey2, TEntity>()
                    {
                        Context = Context,
                        Path = GetSubStatePath(key1.ToString())
                    };
                    Cache[key1] = child;
                }

                return child;
            }
        }

        internal override void OnContextSet()
        {
            foreach (var v in Cache.Values)
            {
                v.Context = Context;
            }
        }

        internal override void Clear()
        {
            Cache = new Dictionary<TKey1, MappedState<TKey2, TEntity>>();
        }

        internal override TransactionExecutingStateSet GetChanges()
        {
            var stateSet = new TransactionExecutingStateSet();
            foreach (var kv in Cache)
            {
                foreach (var kv1 in kv.Value.GetChanges().Writes)
                {
                    stateSet.Writes[kv1.Key] = kv1.Value;
                    var value = kv1.Value;
                    var key = kv1.Key;
                    byte[] b = Encoding.Default.GetBytes(key);
                    Context.LogDebug(() =>$"2 keys MappedState: {kv1.Key}, key size is {sizeof(byte)*b.Length}, value size is {value.ToByteArray().Length}");
                }
                Context.LogDebug(() =>$"2 keys MappedState: {Path.Parts}"); 
                Context.LogDebug(() =>$"2 keys MappedState: {kv.Key},{kv.Value}");
            }

            return stateSet;
        }
    }

    public class MappedState<TKey1, TKey2, TKey3, TEntity> : MappedStateBase
    {
        internal Dictionary<TKey1, MappedState<TKey2, TKey3, TEntity>> Cache =
            new Dictionary<TKey1, MappedState<TKey2, TKey3, TEntity>>();

        public MappedState<TKey2, TKey3, TEntity> this[TKey1 key1]
        {
            get
            {
                if (!Cache.TryGetValue(key1, out var child))
                {
                    child = new MappedState<TKey2, TKey3, TEntity>()
                    {
                        Context = Context,
                        Path = GetSubStatePath(key1.ToString())
                    };
                    Cache[key1] = child;
                }

                return child;
            }
        }

        internal override void OnContextSet()
        {
            foreach (var v in Cache.Values)
            {
                v.Context = Context;
            }
        }

        internal override void Clear()
        {
            Cache = new Dictionary<TKey1, MappedState<TKey2, TKey3, TEntity>>();
        }

        internal override TransactionExecutingStateSet GetChanges()
        {
            var stateSet = new TransactionExecutingStateSet();
            foreach (var kv in Cache)
            {
                foreach (var kv1 in kv.Value.GetChanges().Writes)
                {
                    stateSet.Writes[kv1.Key] = kv1.Value;
                    var value = kv1.Value;
                    var key = kv1.Key;
                    byte[] b = Encoding.Default.GetBytes(key);
                    Context.LogDebug(() =>$"3 keys MappedState: {kv1.Key}, key size is {sizeof(byte)*b.Length}, value size is {value.ToByteArray().Length}");
                }   
                Context.LogDebug(() =>$"3 keys MappedState: {Path.Parts}");
                Context.LogDebug(() =>$"3 keys MappedState: {kv.Key},{kv.Value}");
            } 

            return stateSet;
        }
    }

    public class MappedState<TKey1, TKey2, TKey3, TKey4, TEntity> : MappedStateBase
    {
        internal Dictionary<TKey1, MappedState<TKey2, TKey3, TKey4, TEntity>> Cache =
            new Dictionary<TKey1, MappedState<TKey2, TKey3, TKey4, TEntity>>();

        public MappedState<TKey2, TKey3, TKey4, TEntity> this[TKey1 key1]
        {
            get
            {
                if (!Cache.TryGetValue(key1, out var child))
                {
                    child = new MappedState<TKey2, TKey3, TKey4, TEntity>()
                    {
                        Context = Context,
                        Path = GetSubStatePath(key1.ToString())
                    };
                    Cache[key1] = child;
                }

                return child;
            }
        }

        internal override void OnContextSet()
        {
            foreach (var v in Cache.Values)
            {
                v.Context = Context;
            }
        }

        internal override void Clear()
        {
            Cache = new Dictionary<TKey1, MappedState<TKey2, TKey3, TKey4, TEntity>>();
        }

        internal override TransactionExecutingStateSet GetChanges()
        {
            var stateSet = new TransactionExecutingStateSet();
            foreach (var kv in Cache)
            {
                foreach (var kv1 in kv.Value.GetChanges().Writes)
                {
                    stateSet.Writes[kv1.Key] = kv1.Value;
                    var value = kv1.Value;
                    var key = kv1.Key;
                    byte[] b = Encoding.Default.GetBytes(key);
                    Context.LogDebug(() =>$"4 keys MappedState: {kv1.Key}, key size is {sizeof(byte)*b.Length}, value size is {value.ToByteArray().Length}");
                }
                Context.LogDebug(()=>$"4 keys MappedState: {Path.Parts}");
                Context.LogDebug(()=>$"4 keys MappedState: {kv.Key},{kv.Value}");
            }
      
            return stateSet;
        }
    }
}
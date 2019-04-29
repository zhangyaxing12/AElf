# AElf API

## AElf

**Kind**: global class

* [AElf](aelf.md#AElf)
  * [new AElf\(provider\)](aelf.md#new_AElf_new)
  * _instance_
    * [.setProvider\(provider\)](aelf.md#AElf+setProvider)
    * [.reset\(keepIsSyncing\)](aelf.md#AElf+reset)
    * [.isConnected\(\)](aelf.md#AElf+isConnected) ⇒ `boolean`
  * _static_
    * [.wallet](aelf.md#AElf.wallet)
    * [.pbjs](aelf.md#AElf.pbjs)
    * [.pbUtils](aelf.md#AElf.pbUtils)
    * [.version](aelf.md#AElf.version)

### new AElf\(provider\)

AElf

| Param | Type | Description |
| :--- | :--- | :--- |
| provider | `Object` | the instance of HttpProvider |

**Example**

```javascript
const aelf = new AElf(new AElf.providers.HttpProvider('https://127.0.0.1:8000/chain'))
```

### aelf.setProvider\(provider\)

change the provider of the instance of AElf

**Kind**: instance method of [`AElf`](aelf.md#AElf)

| Param | Type | Description |
| :--- | :--- | :--- |
| provider | `Object` | the instance of HttpProvider |

**Example**

```javascript
const aelf = new AElf(new AElf.providers.HttpProvider('https://127.0.0.1:8000/chain'));
aelf.setProvider(new AElf.providers.HttpProvider('https://127.0.0.1:8010/chain'))
```

### aelf.reset\(keepIsSyncing\)

reset

**Kind**: instance method of [`AElf`](aelf.md#AElf)

| Param | Type | Description |
| :--- | :--- | :--- |
| keepIsSyncing | `boolean` | true/false |

**Example**

```javascript
// keepIsSyncing = true/false
aelf.reset(keepIsSyncing);
```

### aelf.isConnected\(\) ⇒ `boolean`

check the rpc node is work or not

**Kind**: instance method of [`AElf`](aelf.md#AElf)  
**Returns**: `boolean` - true/false whether can connect to the rpc.  
**Example**

```javascript
aelf.isConnected()
// return true / false
```

### AElf.wallet

wallet tool

**Kind**: static property of [`AElf`](aelf.md#AElf)  


### AElf.pbjs

protobufjs

**Kind**: static property of [`AElf`](aelf.md#AElf)  


### AElf.pbUtils

some method about protobufjs of AElf

**Kind**: static property of [`AElf`](aelf.md#AElf)  


### AElf.version

get the verion of the SDK

**Kind**: static property of [`AElf`](aelf.md#AElf)


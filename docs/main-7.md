# Web api reference

Click to get the [swagger.json](main-7.md#swagger-json)

## Overview

### Version information

_Version_ : 1.0

## Paths

### Get information about a given block by block hash. Otionally with the list of its transactions.

```text
GET /api/blockChain/block
```

#### Parameters

| Type | Name | Description | Schema | Default |
| :--- | :--- | :--- | :--- | :--- |
| **Query** | **blockHash**   _optional_ | block hash | string |  |
| **Query** | **includeTransactions**   _optional_ | include transactions or not | boolean | `"false"` |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [BlockDto](main-7.md#blockdto) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get information about a given block by block height. Otionally with the list of its transactions.

```text
GET /api/blockChain/blockByHeight
```

#### Parameters

| Type | Name | Description | Schema | Default |
| :--- | :--- | :--- | :--- | :--- |
| **Query** | **blockHeight**   _optional_ | block height | integer \(int64\) |  |
| **Query** | **includeTransactions**   _optional_ | include transactions or not | boolean | `"false"` |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [BlockDto](main-7.md#blockdto) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get the height of the current chain.

```text
GET /api/blockChain/blockHeight
```

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | integer \(int64\) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get the current state about a given block

```text
GET /api/blockChain/blockState
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **blockHash**   _optional_ | block hash | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [BlockStateDto](main-7.md#blockstatedto) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Broadcast a transaction

```text
POST /api/blockChain/broadcastTransaction
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **rawTransaction**   _optional_ | raw transaction | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [BroadcastTransactionOutput](main-7.md#broadcasttransactionoutput) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Broadcast multiple transactions

```text
POST /api/blockChain/broadcastTransactions
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **rawTransactions**   _optional_ | raw transactions | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | &lt; string &gt; array |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Call a read-only method on a contract.

```text
POST /api/blockChain/call
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **rawTransaction**   _optional_ | raw transaction | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | string |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get the current status of the block chain.

```text
GET /api/blockChain/chainStatus
```

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [ChainStatusDto](main-7.md#chainstatusdto) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get the protobuf definitions related to a contract

```text
GET /api/blockChain/contractFileDescriptorSet
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **address**   _optional_ | contract address | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | string \(byte\) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get the transaction pool status.

```text
GET /api/blockChain/transactionPoolStatus
```

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [GetTransactionPoolStatusOutput](main-7.md#gettransactionpoolstatusoutput) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get the current status of a transaction

```text
GET /api/blockChain/transactionResult
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **transactionId**   _optional_ | transaction id | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | [TransactionResultDto](main-7.md#transactionresultdto) |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Get multiple transaction results.

```text
GET /api/blockChain/transactionResults
```

#### Parameters

| Type | Name | Description | Schema | Default |
| :--- | :--- | :--- | :--- | :--- |
| **Query** | **blockHash**   _optional_ | block hash | string |  |
| **Query** | **limit**   _optional_ | limit | integer \(int32\) | `10` |
| **Query** | **offset**   _optional_ | offset | integer \(int32\) | `0` |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | &lt; [TransactionResultDto](main-7.md#transactionresultdto) &gt; array |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* BlockChain

### Attempts to add a node to the connected network nodes

```text
POST /api/net/peer
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **address**   _optional_ | ip address | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | boolean |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* Net

### Attempts to remove a node from the connected network nodes

```text
DELETE /api/net/peer
```

#### Parameters

| Type | Name | Description | Schema |
| :--- | :--- | :--- | :--- |
| **Query** | **address**   _optional_ | ip address | string |

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | boolean |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* Net

### Get ip addresses about the connected network nodes

```text
GET /api/net/peers
```

#### Responses

| HTTP Code | Description | Schema |
| :--- | :--- | :--- |
| **200** | Success | &lt; string &gt; array |

#### Produces

* `text/plain; v=1.0`
* `application/json; v=1.0`
* `text/json; v=1.0`
* `application/x-protobuf; v=1.0`

#### Tags

* Net

## Definitions

### BlockBodyDto

| Name | Schema |
| :--- | :--- |
| **Transactions**   _optional_ | &lt; string &gt; array |
| **TransactionsCount**   _optional_ | integer \(int32\) |

### BlockDto

| Name | Schema |
| :--- | :--- |
| **BlockHash**   _optional_ | string |
| **Body**   _optional_ | [BlockBodyDto](main-7.md#blockbodydto) |
| **Header**   _optional_ | [BlockHeaderDto](main-7.md#blockheaderdto) |

### BlockHeaderDto

| Name | Schema |
| :--- | :--- |
| **Bloom**   _optional_ | string |
| **ChainId**   _optional_ | string |
| **Extra**   _optional_ | string |
| **Height**   _optional_ | integer \(int64\) |
| **MerkleTreeRootOfTransactions**   _optional_ | string |
| **MerkleTreeRootOfWorldState**   _optional_ | string |
| **PreviousBlockHash**   _optional_ | string |
| **Time**   _optional_ | string \(date-time\) |

### BlockStateDto

| Name | Schema |
| :--- | :--- |
| **BlockHash**   _optional_ | string |
| **BlockHeight**   _optional_ | integer \(int64\) |
| **Changes**   _optional_ | &lt; string, string &gt; map |
| **PreviousHash**   _optional_ | string |

### BroadcastTransactionOutput

| Name | Schema |
| :--- | :--- |
| **TransactionId**   _optional_ | string |

### ChainStatusDto

| Name | Schema |
| :--- | :--- |
| **BestChainHash**   _optional_ | string |
| **BestChainHeight**   _optional_ | integer \(int64\) |
| **Branches**   _optional_ | &lt; string, integer \(int64\) &gt; map |
| **ChainId**   _optional_ | string |
| **GenesisBlockHash**   _optional_ | string |
| **GenesisContractAddress**   _optional_ | string |
| **LastIrreversibleBlockHash**   _optional_ | string |
| **LastIrreversibleBlockHeight**   _optional_ | integer \(int64\) |
| **LongestChainHash**   _optional_ | string |
| **LongestChainHeight**   _optional_ | integer \(int64\) |
| **NotLinkedBlocks**   _optional_ | &lt; [NotLinkedBlockDto](main-7.md#notlinkedblockdto) &gt; array |

### GetTransactionPoolStatusOutput

| Name | Schema |
| :--- | :--- |
| **Queued**   _optional_ | integer \(int32\) |

### LogEventDto

| Name | Schema |
| :--- | :--- |
| **Address**   _optional_ | string |
| **Indexed**   _optional_ | &lt; string &gt; array |
| **Name**   _optional_ | string |
| **NonIndexed**   _optional_ | string |

### NotLinkedBlockDto

| Name | Schema |
| :--- | :--- |
| **BlockHash**   _optional_ | string |
| **Height**   _optional_ | integer \(int64\) |
| **PreviousBlockHash**   _optional_ | string |

### TransactionDto

| Name | Schema |
| :--- | :--- |
| **From**   _optional_ | string |
| **MethodName**   _optional_ | string |
| **Params**   _optional_ | string |
| **RefBlockNumber**   _optional_ | integer \(int64\) |
| **RefBlockPrefix**   _optional_ | string |
| **Sigs**   _optional_ | &lt; string &gt; array |
| **To**   _optional_ | string |

### TransactionResultDto

| Name | Schema |
| :--- | :--- |
| **BlockHash**   _optional_ | string |
| **BlockNumber**   _optional_ | integer \(int64\) |
| **Bloom**   _optional_ | string |
| **Error**   _optional_ | string |
| **Logs**   _optional_ | &lt; [LogEventDto](main-7.md#logeventdto) &gt; array |
| **ReadableReturnValue**   _optional_ | string |
| **Status**   _optional_ | string |
| **Transaction**   _optional_ | [TransactionDto](main-7.md#transactiondto) |
| **TransactionId**   _optional_ | string |

## Swagger.json

You can input it into online Swagger Editor: [http://editor.swagger.io/](http://editor.swagger.io/)

```javascript
{"swagger":"2.0","info":{"version":"1.0","title":"AELF API 1.0"},"paths":{"/api/blockChain/call":{"post":{"tags":["BlockChain"],"summary":"Call a read-only method on a contract.","operationId":"Call","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"rawTransaction","in":"query","description":"raw transaction","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"type":"string"}}}}},"/api/blockChain/contractFileDescriptorSet":{"get":{"tags":["BlockChain"],"summary":"Get the protobuf definitions related to a contract","operationId":"GetContractFileDescriptorSet","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"address","in":"query","description":"contract address","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"format":"byte","type":"string"}}}}},"/api/blockChain/broadcastTransaction":{"post":{"tags":["BlockChain"],"summary":"Broadcast a transaction","operationId":"BroadcastTransaction","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"rawTransaction","in":"query","description":"raw transaction","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/BroadcastTransactionOutput"}}}}},"/api/blockChain/broadcastTransactions":{"post":{"tags":["BlockChain"],"summary":"Broadcast multiple transactions","operationId":"BroadcastTransactions","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"rawTransactions","in":"query","description":"raw transactions","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"uniqueItems":false,"type":"array","items":{"type":"string"}}}}}},"/api/blockChain/transactionResult":{"get":{"tags":["BlockChain"],"summary":"Get the current status of a transaction","operationId":"GetTransactionResult","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"transactionId","in":"query","description":"transaction id","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/TransactionResultDto"}}}}},"/api/blockChain/transactionResults":{"get":{"tags":["BlockChain"],"summary":"Get multiple transaction results.","operationId":"GetTransactionResults","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"blockHash","in":"query","description":"block hash","required":false,"type":"string"},{"name":"offset","in":"query","description":"offset","required":false,"type":"integer","format":"int32","default":0},{"name":"limit","in":"query","description":"limit","required":false,"type":"integer","format":"int32","default":10}],"responses":{"200":{"description":"Success","schema":{"uniqueItems":false,"type":"array","items":{"$ref":"#/definitions/TransactionResultDto"}}}}}},"/api/blockChain/blockHeight":{"get":{"tags":["BlockChain"],"summary":"Get the height of the current chain.","operationId":"GetBlockHeight","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[],"responses":{"200":{"description":"Success","schema":{"format":"int64","type":"integer"}}}}},"/api/blockChain/block":{"get":{"tags":["BlockChain"],"summary":"Get information about a given block by block hash. Otionally with the list of its transactions.","operationId":"GetBlock","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"blockHash","in":"query","description":"block hash","required":false,"type":"string"},{"name":"includeTransactions","in":"query","description":"include transactions or not","required":false,"type":"boolean","default":false}],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/BlockDto"}}}}},"/api/blockChain/blockByHeight":{"get":{"tags":["BlockChain"],"summary":"Get information about a given block by block height. Otionally with the list of its transactions.","operationId":"GetBlockByHeight","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"blockHeight","in":"query","description":"block height","required":false,"type":"integer","format":"int64"},{"name":"includeTransactions","in":"query","description":"include transactions or not","required":false,"type":"boolean","default":false}],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/BlockDto"}}}}},"/api/blockChain/transactionPoolStatus":{"get":{"tags":["BlockChain"],"summary":"Get the transaction pool status.","operationId":"GetTransactionPoolStatus","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/GetTransactionPoolStatusOutput"}}}}},"/api/blockChain/chainStatus":{"get":{"tags":["BlockChain"],"summary":"Get the current status of the block chain.","operationId":"GetChainStatus","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/ChainStatusDto"}}}}},"/api/blockChain/blockState":{"get":{"tags":["BlockChain"],"summary":"Get the current state about a given block","operationId":"GetBlockState","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"blockHash","in":"query","description":"block hash","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"$ref":"#/definitions/BlockStateDto"}}}}},"/api/net/peer":{"post":{"tags":["Net"],"summary":"Attempts to add a node to the connected network nodes","operationId":"AddPeer","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"address","in":"query","description":"ip address","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"type":"boolean"}}}},"delete":{"tags":["Net"],"summary":"Attempts to remove a node from the connected network nodes","operationId":"RemovePeer","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[{"name":"address","in":"query","description":"ip address","required":false,"type":"string"}],"responses":{"200":{"description":"Success","schema":{"type":"boolean"}}}}},"/api/net/peers":{"get":{"tags":["Net"],"summary":"Get ip addresses about the connected network nodes","operationId":"GetPeers","consumes":[],"produces":["text/plain; v=1.0","application/json; v=1.0","text/json; v=1.0","application/x-protobuf; v=1.0"],"parameters":[],"responses":{"200":{"description":"Success","schema":{"uniqueItems":false,"type":"array","items":{"type":"string"}}}}}}},"definitions":{"BroadcastTransactionOutput":{"type":"object","properties":{"TransactionId":{"type":"string"}}},"TransactionResultDto":{"type":"object","properties":{"TransactionId":{"type":"string"},"Status":{"type":"string"},"Logs":{"uniqueItems":false,"type":"array","items":{"$ref":"#/definitions/LogEventDto"}},"Bloom":{"type":"string"},"BlockNumber":{"format":"int64","type":"integer"},"BlockHash":{"type":"string"},"Transaction":{"$ref":"#/definitions/TransactionDto"},"ReadableReturnValue":{"type":"string"},"Error":{"type":"string"}}},"LogEventDto":{"type":"object","properties":{"Address":{"type":"string"},"Name":{"type":"string"},"Indexed":{"uniqueItems":false,"type":"array","items":{"type":"string"}},"NonIndexed":{"type":"string"}}},"TransactionDto":{"type":"object","properties":{"From":{"type":"string"},"To":{"type":"string"},"RefBlockNumber":{"format":"int64","type":"integer"},"RefBlockPrefix":{"type":"string"},"MethodName":{"type":"string"},"Params":{"type":"string"},"Sigs":{"uniqueItems":false,"type":"array","items":{"type":"string"}}}},"BlockDto":{"type":"object","properties":{"BlockHash":{"type":"string"},"Header":{"$ref":"#/definitions/BlockHeaderDto"},"Body":{"$ref":"#/definitions/BlockBodyDto"}}},"BlockHeaderDto":{"type":"object","properties":{"PreviousBlockHash":{"type":"string"},"MerkleTreeRootOfTransactions":{"type":"string"},"MerkleTreeRootOfWorldState":{"type":"string"},"Extra":{"type":"string"},"Height":{"format":"int64","type":"integer"},"Time":{"format":"date-time","type":"string"},"ChainId":{"type":"string"},"Bloom":{"type":"string"}}},"BlockBodyDto":{"type":"object","properties":{"TransactionsCount":{"format":"int32","type":"integer"},"Transactions":{"uniqueItems":false,"type":"array","items":{"type":"string"}}}},"GetTransactionPoolStatusOutput":{"type":"object","properties":{"Queued":{"format":"int32","type":"integer"}}},"ChainStatusDto":{"type":"object","properties":{"ChainId":{"type":"string"},"Branches":{"type":"object","additionalProperties":{"format":"int64","type":"integer"}},"NotLinkedBlocks":{"uniqueItems":false,"type":"array","items":{"$ref":"#/definitions/NotLinkedBlockDto"}},"LongestChainHeight":{"format":"int64","type":"integer"},"LongestChainHash":{"type":"string"},"GenesisBlockHash":{"type":"string"},"GenesisContractAddress":{"type":"string"},"LastIrreversibleBlockHash":{"type":"string"},"LastIrreversibleBlockHeight":{"format":"int64","type":"integer"},"BestChainHash":{"type":"string"},"BestChainHeight":{"format":"int64","type":"integer"}}},"NotLinkedBlockDto":{"type":"object","properties":{"BlockHash":{"type":"string"},"Height":{"format":"int64","type":"integer"},"PreviousBlockHash":{"type":"string"}}},"BlockStateDto":{"type":"object","properties":{"BlockHash":{"type":"string"},"PreviousHash":{"type":"string"},"BlockHeight":{"format":"int64","type":"integer"},"Changes":{"type":"object","additionalProperties":{"type":"string"}}}}}}
```


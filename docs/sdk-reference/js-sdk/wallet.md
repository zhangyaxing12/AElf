# AElf.wallet API

## AElf/wallet

wallet module.

* [AElf/wallet](wallet.md#module_AElf/wallet)
  * [AESEncrypto\(input, password\)](wallet.md#exp_module_AElf/wallet--AESEncrypto) ⇒ `string` ⏏
  * [AESDecrypto\(input, password\)](wallet.md#exp_module_AElf/wallet--AESDecrypto) ⇒ `string` ⏏
  * [createNewWallet\(\)](wallet.md#exp_module_AElf/wallet--createNewWallet) ⇒ `Object` ⏏
  * [getAddressFromPubKey\(pubKey\)](wallet.md#exp_module_AElf/wallet--getAddressFromPubKey) ⇒ `string` ⏏
  * [getWalletByMnemonic\(mnemonic\)](wallet.md#exp_module_AElf/wallet--getWalletByMnemonic) ⇒ `Object` ⏏
  * [getWalletByPrivateKey\(privateKey\)](wallet.md#exp_module_AElf/wallet--getWalletByPrivateKey) ⇒ `Object` ⏏
  * [signTransaction\(rawTxn, keyPair\)](wallet.md#exp_module_AElf/wallet--signTransaction) ⇒ `Object` ⏏
  * [sign\(hexTxn, keyPair\)](wallet.md#exp_module_AElf/wallet--sign) ⇒ `Buffer` ⏏

### AESEncrypto\(input, password\) ⇒ `string` ⏏

Advanced Encryption Standard need crypto-js

**Kind**: Exported function  
**Returns**: `string` - crypted input

| Param | Type | Description |
| :--- | :--- | :--- |
| input | `string` | anything you want to encrypt |
| password | `string` | password |

**Example**

```javascript
const AESEncryptoPrivateKey = aelf.wallet.AESEncrypto('123', '123');
// AESEncryptoPrivateKey = "U2FsdGVkX1+RYovrVJVEEl8eiIUA3vx4GrNR+3sqOow="
const AESEncryptoMnemonic = alef.wallet.AESEncrypto('hello world', '123');
// AESEncryptoMnemonic = U2FsdGVkX19gCjHzYmoY5FGZA1ArXG+eGZIR77dK2GE=
```

### AESDecrypto\(input, password\) ⇒ `string` ⏏

Decrypt any encrypted information you want to decrypt

**Kind**: Exported function  
**Returns**: `string` - decrypted input

| Param | Type | Description |
| :--- | :--- | :--- |
| input | `string` | anything you want to decrypt |
| password | `string` | password |

**Example**

```javascript
const AESDecryptoPrivateKey = aelf.wallet.AESDecrypto('U2FsdGVkX18+tvF7t4rhGOi5cbUvdTH2U5a6Tbu4Ojg=', '123');
// AESDecryptoPrivateKey = "123"
const AESDecryptoMnemonic = aelf.wallet.AESDecrypto('U2FsdGVkX19gCjHzYmoY5FGZA1ArXG+eGZIR77dK2GE=', '123');
// AESDecryptoMnemonic = "hello world"
```

### createNewWallet\(\) ⇒ `Object` ⏏

create a wallet

**Kind**: Exported function  
**Returns**: `Object` - wallet  
**Example**

```javascript
const wallet = aelf.wallet.createNewWallet();
// The format returned is similar to this
// wallet = {
//     address: "5uhk3434242424"
//     keyPair: KeyPair {ec: EC, priv: BN, pub: Point}
//     mnemonic: "hello world"
//     privateKey: "123f7c123"
//     xPrivateKey: "475f7c475"
// }
```

### getAddressFromPubKey\(pubKey\) ⇒ `string` ⏏

the same as in C\#

**Kind**: Exported function  
**Returns**: `string` - address encoded address

| Param | Type | Description |
| :--- | :--- | :--- |
| pubKey | `Object` | get the pubKey you want through keyPair |

**Example**

```javascript
const pubKey = wallet.keyPair.getPublic();
const address = aelf.wallet.getAddressFromPubKey(pubKey);
```

### getWalletByMnemonic\(mnemonic\) ⇒ `Object` ⏏

create a wallet by mnemonic

**Kind**: Exported function  
**Returns**: `Object` - wallet

| Param | Type | Description |
| :--- | :--- | :--- |
| mnemonic | `string` | base on bip39 |

**Example**

```javascript
const mnemonicWallet = aelf.wallet.getWalletByMnemonic('hallo world');
```

### getWalletByPrivateKey\(privateKey\) ⇒ `Object` ⏏

create a wallet by private key

**Kind**: Exported function  
**Returns**: `Object` - wallet

| Param | Type | Description |
| :--- | :--- | :--- |
| privateKey | `string` | privateKey |

**Example**

```javascript
const privateKeyWallet = aelf.wallet.getWalletByPrivateKey('123');
```

### signTransaction\(rawTxn, keyPair\) ⇒ `Object` ⏏

sign a transaction

**Kind**: Exported function  
**Returns**: `Object` - wallet

| Param | Type | Description |
| :--- | :--- | :--- |
| rawTxn | `Object` | rawTxn |
| keyPair | `Object` | Any standard key pair |

**Example**

```javascript
const rawTxn = proto.getTransaction('ELF_65dDNxzcd35jESiidFXN5JV8Z7pCwaFnepuYQToNefSgqk9', 'ELF_65dDNxzcd35jESiidFXN5JV8Z7pCwaFnepuYQToNefSgqk9', 'test', []);
const signWallet = aelf.wallet.signTransaction(rawTxn, wallet.keyPair);
// signWallet = { 
//     Transaction: {
//    Sigs:
//     [ <Buffer af 61 1a fa 9c 94 8f 23 e7 f5 b5 03 dc ca 62 b1 94 05 e9 cc 28 ed 9b 6c af 1f 4f 1b 78 14 5e 52 72 35 81 ba b1 51 35 4c 63 c5 38 0a 1f b9 b9 ab d8 22 ... > ],
//     From:
//     Address {
//         Value: <Buffer e0 b4 0d dc 35 20 d0 b5 36 3b d9 77 50 14 d7 7e 4b 8f e8 32 94 6d 0e 38 25 73 1d 89 12 7b>
//     },
//     To:
//         Address {
//            Value: <Buffer e0 b4 0d dc 35 20 d0 b5 36 3b d9 77 50 14 d7 7e 4b 8f e8 32 94 6d 0e 38 25 73 1d 89 12 7b> 
//         },
//         MethodName: 'test',
//         Params: null,
//         R: null,
//         S: null,
//         P: null,
//         IncrementId: null,
//         Fee: null
//     }
//  }
```

### sign\(hexTxn, keyPair\) ⇒ `Buffer` ⏏

just sign

**Kind**: Exported function  
**Returns**: `Buffer` - Buffer.from\(hex, 'hex'\)

| Param | Type | Description |
| :--- | :--- | :--- |
| hexTxn | `string` | hex string |
| keyPair | `Object` | Any standard key pair |

**Example**

```javascript
const buffer = aelf.wallet.sign('68656c6c6f20776f726c64', wallet.keyPair);
// buffer = [65, 246, 49, 108, 122, 252, 66, 187, 240, 7, 14, 48, 89, 38, 103, 42, 58, 0, 46, 182, 180, 194, 200, 208, 141, 15, 95, 67, 234, 248, 31, 199, 73, 151, 2, 133, 233, 84, 180, 216, 116, 9, 153, 208, 254, 175, 96, 123, 76, 184, 224, 87, 69, 220, 172, 170, 239, 232, 188, 123, 168, 163, 244, 151, 1]
```


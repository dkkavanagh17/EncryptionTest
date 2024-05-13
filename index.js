//Imports
const readlineSync = require('readline-sync');


//Modules
const encryption = require('./encryption/encryption')
const encryptionExt = require('./encryption/encryptionExt')

let strKey = readlineSync.question('\x1b[34mkey>\x1b[0m').replace; process.stdout.write('\x1b[34m<\x1b[0m\n')
//var key = encryptionExt.parseKeys(strKey) //3:x453fg

while (true) {

}

/*let plainText = readlineSync.q
console.log("k:\n", keys)

var plainText = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters making it look like readable English."
var plainBatch = encryptionExt.parseBatch(plainText, "text")
console.log("p:\n", encryptionExt.batchData(plainBatch, "text"))

var cipherBatch = encryption.cipher(plainBatch, keys)
console.log("c:\n", cipherBatch)

var decodedBatch = encryption.cipher(cipherBatch, keys)
console.log("d:\n", decodedBatch)
    */
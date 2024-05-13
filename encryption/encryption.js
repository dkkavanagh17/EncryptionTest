//Exports
module.exports = { cipher }


function cipher(batch, keys) {

    //For Each Cycle
    for (let cycleNum = 0; cycleNum < keys.numCycles; cycleNum++) {

        var key = raiseKey(keys.xorKey, cycleNum + 2)
        var keystream = createKeystream(key, batch.length)

        for (let batchIdx = 0; batchIdx < batch.length; batchIdx++) {
            batch[batchIdx] = xor(batch[batchIdx], keystream[batchIdx])
        }
    }

    return batch
}

function xor(num, key) {
    return num ^ key
}

function createKeystream(key, length) {
    var keyStream = Array(length)

    for (let i = 0; i < length; i++) {
        keyStream[i] = key[i % key.length]
    }

    return keyStream
}

function raiseKey(key, num) {
    var raisedKey = Array(key.length)

    for (let i = 0; i < raisedKey.length; i++) {
        raisedKey[i] = (key[i] ** num) % 256
    }

    return raisedKey
}
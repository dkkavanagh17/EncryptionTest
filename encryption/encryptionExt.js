//Exports
module.exports = { parseBatch, batchData, parseKeys }


function parseBatch(text, mode) {
    if (mode == "text") {
        var batch = text.split("")

        for (let batchIdx = 0; batchIdx < batch.length; batchIdx++) {
            batch[batchIdx] = batch[batchIdx].charCodeAt(0)
        }

        return batch
    }
    else if (mode == "hex") {
        if ((text.length % 2) != 0) {
            text += "A"
        }

        batch = Array(text.length / 2)
        for (let i = 0; i < batch.length; i++) {
            batch[i] = parseInt(text[2 * i] + text[2 * i + 1], 16)
        }
    }
    else {
        return null
    }
}

function batchData(batch, mode) {
    var data = Array(batch.length)

    if (mode == "text") {
        for (let batchIdx = 0; batchIdx < batch.length; batchIdx++) {
            data[batchIdx] = String.fromCharCode(batch[batchIdx]);
        }
    }
    else if (mode == "hex") {
        for (let batchIdx = 0; batchIdx < batch.length; batchIdx++) {
            data[batchIdx] = batch[batchIdx].toString(16);
        }
    }
    else {
        return null
    }

    return data.join("")
}

function parseKeys(keys) {
    var parts = keys.split(":", 2)

    var numCycles = parseInt(parts[0])

    var xorKey = Array(parts[1].length)
    for (let i = 0; i < xorKey.length; i++) {
        xorKey[i] = parseInt(parts[1].charCodeAt(i))
    }

    return { numCycles: numCycles, xorKey: xorKey }
}
const allowedChars =
    "0123456789" +
    "abcdefghijklmnopqrstuvwxyz" +
    "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
    " " +
    "~`" +
    "!@#$%^&*()" +
    "_-+=" +
    "{}[]" +
    "|\\/" +
    "<>,.?;:" +
    "\"'"

//XOR CIPHER
//REMAP

//REPEAT FOR CYCLES

function cipher(plainText, key) {
    var cipherText = plainText

    for (let cycle = 1; 1 <= key.cycles; cycle++) {
        for (let i = 0; i < plainText.length; i++) {
            var plainChar = plainText[i]

            var plainChIdx = allowedChars.indexOf(plainChar)

            if (plainChIdx == -1) { cipherText += plainChar; continue; }//-1 represents not found



            var cipherChIdx = plainChIdx

            var cipherChar = allowedChars[cipherChIdx]

            cipherText += cipherChar
        }
    }

    return cipherText
}


//Exports
module.exports = { allowedChars, cipher }
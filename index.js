const encryption = require('./encryption')

var plainText =
    "A naive method of finding a modular inverse for A (mod C) is:" +
    "Calculate A * B mod C for B values 0 through C - 1." +
    "The modular inverse of A mod C is the B value that makes A * B mod C = 1. Note that the term B mod C can only have an integer value 0 through C - 1, so testing larger values for B is redundant."


var cyclesKey = 7
var xorKey = "AF7C9E24"
var remapKey = "LwS-Pr1QEe6y]lbH}\\)pzqZ'=2%<YD@9B~FCa30I+f(nc >i.?7_\"k#M/;8h[G^dW$jTvJsugmK&,Vx{U5|`4tRA!:oN*XO"
var key = { cycles: cyclesKey, xor: xorKey, remap: remapKey }

console.log(key)
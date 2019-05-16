const arr = [[11,2,4],[4,5,6],[10,8,-12]] // => 15
const arr2 = [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]] // => 0

function diagonalDifference(arr) {
    let length = arr.length // 3 
    let index = 0
    let number2 = length-1
    let number1 = 0
    let result = 0
    let result2 = 0
    while(index < length){
        result += arr[index][number1] // arr[0][0] arr[1][1] arr[2][2]
        result2 += arr[index][number2]// arr[0][2] arr[1][1] arr[2][0]
        index++
        number1++
        number2--
    }
    return Math.abs(result-result2)
}

console.log(diagonalDifference(arr))
console.log(diagonalDifference(arr2))

// start with number at the right
// divide by 1, then 2, then 3, then 4, then 5 ...
// store numbers, once it starts repeating, break the cycle, check the stored numbers squared added to see if it is a square
// push value pair to array

// result = []



function listSquared(m, n) {
    let obj = {}
    let result = []
    let num = n
    let indexNum = 1
for(let i = n; i <= Math.ceil(n/2); i++){

    if(n % indexNum === 0){
        console.log('Hello world')
        if(!obj[num]){
            obj[num] = indexNum
            result.push(num, indexNum)
        }
        indexNum += 1
        num = n/indexNum
    }
}
return obj
}

console.log(listSquared(1, 250))


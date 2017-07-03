/*jshint esversion: 6 */
(function () {
    String.prototype.ensureStart = function (str) {
        let resultStr = this.toString();
        if (resultStr.indexOf(str) != 0) {
            return str + resultStr;
        }
        return resultStr;
    };

    String.prototype.ensureEnd = function (str) {
        let resultStr = this.toString();
        if (resultStr.indexOf(str) != resultStr.length - str.length) {
            return resultStr + str;
        }
        return resultStr;
    };

    String.prototype.isEmpty = function () {
        return this.toString().length == 0;

    }
    String.prototype.truncate = function (n) {
        let initialString = this.toString();
        if(this.length <= n){
            return initialString;
        }
        if(initialString.length > n){
            let result ="";
            let splitString = initialString.split(" ");
            if(splitString !=initialString){
                result = splitString[0];
                for(let i = 1;i<splitString.length;i++){
                    if(result.length + splitString[i].length + 4 > n){
                        return result+"...";
                    }
                    result+=` ${splitString[i]}`;
                }
                return result;
            }
            if(n>=4){
                for(let i = 0; i < n - 3; i++){
                    result+= initialString[i];
                }
                result+="...";
                return result;
            }
            return Array(n+1).join(".");
        }
    }

    String.format = function (inputString) {
        let resultString = inputString;
        let placeholderPattern = /({\d+})/g;
        let match = placeholderPattern.exec(resultString);
        let index = 1;
        while(match){
            if(index < arguments.length){
                resultString = resultString.replace(match[1], arguments[index]);
            }

            index++;
            match = placeholderPattern.exec(resultString);
        }
        return resultString;
    }
})()

//
// let str = 'my string'
// str = str.ensureStart('my')
// console.log(str);
// str = str.ensureStart('hello ')
// console.log(str);
// str = str.truncate(16)
// console.log(str);
// str = str.truncate(14)
// console.log(str);
// str = str.truncate(8)
// console.log(str);
// str = str.truncate(4)
// console.log(str);
// str = str.truncate(2)
// console.log(str);
// str = String.format('The {0} {1} fox',
//     'quick', 'brown');
// console.log(str);
// str = String.format('jumps {0} {1}',
//     'dog');
// console.log(str);

/*jshint esversion: 6 */
function mathItUp() {
    let add = function (vec1, vec2) {
        let firstCoordinate = vec1[0] + vec2[0];
        let secondCoordinate = vec1[1] + vec2[1];
        return [firstCoordinate, secondCoordinate];
    };

    let multiply = function (vec1, scalar) {
        let firstCoordinate = vec1[0] * scalar;
        let secondCoordinate = vec1[1] * scalar;
        return [firstCoordinate, secondCoordinate];
    };

    let length = function (vec1) {
        let firstCoordinate = Math.sqrt((vec1[0] * vec1[0]) + (vec1[1] * vec[1]));

        return firstCoordinate
    };

    let dot = function (vec1, vec2) {
        let firstCoordinate = (vec1[0] * vec2[1]) + (vec1[1] * vec2[0]);
        return firstCoordinate;
    }
    return {
        add : add(),
        multiply : multiply(),
        length: length(),
        dot: dot()
    }
}
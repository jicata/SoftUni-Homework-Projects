/*jshint esversion: 6 */
function rectangleFactory(data) {
    "use strict";
    let rectangles = [];
    for (let i = 0; i < data.length; i++) {
        let width = data[i][0];
        let height = data[i][1];
        let rectangle = {
            width: width,
            height: height,
            area: () => rectangle.width * rectangle.height,
            compareTo: (other) => {
                if (rectangle.area() == other.area()) {
                    return other.width - rectangle.width;
                }
                return other.area() - rectangle.area();
            }
        };
        rectangles.push(rectangle);
    }
    rectangles.sort((a, b) => a.compareTo(b));
    return rectangles;
}
//console.log(rectangleFactory([[10, 5], [5, 12]]));
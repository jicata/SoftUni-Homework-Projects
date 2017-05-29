function CalcStuffOfCone(parameters) {
    var radius = Number(parameters[0]);
    var height = Number(parameters[1]);
    var volume = (1/3) *(Math.PI *(radius*radius) * height);
    var baseArea = Math.PI * (radius * radius);
    var lateralArea = (Math.PI * radius) * Math.sqrt((radius * radius) + (height * height));
    var area = baseArea + lateralArea;
    console.log("volume = " + volume);
    console.log("area= " + area);
}/**
 * Created by Maika on 17-Feb-17.
 */

CalcStuffOfCone([3,5])
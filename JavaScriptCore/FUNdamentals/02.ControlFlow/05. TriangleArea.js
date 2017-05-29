function CalcTriangleAreaHeron([num1, num2, num3]) {
    var a = Number(num1);
    var b = Number(num2);
    var c = Number(num3);

    var s  = (a+b+c) / 2;
    var area = Math.sqrt(s*(s-a)*(s-b)*(s-c));
    console.log(area);

}/**
 * Created by Maika on 17-Feb-17.
 */
CalcTriangleAreaHeron([2,3.5,4]);

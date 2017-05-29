function CalcAreaOfFigure(dimensions) {
    var w = Number(dimensions[0]);
    var h = Number(dimensions[1]);
    var W = Number(dimensions[2]);
    var H = Number(dimensions[3]);
    var areaOfInner = 0;
    var totalArea=0;
    if(H> h && W>w)
    {
         totalArea = W*H;
    }
    else if(H > h){
        areaOfInner = h*W;
        var areaOfLowerCases = w * h;
        var areaOfUpperCases = W*H;
        totalArea = (areaOfLowerCases + areaOfUpperCases) - areaOfInner;
    }

    else if(h> H){
        areaOfInner = w * H;
        var areaOfLowerCases = w * h;
        var areaOfUpperCases = W*H;
        totalArea = (areaOfLowerCases + areaOfUpperCases) - areaOfInner;
    }
    else if(h==H && w==W)
    {
        totalArea = w *h;
    }


    console.log(totalArea);
}
CalcAreaOfFigure(['1', '1', '2', '2']);
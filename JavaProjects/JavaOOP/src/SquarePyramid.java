import java.util.ArrayList;

/**
 * Created by Maika on 10/30/2015.
 */
public class SquarePyramid extends SpaceShape {
    private _ThreeDVertex baseCenter;
    private double baseWidth;
    private double pyramidHeight;
    private ArrayList<_ThreeDVertex> vertices;

    public SquarePyramid( _ThreeDVertex baseCenter, double baseWidth, double pyramidHeight) {
        super(baseCenter);
        this.baseCenter = super.getVertex();
        this.setBaseWidth(baseWidth);
        this.setPyramidHeight(pyramidHeight);
        this.vertices = super.getVertices();
    }

    public _ThreeDVertex getBaseCenter() {
        return baseCenter;
    }

    public void setBaseCenter(_ThreeDVertex baseCenter) {
        this.baseCenter = baseCenter;
    }

    public double getBaseWidth() {
        return baseWidth;
    }

    public void setBaseWidth(double baseWidth) {
        this.baseWidth = baseWidth;
    }

    public double getPyramidHeight() {
        return pyramidHeight;
    }

    public void setPyramidHeight(double pyramidHeight) {
        this.pyramidHeight = pyramidHeight;
    }

    public void setVerteces(ArrayList<_ThreeDVertex> vertices) {
        this.vertices = vertices;
    }

    @Override
    public double getArea() {
         //A=a^2+(2*a) * V(a^2/4) +h^2

        double area = Math.pow(this.baseWidth,2) + (2.0*this.baseWidth) * Math.sqrt((((baseWidth*baseWidth)/4.0) + pyramidHeight*pyramidHeight));
        return area;
    }

    @Override
    public double getVolume() {
        double volume = Math.pow(this.baseWidth,2) * this.pyramidHeight / 3;
        return volume;
    }
    @Override
    public String toString(){
        StringBuilder squarePyramid = new StringBuilder();
        squarePyramid.append(String.format("Square Pyrdamid: Width %.2f, Height %.2f. Area: %.2f; Volume: %.2f\n"
                ,this.getBaseWidth(), this.getPyramidHeight(), this.getArea(), this.getVolume()));
        squarePyramid.append("Coordinates: ");
        for (_ThreeDVertex vertex : this.vertices){
            squarePyramid.append(String.format("%.2f - %.2f - %.2f, ", vertex.getX(), vertex.getY(), vertex.getZ()));
        }
        squarePyramid.deleteCharAt(squarePyramid.length() - 2);
        return squarePyramid.toString();
    }
}

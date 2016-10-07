import java.util.ArrayList;

/**
 * Created by Maika on 10/30/2015.
 */
public class Rektangle extends PlaneShape {
    private _TwoDVertex pointA;
    private double width;
    private double height;
    private ArrayList<_TwoDVertex> vertices;



    public Rektangle(_TwoDVertex pointA, double width, double height) {
        super(pointA);
        this.pointA = super.getVertex();
        this.setHeight(height);
        this.setWidth(width);
        this.vertices = super.getVertices();
    }

    public void setVertices(ArrayList<_TwoDVertex> vertices) {
        this.vertices = vertices;
    }

    public _TwoDVertex getPointA() {
        return pointA;
    }

    public void setPointA(_TwoDVertex pointA) {
        this.pointA = pointA;
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }
    @Override
    public double getArea() {
        double area = this.getHeight() * this.getWidth();
        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = 2*(this.getWidth() + this.getHeight());
        return perimeter;
    }

    @Override
    public String toString(){
        StringBuilder rektangle = new StringBuilder();
        rektangle.append(String.format("Rektangle: Width %.2f, Height %.2f. Area: %.2f; Perimeter: %.2f\n"
                ,this.getWidth(), this.getHeight(), this.getArea(), this.getPerimeter()));
        rektangle.append("Coordinates: ");
        for (_TwoDVertex vertex : this.vertices){
            rektangle.append(String.format("%.2f - %.2f, ", vertex.getX(), vertex.getY()));
        }
        rektangle.deleteCharAt(rektangle.length() - 2);
        return rektangle.toString();
    }
}

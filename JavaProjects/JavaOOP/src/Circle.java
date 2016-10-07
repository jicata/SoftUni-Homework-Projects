import com.sun.javaws.exceptions.InvalidArgumentException;

import java.util.ArrayList;

/**
 * Created by Maika on 10/30/2015.
 */
public class Circle extends PlaneShape {
    private _TwoDVertex center;
    private double radius;

    private ArrayList<_TwoDVertex> vertices;

    public Circle(_TwoDVertex center, double radius) throws InvalidArgumentException{
        super(center);
        this.center = super.getVertex();
        this.setRadius(radius);
        this.vertices = super.getVertices();
    }


    public _TwoDVertex getCenter() {
        return center;
    }

    public void setCenter(_TwoDVertex center) {
        this.center = center;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) throws InvalidArgumentException {

        if (radius < 0) {
            String[] message = new String[]{"Radius cannot be negative."};
            throw new InvalidArgumentException(message);
        }

        this.radius = radius;
    }
    public void setVertices(ArrayList<_TwoDVertex> vertices) {
        this.vertices = vertices;
    }

    @Override
    public double getArea() {
        double area = Math.PI * Math.pow(this.radius, 2);
        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = 2*(Math.PI * this.radius);
        return perimeter;
    }
    @Override
    public String toString(){
        StringBuilder circle = new StringBuilder();
        circle.append(String.format("Circle: Radius %.2f .Area: %.2f; Perimeter: %.2f\n", this.radius, this.getArea(), this.getPerimeter()));
        circle.append("Coordinates: ");
        for (_TwoDVertex vertex : this.vertices){
            circle.append(String.format("%.2f - %.2f, ", vertex.getX(), vertex.getY()));
        }
        circle.deleteCharAt(circle.length() - 2);
        return circle.toString();
    }
}

import com.sun.javaws.exceptions.InvalidArgumentException;

import java.util.ArrayList;

/**
 * Created by Maika on 10/29/2015.
 */
public class Triangle extends PlaneShape {


    private _TwoDVertex pointA;
    private _TwoDVertex pointB;
    private _TwoDVertex pointC;
    private double sideA;
    private double sideB;
    private double sideC;
    private ArrayList<_TwoDVertex> vertices;

    public Triangle(_TwoDVertex pointA, _TwoDVertex pointB, _TwoDVertex pointC) throws InvalidArgumentException{
        super(pointA);

        this.pointA = super.getVertex();
        this.setPointB(pointB);
        this.setPointC(pointC);

        this.sideA = pointC.CalculateDistance(pointB);
        this.sideB = pointC.CalculateDistance(pointA);
        this.sideC = pointA.CalculateDistance(pointB);
        this.isTriangle();

        this.vertices = super.getVertices();
        this.vertices.add(pointB);
        this.vertices.add(pointC);

    }
    private void isTriangle() throws InvalidArgumentException{
        boolean isValidA = sideB + sideC > sideA;
        boolean isValidB = sideA + sideC > sideB;
        boolean isValidC = sideA + sideB > sideC;
        boolean isValidTriangle = isValidA && isValidB && isValidC;
        if(!isValidTriangle){
            String[] message = new String[]{"Invalid triangle points."};
            throw new InvalidArgumentException(message);
        }
    }

    public _TwoDVertex getPointA() {
        return pointA;
    }

    public void setPointA(_TwoDVertex pointA) {
        this.pointA = pointA;
    }

    public _TwoDVertex getPointB() {
        return pointB;
    }

    public void setPointB(_TwoDVertex pointB) {
        this.pointB = pointB;
    }

    public _TwoDVertex getPointC() {
        return pointC;
    }

    public void setPointC(_TwoDVertex pointC) {
        this.pointC = pointC;
    }

    @Override
    public double getPerimeter() {
        double perimiter = this.sideA + this.sideB + this.sideC;
        return perimiter;
    }

    @Override
    public double getArea() {

            double s = getPerimeter();
            double area = Math.sqrt(s*(s-this.sideA)*(s-this.sideB)*(s-this.sideC));

            return area;
    }

    @Override
    public String toString(){
        StringBuilder triangle = new StringBuilder();
        triangle.append(String.format("Triangle : A: %.2f, B: %.2f, C: %.2f. Area: %.2f; Perimeter: %.2f\n",
                this.sideA, this.sideB, this.sideC, getArea(), getPerimeter()));
        triangle.append("Coordinates: ");
        for (_TwoDVertex vertex : this.vertices){
            triangle.append(String.format("%.2f - %.2f, ", vertex.getX(), vertex.getY()));
        }
        triangle.deleteCharAt(triangle.length()-2);

        return triangle.toString();
    }
}

import com.sun.javaws.exceptions.InvalidArgumentException;

import java.util.ArrayList;

/**
 * Created by Maika on 10/30/2015.
 */
public class Sphere extends SpaceShape {
    private _ThreeDVertex center;
    private double radius;
    private ArrayList<_ThreeDVertex> vertices;

    public Sphere(_ThreeDVertex center, double radius) throws InvalidArgumentException {
        super(center);
        this.setCenter(super.getVertex());
        this.setRadius(radius);
        this.setVertices(super.getVertices());
        this.getVertices().add(center);
    }

    public _ThreeDVertex getCenter() {
        return center;
    }

    public void setCenter(_ThreeDVertex center) {
        this.center = center;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) throws InvalidArgumentException{
        if (radius < 0 ){
            String[] message = new String[]{"Radius cannot be less than zero!"};
            throw  new InvalidArgumentException(message);
        }
        this.radius = radius;
    }

    public void setVertices(ArrayList<_ThreeDVertex> vertices) {
        this.vertices = vertices;
    }

    @Override
    public double getArea() {
        double area = 4 * Math.PI * (this.getRadius() * this.getRadius());
        return area;
    }

    @Override
    public double getVolume() {
        double volume = 1.3*Math.PI * Math.pow(this.radius,3);
        return volume;
    }
    public String toString(){
        StringBuilder cuboid = new StringBuilder();
        cuboid.append(String.format("Cuboid: Radius %.2f. Area: %.2f; Volume %.2f\n",
                this.getRadius(), this.getArea(), this.getVolume()));
        cuboid.append("Coordinates: ");
        for (_ThreeDVertex vertex : this.vertices){
            cuboid.append(String.format("%.2f - %.2f - %.2f, ", vertex.getX(), vertex.getY(), vertex.getZ()));
        }
        cuboid.deleteCharAt(cuboid.length() - 2);
        return cuboid.toString();

    }
}

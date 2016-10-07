import java.util.ArrayList;

/**
 * Created by Maika on 10/30/2015.
 */
public class Cuboid extends SpaceShape {
    private _ThreeDVertex vertexche;



    private double height;
    private double width;
    private double depth;
    private ArrayList<_ThreeDVertex> vertices;

    public Cuboid(_ThreeDVertex vertexche, double height, double width, double depth) {
        super(vertexche);
        this.vertexche = super.getVertex();
        this.setHeight(height);
        this.setWidth(width);
        this.setDepth(depth);
        this.setVertices(super.getVertices());
        this.getVertices().add(vertexche);
    }

    public void setVertices(ArrayList<_ThreeDVertex> vertices) {
        this.vertices = vertices;
    }

    public _ThreeDVertex getVertexche() {
        return vertexche;
    }

    public void setVertexche(_ThreeDVertex vertexche) {
        this.vertexche = vertexche;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getDepth() {
        return depth;
    }

    public void setDepth(double depth) {
        this.depth = depth;
    }
    @Override
    public double getArea() {
        //2(lw+wh+hl)
        double area= 2*(this.height * this.width + this.width * this.depth + this.depth * this.height);
        return area;
    }

    @Override
    public double getVolume() {
        double volume = this.width * this.height * this.depth;
        return volume;
    }

    @Override
    public String toString(){
        StringBuilder cuboid = new StringBuilder();
        cuboid.append(String.format("Cuboid: Height %.2f, Width %.2f, Depth %.2f. Area: %.2f; Volume %.2f\n",
                this.getHeight(), this.getWidth(), this.getDepth(), this.getArea(), this.getVolume()));
        cuboid.append("Coordinates: ");
        for (_ThreeDVertex vertex : this.vertices){
            cuboid.append(String.format("%.2f - %.2f - %.2f, ", vertex.getX(), vertex.getY(), vertex.getZ()));
        }
        cuboid.deleteCharAt(cuboid.length() - 2);
        return cuboid.toString();

    }
}

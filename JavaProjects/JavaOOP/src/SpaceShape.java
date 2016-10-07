import java.util.ArrayList;

/**
 * Created by Maika on 10/30/2015.
 */
public abstract class SpaceShape extends Shape implements VolumeMeasureable, AreaMeasureable {
    private _ThreeDVertex vertex;
    private ArrayList<_ThreeDVertex> vertices;

    public SpaceShape(_ThreeDVertex vertex) {
        this.vertex = vertex;
        this.vertices = new ArrayList<_ThreeDVertex>() {{
            add(vertex);
        }};
    }

    public _ThreeDVertex getVertex() {
        return vertex;
    }
    public void setVertex(_ThreeDVertex vertex) {
        this.vertex = vertex;
    }
    public ArrayList<_ThreeDVertex> getVertices() {
        return vertices;
    }

}
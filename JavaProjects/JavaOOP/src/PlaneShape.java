import sun.security.provider.certpath.Vertex;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Maika on 10/29/2015.
 */
public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasureable {



    private _TwoDVertex vertex;
    private ArrayList<_TwoDVertex> vertices;

    public PlaneShape(_TwoDVertex vertex){
        this.setVertex(vertex);
        this.vertices = new ArrayList<_TwoDVertex>(){{
           add(vertex);
        }};
    }

    public _TwoDVertex getVertex() {
        return vertex;
    }
    public void setVertex(_TwoDVertex vertex) {
       this.vertex = vertex;
    }
    public ArrayList<_TwoDVertex> getVertices() {
        return vertices;
    }
}

/**
 * Created by Maika on 10/30/2015.
 */
public class _ThreeDVertex implements  IVertexx {
    private double x;
    private double y;
    private double z;






    public _ThreeDVertex(double x, double y, double z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double getX() {
        return x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    public void setY(double y) {
        this.y = y;
    }

    public double getZ() {
        return z;
    }

    public void setZ(double z) {
        this.z = z;
    }

    @Override
    public double CalculateDistance(IVertexx otherVertex) {
        double otherX = otherVertex.getX();
        double otherY = otherVertex.getY();

        double distance = Math.sqrt(((getX() - otherX) *(getX() - otherX)) + ((getY() - otherY) * (getY() - otherY)));
        return  distance;
    }
}

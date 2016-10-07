

/**
 * Created by Maika on 10/29/2015.
 */
public class _TwoDVertex implements IVertexx {
    private double x;
    private double y;

    public _TwoDVertex(double x, double y) {
        this.setX(x);
        this.setY(y);

    }


    public void setX(double x) {
        this.x = x;
    }

    public double getX() {
        return x;
    }

    public void setY(double y) {
        this.y = y;
    }

    public double getY() {
        return y;
    }


    public double CalculateDistance(IVertexx otherVertex) {
        double otherX = otherVertex.getX();
        double otherY = otherVertex.getY();

        double distance = Math.sqrt(((getX() - otherX) *(getX() - otherX)) + ((getY() - otherY) * (getY() - otherY)));
        return  distance;

    }


}

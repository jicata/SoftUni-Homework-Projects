import java.util.Scanner;

/**
 * Created by Maika on 10/14/2015.
 */
public class _02TriangleArea {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);

        String inputCoords = reader.nextLine();
        String[] specCoords = inputCoords.split(" ");
        int Ax = Integer.parseInt(specCoords[0]);
        int Ay = Integer.parseInt(specCoords[1]);

        inputCoords = reader.nextLine();
        specCoords = inputCoords.split(" ");
        int Bx = Integer.parseInt(specCoords[0]);
        int By = Integer.parseInt(specCoords[1]);

        inputCoords = reader.nextLine();
        specCoords = inputCoords.split(" ");
        int Cx = Integer.parseInt(specCoords[0]);
        int Cy = Integer.parseInt(specCoords[1]);
        if (IsATriangle(Ax,Ay,Bx,By,Cx,Cy) == 0){
            System.out.println("0");
        }
        else{
            System.out.println(IsATriangle(Ax,Ay,Bx,By,Cx,Cy));
        }
    }
    public static int IsATriangle(int Ax, int Ay, int Bx, int By, int Cx, int Cy){
        int area = Math.abs((Ax*(By-Cy) + Bx*(Cy-Ay) + Cx*(Ay -By)) / 2);
        return area;

    }

}

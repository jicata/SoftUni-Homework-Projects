import java.util.Scanner;

/**
 * Created by Maika on 10/14/2015.
 */
public class _01RectangleArea {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int a = reader.nextInt();
        int b = reader.nextInt();
        int areaOfRectangle = a*b;
        System.out.println(areaOfRectangle);
    }
}

/**
 * Created by Maika on 10/12/2015.
 */
import java.util.Scanner;
public class BezIntervali {
    public static void main(String[] args) {
        System.out.println("Hello Java");
        System.out.println("Tup li si");
        System.out.print("A? :");
        Scanner myInput = new Scanner(System.in);
        int a = 0;
        try
        {
                a = Integer.parseInt(myInput.next());
                System.out.println("Qvno si " + a + "% tup");
        }
        catch (Exception i)
        {
            System.out.println("em mai da");
        }
        System.out.println("Bravo");
       // int a = 5;



    }
}

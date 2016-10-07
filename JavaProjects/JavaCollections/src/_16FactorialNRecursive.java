import java.math.BigInteger;
import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _16FactorialNRecursive {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int n = Integer.parseInt(reader.nextLine());

        System.out.println(FactorialN(n));

    }
    public static int FactorialN(int n){
        int sum = 1;
        if (n > 1){
            return FactorialN(n-1) *n;

        }
        else{
            return 1;

        }




    }
}

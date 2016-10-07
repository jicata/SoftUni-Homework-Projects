import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _05DecToSys7 {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int decimalNumber = Integer.parseInt(reader.nextLine());
        String baseSevenWhat = Integer.toString(decimalNumber,7);
        System.out.println(baseSevenWhat);
    }
}

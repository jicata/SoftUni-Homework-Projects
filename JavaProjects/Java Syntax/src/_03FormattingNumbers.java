import java.util.Scanner;

/**
 * Created by Maika on 10/14/2015.
 */
public class _03FormattingNumbers {
    public static void main(String[] args) {

        Scanner reader = new Scanner(System.in);
        int a = reader.nextInt();
        float b = reader.nextFloat();
        float c = reader.nextFloat();

        String aHex = Integer.toHexString(a).toUpperCase();
        String aBin = Integer.toBinaryString(a);
        int aBinInt = Integer.parseInt(aBin);


        System.out.printf("|%-10s|%010d|%10.2f|%-10.3f|",aHex, aBinInt, b, c);
    }
}

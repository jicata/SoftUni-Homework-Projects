import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _06Sys7ToDec {
    public static void main(String[] args) {
        Scanner reader = new Scanner((System.in));
        String theSeven = reader.nextLine();
        int toDec = Integer.valueOf(theSeven, 7);
        System.out.println(toDec);

    }
}

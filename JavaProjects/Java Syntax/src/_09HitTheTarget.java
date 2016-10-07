import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _09HitTheTarget {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int theTarget = Integer.parseInt(reader.nextLine());
        Integer[] oneToTwenty = new Integer[20];
        for (int i = 1; i < 21 ; i++) {
            oneToTwenty[i-1] = i;
        }
        for (int i = 0; i <oneToTwenty.length ; i++) {
            for (int j = 0; j < oneToTwenty.length; j++) {
                if (oneToTwenty[i] + oneToTwenty[j] == theTarget){
                    System.out.printf("%d + %d = %d", oneToTwenty[i], oneToTwenty[j], theTarget);
                    System.out.println();
                }
                if (oneToTwenty[i]-oneToTwenty[j] == theTarget){
                    System.out.printf("%d - %d = %d",oneToTwenty[i], oneToTwenty[j], theTarget);
                    System.out.println();
                }
            }

        }
    }
}

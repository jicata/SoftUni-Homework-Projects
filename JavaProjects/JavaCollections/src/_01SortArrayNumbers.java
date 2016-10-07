import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

/**
 * Created by Maika on 10/23/2015.
 */
public class _01SortArrayNumbers {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int n = Integer.parseInt(reader.nextLine());
        int[] uuhArray = new int[n];
        String[] numbersForTheArray = reader.nextLine().split(" ");
        for (int i = 0; i < uuhArray.length ; i++) {
            uuhArray[i] = Integer.parseInt(numbersForTheArray[i]);
        }
        Arrays.sort(uuhArray);
        for (int i = 0; i < uuhArray.length ; i++) {
            System.out.print(uuhArray[i] + " ");
        }
       // System.out.println(uuhArray);

    }
}

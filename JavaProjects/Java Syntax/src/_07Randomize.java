import java.util.*;

/**
 * Created by Maika on 10/16/2015.
 */
public class _07Randomize {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int n = Integer.parseInt(reader.nextLine());
        int m = Integer.parseInt(reader.nextLine());

        if (n > m ) {
            Integer[] mehArray = new Integer[n-m+1];

            for (int i = 0; i < mehArray.length; i++, m++) {
                mehArray[i] = m;

            }
            Collections.shuffle(Arrays.asList(mehArray));
            for (int i = 0; i < mehArray.length ; i++) {
                System.out.println(mehArray[i]);
            }
        }
        else if (m > n){
            Integer[] mehArray = new Integer[m-n+1];

            for (int i = 0; i < mehArray.length; i++, n++) {
                mehArray[i] = n;

            }
            Collections.shuffle(Arrays.asList(mehArray));
            for (int i = 0; i < mehArray.length ; i++) {
                System.out.println(mehArray[i]);
            }


        }
        else{
           System.out.println(m);
        }

    }
}

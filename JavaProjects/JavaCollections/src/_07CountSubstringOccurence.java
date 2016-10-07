import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 10/24/2015.
 */
public class _07CountSubstringOccurence {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String whatTheUserSaid = reader.nextLine().toLowerCase();
        String theWord = reader.nextLine();
        int counter = 0;

        for (int i = 0; i < whatTheUserSaid.length() - theWord.length()+1 ; i++) {

            String substr = whatTheUserSaid.substring(i, i+ theWord.length());
            if(substr.equals(theWord)){
                counter++;
            }
        }
        System.out.println(counter);


    }
}

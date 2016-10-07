import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 10/16/2015.
 */
public class _11StartsAndEnds {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userInput = reader.nextLine();
        Pattern pattern = Pattern.compile("(?:(\\b[A-Z](?:\\w+)?[A-Z]))");

        Matcher findEm = pattern.matcher(userInput);

        while(findEm.find()){
            System.out.println(findEm.group(1) + " ");
        }
    }
}

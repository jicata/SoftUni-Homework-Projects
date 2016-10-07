import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 10/16/2015.
 */
public class _10ExtractWords {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String cryptedString = reader.nextLine();
        String pattern = "([a-zA-Z]{2,})";
        Pattern catchEm = Pattern.compile(pattern);

        Matcher gotIt = catchEm.matcher(cryptedString);

        while(gotIt.find()){

            System.out.print(gotIt.group(1)+ " ");
        }

    }
}

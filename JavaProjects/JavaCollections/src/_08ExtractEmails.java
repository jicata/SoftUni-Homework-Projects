import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 10/24/2015.
 */
public class _08ExtractEmails {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userProvidedText = reader.nextLine();
        Pattern emailMatcher = Pattern.compile("(\\b\\w+[.]*\\w*@\\w+\\.\\w+)");
        Matcher matcher = emailMatcher.matcher(userProvidedText);
        while (matcher.find()){
            System.out.println(matcher.group(1));
        }
    }
}

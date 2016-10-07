import java.util.Locale;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 10/14/2015.
 */
public class _WorkInClass {
    public static void main(String[] args) {
        String kurwaa = "kuwaaa";
        Pattern patty = Pattern.compile("\\w+");
        Matcher match = patty.matcher(kurwaa);

        while(match.find()){
            System.out.println(match.group());
        }
        Locale.setDefault(Locale.ROOT);
    }
}

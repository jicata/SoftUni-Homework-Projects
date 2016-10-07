import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/14/2015.
 */
public class _RandomTheNumbers {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String cryptedMessage = reader.nextLine();
        Pattern pattern = Pattern.compile("(\\d+)");
        Matcher matcher = pattern.matcher(cryptedMessage);
        List<Integer> numbers  = new ArrayList<>();
        while(matcher.find()){
            numbers.add(Integer.parseInt(matcher.group(1)));
        }
        List<String> hexNumbers = new ArrayList<>();
        for (int i = 0; i < numbers.size(); i++) {
            String kur = Integer.toHexString(numbers.get(i));
            String padded ="0000".substring(kur.length()) + kur.toUpperCase();
            hexNumbers.add(padded);
        }
        for (int i = 0; i < hexNumbers.size() ; i++) {
            if (i < hexNumbers.size() -1){
                System.out.print("0x" + hexNumbers.get(i) + "-");
            }
            else{
                System.out.print("0x"+hexNumbers.get(i));

            }
        }
    }
}

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/3/2015.
 */
public class _02WeirdScript {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int letter = Integer.parseInt(reader.nextLine());
        int kur = letter % 52;
        String theLetter = "";



        if(kur ==0 || kur > 26){
            theLetter = IntToLetters(letter-1).toUpperCase();

        }
        else{
            theLetter = IntToLetters(letter-1);
        }
        String userData = reader.nextLine();
        String letters = theLetter+theLetter;
        StringBuilder sb = new StringBuilder();
        while(!userData.equals("End")){
            sb.append(userData);
//            String letters = theLetter+theLetter;
//            Pattern pattern = Pattern.compile(letters+"(.+)"+letters);
//            Matcher matcher = pattern.matcher(userData);
//            while(matcher.find()){
//                System.out.println(matcher.group(1));
//            }

            userData = reader.nextLine();
        }
        int lastIndex = sb.lastIndexOf(letters);
       // System.out.println(sb);
        int nextOccurence = 0;
        int firstOccurence = 0;
        while(nextOccurence < lastIndex ){
            firstOccurence = sb.indexOf(letters,nextOccurence);
            nextOccurence = sb.indexOf(letters, firstOccurence+2);
            String leString = sb.substring(firstOccurence+2,nextOccurence);
            if(!leString.equals("")){
                System.out.println(leString);
            }

            nextOccurence+=2;
        }










    }
    public static String IntToLetters(int value)
    {
        String result = "";

            result = (char)('a' + value % 26 ) + result;
            value /= 26 ;

        return result;
    }
}

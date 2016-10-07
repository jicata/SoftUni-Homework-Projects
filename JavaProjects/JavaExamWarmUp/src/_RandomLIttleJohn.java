import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/11/2015.
 */
public class _RandomLIttleJohn {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        Pattern pattern = Pattern.compile("(>----->)|(>>----->)|(>>>----->>)");
        int large=0;
        int medium=0;
        int small=0;
        for (int i = 0; i < 4; i++) {

            String arrowStrings = reader.nextLine();
            Matcher matcher = pattern.matcher(arrowStrings);
            while(matcher.find()){
                if(matcher.group(1) != null){
                    small++;
                }
                if(matcher.group(2) !=null){
                    medium++;
                }
                if(matcher.group(3) !=null){
                    large++;
                }
            }
        }
        //System.out.println(large + "||" + medium + "||" + small);
        String arrowsConcat = String.valueOf(small)+String.valueOf(medium)+String.valueOf(large);
        int arrowShan = Integer.parseInt(arrowsConcat);
        String binaryArrows = Integer.toBinaryString(arrowShan);
        String binaryArrowsReversed = new StringBuilder(binaryArrows).reverse().toString();
        String finalBinArrows = binaryArrows+binaryArrowsReversed;
        int message = Integer.parseInt(finalBinArrows,2);
        System.out.println(message);



    }
}

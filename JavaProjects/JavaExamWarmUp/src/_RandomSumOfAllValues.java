import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.DoubleSummaryStatistics;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/12/2015.
 */
public class _RandomSumOfAllValues {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        Pattern keyPattern = Pattern.compile("^([a-zA-Z_]*?)(?=[0-9])(?:.)*?(?<=\\d)([a-zA-Z_]*?)$");
        String keyString = reader.nextLine();
        Matcher matcher = keyPattern.matcher(keyString);
        String startKey = "";
        String endKey = "";
        double sum = 0;
        if(matcher.find()){
            startKey = matcher.group(1);
            endKey = matcher.group(2);
        }
        String valueString = reader.nextLine();
        if (startKey.equals("") || endKey.equals("")){
            System.out.println("<p>A key is missing</p>");
            return;
        }
        else{
            Pattern valuePattern = Pattern.compile(startKey + "((?:\\.|[0-9]+\\.?)(?:[0-9])?[0-9]*?)"+ endKey);
            Matcher matcher1 = valuePattern.matcher(valueString);
            while(matcher1.find()){

                    if(Double.parseDouble(matcher1.group(1)) > 0){
                        sum += Double.parseDouble(matcher1.group(1));
                    }
                    else{
                        sum-=Double.parseDouble(matcher1.group(1));
                    }



            }

        }

        DecimalFormat df = new DecimalFormat("#.##");

        sum = Double.valueOf(df.format(sum));
        if(sum == 0){
            System.out.println("<p>The total value is: <em>nothing</em></p>");
        }
        else{
            System.out.printf("<p>The total value is: <em>" + df.format(sum) +"</em></p>" );
            System.out.println();
        }

    }
}




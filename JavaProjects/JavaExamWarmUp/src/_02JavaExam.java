import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/15/2015.
 */
public class _02JavaExam {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String rawData = reader.nextLine();
        int totalAlcohol = 0;
        while(!rawData.equals("OK KoftiShans")){
            Pattern pattern = Pattern.compile("(?:.)*?([A-Z][a-z]+)(?:.)*?([A-Z][a-zA-Z]*?[A-Z])(?:.)*?(\\d+)L");
            Matcher matcher = pattern.matcher(rawData);
            String guestName;
            String alcholName;
            int alchoholQuantity = 0;
            while(matcher.find()){
                guestName = matcher.group(1);
                alcholName = matcher.group(2).toLowerCase();
                alchoholQuantity = Integer.parseInt(matcher.group(3));
                totalAlcohol+=alchoholQuantity;
                System.out.println(guestName + " brought " + alchoholQuantity + " liters of " + alcholName+"!");
            }
            rawData=reader.nextLine();
        }
        double finalQuantity = totalAlcohol * 0.001;
        System.out.printf("%.3f softuni liters", finalQuantity);
       // System.out.println(finalQuantity+" softuni liters");
    }
}

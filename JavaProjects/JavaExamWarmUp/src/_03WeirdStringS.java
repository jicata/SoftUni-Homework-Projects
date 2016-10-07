import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/12/2015.
 */
public class _03WeirdStringS {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userString = reader.nextLine();
        userString = userString.replaceAll("\\\\", "");
        String noJunkString = userString.replaceAll("[/\\(\\)\\|\\s]", "");
        List<String> lasPalabras = new ArrayList<>();
        Pattern wordPattern = Pattern.compile("([a-zA-Z]+)");
        Matcher matcher = wordPattern.matcher(noJunkString);
       // System.out.println(noJunkString);
        while(matcher.find()){
            lasPalabras.add(matcher.group(1));
        }
        int biggestSum = Integer.MIN_VALUE;
        int positionOne = 0;
        int positionTwo = 0;
        for (int i = 0; i < lasPalabras.size() - 1; i++) {
            char[] firstWord = lasPalabras.get(i).toLowerCase().toCharArray();
            char[] secondWord = lasPalabras.get(i+1).toLowerCase().toCharArray();
            int currentSum = SumChars(firstWord) + SumChars(secondWord);
            if(currentSum >= biggestSum){
                biggestSum = currentSum;
                positionOne = i;
                positionTwo = i+1;
            }
        }
        System.out.println(lasPalabras.get(positionOne));
        System.out.println(lasPalabras.get(positionTwo));

    }
    public static int SumChars(char[] word){
        int sum = 0;
        for (int i = 0; i < word.length; i++) {
            int index = (int)word[i] % 32;
            sum+=index;
        }
        return sum;
    }
}

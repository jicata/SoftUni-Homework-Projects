import java.util.Scanner;

public class _02LettersChangeNumbersa {
    public static void main(String[] args) {
        //int index = (int)c % 32;
        Scanner reader = new Scanner(System.in);
        String rawData = reader.nextLine();
        String[] properData = rawData.replaceAll("\\s+", " ").split(" ");
        double sum = 0;
        double currentResult = 0;
        for (int i = 0; i < properData.length ; i++) {
            char firstLetter = properData[i].charAt(0);
            char lastLetter = properData[i].charAt(properData[i].length() -1);
            double leNumber = Integer.parseInt(properData[i].substring(1,properData[i].length()-1));
            if (Character.isUpperCase(firstLetter)){
                int index = (int)firstLetter % 32;
                currentResult+= leNumber / index;

            }
            else{
                int index = (int)firstLetter % 32;
                currentResult += leNumber*(double)index;

            }
            if(Character.isUpperCase(lastLetter)){
                int index = (int)lastLetter % 32;
                currentResult -= (double)index;
            }
            else{
                int index = (int)lastLetter % 32;
                currentResult+=(double)index;
            }
            sum+=currentResult;
            currentResult=0;

        }
        System.out.printf("%.2f", sum);
    }
}

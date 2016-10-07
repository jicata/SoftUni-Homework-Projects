import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/23/2015.
 */
public class _04LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] arrayOfStrings = reader.nextLine().split(" ");
        int[] themNumbers = new int[arrayOfStrings.length];
        for (int i = 0; i < arrayOfStrings.length; i++) {
            themNumbers[i] = Integer.parseInt(arrayOfStrings[i]);
        }
        List<Integer> sequences = new ArrayList<>();
        List<List<Integer>> longestSeq = new ArrayList<>();

        int lastIndex = Integer.MIN_VALUE;
        int maxSize = Integer.MIN_VALUE;
        for (int i = 0; i < themNumbers.length; i++) {
            int currentNumber = themNumbers[i];
            if (i > lastIndex) {
                sequences.add(currentNumber);
                if (i != themNumbers.length - 1) {
                    for (int j = Math.min(i + 1, themNumbers.length - 1); j < themNumbers.length; j++) {


                        if (currentNumber < themNumbers[j]) {
                            sequences.add(themNumbers[j]);
                            currentNumber = themNumbers[j];
                            lastIndex = j;
                        } else {

                            break;
                        }
                    }
                }
                if(sequences.size() > maxSize){
                    maxSize = sequences.size();
                    longestSeq.clear();
                    longestSeq.add(sequences);
                }

                System.out.println(sequences);
                sequences = new ArrayList<>();



            }
        }
        for(List<Integer> longestseq : longestSeq){
            System.out.println("Longest: " + longestseq);
        }
    }
}

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/23/2015.
 */
public class _03LargestSequenceOfEqualStrings {
    public static void main(String[] args) {


            Scanner reader = new Scanner(System.in);
            String[] arrayOfStrings = reader.nextLine().split(" ");
            List<String> sequences = new ArrayList<>();
            List<List<String>> longestSeq = new ArrayList<>();
            int maxSize = Integer.MIN_VALUE;

            String lastString = "";
            for (int i = 0; i < arrayOfStrings.length; i++) {
                String currentString = arrayOfStrings[i];
                if (!currentString.equals(lastString)) {
                    sequences.add(currentString);
                    if (i != arrayOfStrings.length - 1) {

                        for (int j = Math.min(i + 1, arrayOfStrings.length - 1); j < arrayOfStrings.length; j++) {
                            lastString = currentString;

                            if (currentString.equals(arrayOfStrings[j])) {
                                sequences.add(currentString);
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

                    sequences = new ArrayList<>();


                }


            }
        for(List<String> longestseq : longestSeq){
            System.out.println(longestseq);
        }
        }
    }


import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/23/2015.
 */
public class _02SequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] arrayOfStrings = reader.nextLine().split(" ");
        List<String> sequences = new ArrayList<>();
        int counter = 0;
        String lastString ="";
        for (int i = 0; i < arrayOfStrings.length ; i++) {
          String currentString = arrayOfStrings[i];
            if (!currentString.equals(lastString)){
                sequences.add(currentString);
                if(i!=arrayOfStrings.length-1){

                    for (int j = Math.min(i+1, arrayOfStrings.length - 1); j < arrayOfStrings.length ; j++) {
                        lastString = currentString;

                        if(currentString.equals(arrayOfStrings[j])){
                            sequences.add(currentString);
                        }
                        else{

                            break;
                        }
                    }
                }
                System.out.println(sequences);
                sequences.clear();



            }





        }
    }
}

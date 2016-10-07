import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _13GetFirstOddOrEven {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userInputArray = reader.nextLine();
        String[] userStringArray = userInputArray.split(" ");
        Integer[] collection = new Integer[userStringArray.length];
        for (int i = 0; i < userStringArray.length ; i++) {
            collection[i] = Integer.parseInt(userStringArray[i]);
        }
        String userInput = reader.nextLine();
        String[] instructions = userInput.split(" ");
        String oddOrEven = instructions[2];
        int numberOfElements = Integer.parseInt(instructions[1]);
        List<Integer> allTheRequiredNumbers = new ArrayList<Integer>();



        for (int i = 0; i < collection.length ; i++) {
            if (oddOrEven.equals("odd")){
                if(collection[i] % 2 !=0){
                    allTheRequiredNumbers.add(collection[i]);
                }
            }
            else if(oddOrEven.equals("even")){
                if(collection[i] % 2 == 0){
                    allTheRequiredNumbers.add(collection[i]);
                }
            }
        }
        if (numberOfElements > allTheRequiredNumbers.size()){
            for (int i = 0; i < allTheRequiredNumbers.size() ; i++) {
                System.out.print(allTheRequiredNumbers.get(i) + " ");
            }
        }
        if (numberOfElements < allTheRequiredNumbers.size() || numberOfElements == allTheRequiredNumbers.size()){
            for (int i = 0; i < numberOfElements ; i++) {
                System.out.print(allTheRequiredNumbers.get(i) + " ");
            }
        }

    }
}

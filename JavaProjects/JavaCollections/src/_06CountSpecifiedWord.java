import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/24/2015.
 */
public class _06CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userInput = reader.nextLine().toLowerCase();
        String[] splitItUp = userInput.trim().split("[^a-zA-Z0-9]");
        List<String> putItHere = new ArrayList<>();

        for (int i = 0; i <splitItUp.length ; i++) {
            if (!splitItUp[i].equals("")){
                putItHere.add(splitItUp[i]);
            }
        }
        String specificWord = reader.nextLine();
        int counter = 0;
        for (int i = 0; i <putItHere.size(); i++) {
            if (specificWord.equals(putItHere.get(i))){
                counter++;
            }
        }
        System.out.println(counter);
    }
}

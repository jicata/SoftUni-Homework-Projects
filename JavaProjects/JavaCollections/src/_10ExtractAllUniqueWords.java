import java.util.*;

/**
 * Created by Maika on 10/24/2015.
 */
public class _10ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] userText = reader.nextLine().toLowerCase().split("[^a-zA-Z0-9]");
        List<String> duplicate = new ArrayList<>();
        for (int i = 0; i < userText.length ; i++) {
            if (!userText[i].equals("")){
                duplicate.add(userText[i]);
            }
        }
        List<String> noDuplicateText = new ArrayList<>();

        for (int i = 0; i < duplicate.size(); i++) {
            String word = duplicate.get(i);

            if (!noDuplicateText.contains(word)){
                noDuplicateText.add(word);
            }
            else{
                continue;
            }
        }
        Collections.sort(noDuplicateText);
        System.out.println(noDuplicateText);
    }
}

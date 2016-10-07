import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/24/2015.
 */
public class _11MostFrequentWord {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] userText = reader.nextLine().toLowerCase().split("[^a-zA-Z0-9]");
        List<String> workableText = new ArrayList<>();
        for (int i = 0; i < userText.length ; i++) {
            if (!userText[i].equals("")){
                workableText.add(userText[i]);
            }
        }
        List<String> usedWords = new ArrayList<>();
        List<String> mostFrequentWords = new ArrayList<>();
        int counter = 0;
        int maxCounter = Integer.MIN_VALUE;
        for (int i = 0; i < workableText.size() ; i++) {
            String word = workableText.get(i);
            if(!usedWords.contains(word)){
                usedWords.add(word);
                for (int j = i; j < workableText.size() ; j++) {
                    if (workableText.get(j).equals(word)){
                        counter++;
                    }

                }
                if (counter > maxCounter){
                    maxCounter = counter;
                    mostFrequentWords.clear();
                    mostFrequentWords.add(word);
                }
                else if(counter == maxCounter){
                    mostFrequentWords.add(word);
                }
                counter=0;
            }
        }
        for (String word : mostFrequentWords){
            System.out.println(word + " -> " + maxCounter);
        }
    }
}

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/24/2015.
 */
public class _12CardsFrequencies {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] theCards = reader.nextLine().split(" ");
        List<String> usedCards = new ArrayList<>();

        int counter = 0;
        for (int i = 0; i < theCards.length ; i++) {
            String aCard = theCards[i];
            if(!usedCards.contains(aCard)){
                usedCards.add(aCard);
                for (int j = i; j < theCards.length ; j++) {
                    if (theCards[j].equals(aCard)){
                        counter++;
                    }
                }

                double frequency = (double)Math.round(100 * ((double)counter/(double)theCards.length));
                String uuh = "%";
                System.out.printf("%s -> %.2f%s", aCard, frequency, uuh);
                System.out.println();
                counter=0;

            }
        }
    }
}

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/24/2015.
 */
public class _09CombineListOfLetters {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] listOne = reader.nextLine().split(" ");
        String[] listTwo = reader.nextLine().split(" ");

        List<Character> l1 = new ArrayList<>();
        List<Character> l2 = new ArrayList<>();
        List<Character> l3Sorry = new ArrayList<>();
        for (int i = 0; i < listOne.length ; i++) {
            char c = listOne[i].charAt(0);
            l1.add(c);
            l3Sorry.add(c);
        }
        for (int i = 0; i < listTwo.length ; i++) {
            char c = listTwo[i].charAt(0);
            l2.add(c);
        }
        for (int i = 0; i < l2.size() ; i++) {
            char leChar = l2.get(i);
            if(!l1.contains(leChar)){
                l3Sorry.add(leChar);
            }
            else {
                continue;
            }
        }
        System.out.println(l3Sorry);

    }
}

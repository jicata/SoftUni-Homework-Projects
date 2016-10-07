import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by Maika on 10/26/2015.
 */
public class _13FilterArray {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] userWords = reader.nextLine().split(" ");
        List<String> penis = new ArrayList<>();
        for (int i = 0; i < userWords.length ; i++) {
            penis.add(userWords[i]);
        }

       penis = penis.stream().filter(s -> s.length() > 3).collect(Collectors.toList());
        System.out.println(penis);
    }
}

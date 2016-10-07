import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by Maika on 10/26/2015.
 */
public class _14SortedStream {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] nums = reader.nextLine().split(" ");
        List<Integer> numbers = new ArrayList<>();
        for (int i = 0; i < nums.length ; i++) {
            numbers.add(Integer.parseInt(nums[i]));

        }
        String order = reader.nextLine();
        if (order.equals("Ascending")){
            numbers = numbers.stream().sorted(Comparator.<Integer>naturalOrder()).collect(Collectors.toList());
            System.out.println(numbers);
        }
        else{
            numbers = numbers.stream().sorted(Comparator.<Integer>reverseOrder()).collect(Collectors.toList());
            System.out.println(numbers);
        }


    }
}

import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _15RecursiveBinarySearch {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int desiredNumber = Integer.parseInt(reader.nextLine());
        String[] rawArray = reader.nextLine().split(" ");
        int[] sortedIntArray = new int[rawArray.length];
        for (int i = 0; i < rawArray.length ; i++) {
            sortedIntArray[i] = Integer.parseInt(rawArray[i]);
        }
        System.out.println(binarySearch(sortedIntArray, 0, sortedIntArray.length - 1, desiredNumber));

    }
    public static int binarySearch(int[] a, int target) {
        return binarySearch(a, 0, a.length-1, target);
    }

    public static int binarySearch(int[] a, int start, int end, int target) {
        int middle = (start + end) / 2;
        if(end < start) {
            return -1;
        }

        if(target==a[middle]) {
            return middle;
        } else if(target<a[middle]) {
            return binarySearch(a, start, middle - 1, target);
        } else {
            return binarySearch(a, middle + 1, end, target);
        }
    }
}

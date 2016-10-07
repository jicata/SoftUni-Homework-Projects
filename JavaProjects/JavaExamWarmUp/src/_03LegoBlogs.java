
import java.util.*;

/**
 * Created by Maika on 10/30/2015.
 */
public class _03LegoBlogs {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int rows = Integer.parseInt(reader.nextLine());
        String[][] firstArray = new String[rows][];
        String[][] secondArray = new String[rows][];
        int totalLinesOfInput = 2 * rows;
        for (int i = 0; i <rows ; i++) {
            String rowsSpecified = reader.nextLine().trim();

                String[] specificRows = rowsSpecified.split("\\s+");
                firstArray[i] = new String[specificRows.length];
                for (int j = 0; j < specificRows.length ; j++) {
                    firstArray[i][j] = specificRows[j];
                }

        }

        for (int i = 0; i < rows ; i++) {
            String rowsSpecified = reader.nextLine().trim();
            String[] specificRows = rowsSpecified.split("\\s+");
            secondArray[i] = new String[specificRows.length];
            List<String> letsReverse = Arrays.asList(specificRows);
            Collections.reverse(letsReverse);
            for (int j = 0; j < letsReverse.size() ; j++) {
                secondArray[i][j] = letsReverse.get(j);
            }

        }
//        for (int i = 0; i < rows ; i++) {
//            for (int j = 0; j < firstArray[i].length ; j++) {
//                System.out.print(firstArray[i][j]);
//            }
//            System.out.println();
//
//        }
//        for (int i = 0; i < rows ; i++) {
//            for (int j = 0; j < secondArray[i].length ; j++) {
//                System.out.print(secondArray[i][j]);
//            }
//            System.out.println();
//
//        }
        int totalLenght = firstArray[0].length + secondArray[0].length;
        boolean sameLength = false;
        for (int i = 1; i < rows ; i++) {
            if (firstArray[i].length+secondArray[i].length == totalLenght){
                sameLength = true;
                continue;
            }
            else{
                sameLength = false;
                break;
            }

        }
        if (sameLength){
            for (int i = 0; i < rows ; i++) {
                ArrayList<String> both = new ArrayList(Arrays.asList(firstArray[i]));
                both.addAll(Arrays.asList(secondArray[i]));
                both.toArray();
                System.out.print("[");
                System.out.print(String.join(", ", both));
                System.out.print("]");
                System.out.println();
            }
        }
        else{
            int lenght = 0;
            for (int i = 0; i < rows ; i++) {
                lenght+= firstArray[i].length;
                lenght+=secondArray[i].length;

            }
            System.out.println("The total number of cells is: " + lenght);
        }
    }
}

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _02LargestRectangle {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userLine = reader.nextLine();
        List<String[]> theMatrix = new ArrayList<>();
        int cols = 0;
        while (!userLine.equals("END")) {
            String workAbleInput = userLine.replaceAll(",", " ").trim();
            String[] aRow = workAbleInput.split(" ");
            cols = aRow.length;
            theMatrix.add(aRow);
            userLine = reader.nextLine();
        }
        String[][] board = new String[theMatrix.size()][cols];
        for (int i = 0; i < theMatrix.size(); i++) {
            String[] s = theMatrix.get(i);
            for (int j = 0; j < s.length; j++) {
                board[i][j] = s[j];
            }
            ;

        }
        for (int i = 0; i < board.length; i++) {
            String[] s = board[i];
            for (int j = 0; j < s.length; j++) {
                System.out.print(board[i][j]);
            }
            System.out.println();
        }
    }
}

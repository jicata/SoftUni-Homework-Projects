import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/4/2015.
 */
public class _03DragonTrap {
    //private static ArrayList<int[]> positions;
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int rows = Integer.parseInt(reader.nextLine());
        char[][] board = new char[rows][];
        int cols = 0 ;
        List<int[]> positions = new ArrayList<>();
        String kur ="";
        char[][]fakeboard = new char[rows][];


        for (int i = 0; i < rows ; i++) {
            String boardData = reader.nextLine();
            cols = boardData.length();
            char[] gotIt = boardData.toCharArray();
            char[] duplicate  = boardData.toCharArray();
            board[i] = gotIt;
            fakeboard[i] = duplicate;
        }
        String userData = reader.nextLine();
        while(!userData.equals("End")){
            String properData = userData.replaceAll("[)(]+", "");
            String[] specificData = properData.split("\\s+");
            int row = Integer.parseInt(specificData[0]);
            int col = Integer.parseInt(specificData[1]);
            int radius = Integer.parseInt(specificData[2]);
            int rotations = Integer.parseInt(specificData[3]);

            int topBorder = row - radius;
            int botBorder = row + radius;
            int leftCol = col - radius;
            int rightCol = col + radius;

            String borders = GetBorders(board, topBorder, botBorder, leftCol, rightCol, positions);

            if(rotations!=0 && borders.length()>0){
                borders = RotateBorders(borders, rotations);
             for (int i = 0; i < positions.size() ; i++) {
                board[positions.get(i)[0]][positions.get(i)[1]] = borders.charAt(i);
//                 int currentRow = positions.get(i)[0];
//                 int currentCol = positions.get(i)[1];
//                 char kurche = kur.charAt(i);
//                 fakeboard[currentRow][currentCol] = kurche;
             }
            }
            positions = new ArrayList<>();


            userData = reader.nextLine();
        }

        int counter = 0;
        for (int i = 0; i < rows ; i++) {
            for (int j = 0; j < board[0].length; j++) {
                System.out.print(board[i][j]);
                if(board[i][j] != fakeboard[i][j]){
                    counter++;
                }
            }
            System.out.println();
        }
        System.out.println("Symbols changed: " + counter);





    }
    private static String GetBorders(char[][] board, int top, int bot, int left, int right, List<int[]> positions){
        StringBuilder borders = new StringBuilder();
        if (top>= 0 && top<board.length){
            int minCol = Math.max(left, 0);
            int maxCol = Math.min(right, board[0].length-1);
            for (int i = minCol; i <= maxCol ; i++) {
                borders.append(board[top][i]);
                positions.add(new int[]{top, i});

            }
            top++;

        }

        if(right >=0 && right < board[0].length){
            int minRow = Math.max(0,top);
            int maxRow = Math.min(bot, board.length-1);
            for (int i = minRow; i <= maxRow ; i++) {
                borders.append(board[i][right]);
                positions.add(new int[]{i, right});
            }
            right--;

        }
        if(bot >= 0 && bot < board.length){
            int minCol = Math.max(0,left);
            int maxCol = Math.min(board[0].length-1, right);
            for (int i = maxCol; i >= minCol ; i--) {
                borders.append(board[bot][i]);
                positions.add(new int[]{bot, i});
            }
            bot--;

        }
        if(left >= 0 && left < board[0].length){
            int minRow = Math.max(0, top);
            int maxRow = Math.min(board.length-1, bot);
            for (int i = maxRow; i >= minRow ; i--) {
                borders.append(board[i][left]);
                positions.add(new int[]{i, left});
            }
        }




        return  borders.toString();
    }
    private static String RotateBorders(String borders, int rotations) {
        // a b c f i h g d
        // b c f i h g d a

        String finalString = "";
        if (rotations < 0){
            int totalRotations = Math.abs(rotations) % borders.length();
            String endPart = borders.substring(0,totalRotations);
            String startPart = borders.substring(totalRotations);
            finalString = startPart + endPart;

        }
        else{
            int totalRotations = rotations % borders.length();
            String endPart = borders.substring(borders.length() - totalRotations);
            String startPart = borders.substring(0, borders.length()-totalRotations);
            finalString = endPart + startPart;
        }
        return finalString;

    }
}



import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 11/10/2015.
 */
public class _RandomXRemoval {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        List<String> storageRoom = new ArrayList<>();
        List<int[]> coordinates = new ArrayList<>();
        String userRawData = reader.nextLine();
        while(!userRawData.equals("END")){
            storageRoom.add(userRawData);
            userRawData = reader.nextLine();
        }
        char[][] board = new char[storageRoom.size()][];
        for (int i = 0; i < storageRoom.size() ; i++) {
            char[] kurhce = storageRoom.get(i).toCharArray();
            board[i] = kurhce;
        }
        for (int i = 0; i < board.length -2 ; i++) {
            for (int j = 0; j <Math.min(board[i].length - 2, board[i+1].length -1) ; j++) {
                if(xPossible(board, i,j)){
                    if(isX(board, i, j)){
                        coordinates.add(new int[]{i, j});
                    }

                }

            }
        }

        RemoveX(board, coordinates);
        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j <board[i].length ; j++) {
                if (board[i][j] != ' '){
                    System.out.print(board[i][j]);
                }
            }
            System.out.println();
        }


    }
    public static boolean xPossible(char[][] board, int currentRow, int currentCol){
        boolean isPossible =false;
        if(currentCol+2 < board[currentRow+2].length){
            isPossible = true;
        }
        return isPossible;

    }
    public static boolean isX(char[][] board, int currentRow, int currentCol){
        boolean isX = false;
        char topLeftChar = Character.toLowerCase(board[currentRow][currentCol]);
        char topRightChar = Character.toLowerCase(board[currentRow][currentCol+2]);
        char midChar = Character.toLowerCase(board[currentRow+1][currentCol+1]);
        char botLeftChar = Character.toLowerCase(board[currentRow+2][currentCol]);
        char botRightChar = Character.toLowerCase(board[currentRow+2][currentCol+2]);
        if(topLeftChar == topRightChar && topLeftChar == midChar  && topLeftChar == botLeftChar && topLeftChar == botRightChar){
            isX = true;
        }
        return isX;
    }
    public static void RemoveX(char[][] board, List<int[]> coordinates){
        for (int i = 0; i < coordinates.size() ; i++) {
            int currentRow =  coordinates.get(i)[0];
            int currentCol = coordinates.get(i)[1];
            board[currentRow][currentCol] = ' ';
            board[currentRow][currentCol +2]= ' ';
            board[currentRow+1][currentCol+1]= ' ';
            board[currentRow+2][currentCol] = ' ';
            board[currentRow+2][currentCol+2]= ' ';
        }
    }
}

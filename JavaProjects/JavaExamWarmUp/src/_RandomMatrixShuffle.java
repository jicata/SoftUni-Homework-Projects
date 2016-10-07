import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

/**
 * Created by Maika on 11/14/2015.
 */
public class _RandomMatrixShuffle {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int matrixSize = Integer.parseInt(reader.nextLine());
        char[][] board = new char[matrixSize][matrixSize];
        String initialString = reader.nextLine();
        FillTheMatrix(board, initialString);
        //PrintMatrix(board);
        String extractedString = WhiteSquared(board) + BlackSquared(board);
        String letsCompare = extractedString.replaceAll("[^a-zA-Z]", "").toLowerCase();
        //System.out.println(extractedString);
        StringBuilder reversedString = new StringBuilder(letsCompare.toLowerCase()).reverse();
//        System.out.println(letsCompare);
//        System.out.println(reversedString);
        if(letsCompare.equals(reversedString.toString())){

            System.out.println("<div style='background-color:#4FE000'>"+extractedString+"</div>");
        }
        else{
            System.out.println("<div style='background-color:#E0000F'>"+extractedString+"</div>");
        }
    }

    public static void FillTheMatrix(char[][] board, String leString){
        char[] betterString = leString.toCharArray();
        int topRow = 0;
        int botRow = board.length-1;
        int leftCol = 0;
        int rightCol = board.length - 1;
        int counter = 0;
        while(counter < betterString.length){
            //top row ->
            for (int i = leftCol; i <= rightCol; i++) {
                if(counter <betterString.length){
                    board[topRow][i] = betterString[counter];
                }
                else{
                    break;
                }
                counter++;
            }
            topRow++;
            //right col v
            for (int i = topRow; i <= botRow ; i++) {
                if (counter<betterString.length){
                    board[i][rightCol] = betterString[counter];
                }
                else{
                    break;
                }
                counter++;
            }
            rightCol--;
            //bot row <-
            for (int i = rightCol; i >= leftCol ; i--) {
                if (counter<betterString.length){
                    board[botRow][i] = betterString[counter];
                }
                else{
                    break;
                }
                counter++;
            }
            botRow--;
            //left col ^
            for (int i = botRow; i >= topRow ; i--) {
                if (counter<betterString.length){
                    board[i][leftCol] = betterString[counter];
                }
                else{
                    break;
                }
                counter++;
            }
            leftCol++;
        }

    }
    public static void PrintMatrix(char[][] board){
        for (int i = 0; i <board.length ; i++) {
            for (int j = 0; j <board[i].length ; j++) {
                System.out.print(board[i][j]);
            }
            System.out.println();
        }
    }
    public static String WhiteSquared(char[][] board){
        StringBuilder whiteString = new StringBuilder();
        for (int i = 0; i < board.length ; i++) {
            if(i == 0 || i %2 == 0){
                for (int j = 0; j < board[i].length; j+=2) {
                    whiteString.append(board[i][j]);
                }
            }
            else{
                for (int j = 1; j < board[i].length; j+=2) {
                    whiteString.append(board[i][j]);
                }
            }
        }
        return whiteString.toString();
    }
    public static String BlackSquared(char[][] board){
        StringBuilder blackString = new StringBuilder();
        for (int i = 0; i < board.length ; i++) {
            if(i == 0 || i %2 == 0){
                for (int j = 1; j < board[i].length; j+=2) {
                    blackString.append(board[i][j]);
                }
            }
            else{
                for (int j = 0; j < board[i].length; j+=2) {
                    blackString.append(board[i][j]);
                }
            }
        }
        return blackString.toString();
    }

}

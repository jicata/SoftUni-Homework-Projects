import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 11/8/2015.
 */
public class _RandomPlusRemove {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userString = reader.nextLine();
        List<String> rawStrings = new ArrayList<>();
        List<int[]> coordinates = new ArrayList<>();
        while(!userString.equals("END")){
            rawStrings.add(userString);
            userString = reader.nextLine();
        }
        char[][] matrix = new char[rawStrings.size()][];
        for (int i = 0; i < rawStrings.size(); i++) {
            char[] penis = rawStrings.get(i).toCharArray();
            matrix[i] = penis;
        }
        if(rawStrings.size() <= 2){
            for (int i = 0; i < matrix.length; i++) {
                for (int j = 0; j <matrix[i].length ; j++) {
                    System.out.print(matrix[i][j]);
                }
                System.out.println();
            }
        }
        else{
            for (int i = 0; i < matrix.length - 2 ; i++) {
                for (int j = 1; j < Math.min(matrix[i+1].length -1, matrix[i].length) ; j++) {
                    if(IsPlusPossible(matrix, i, j)){
                        if(IsLegitPlus(matrix, i, j)){
                            coordinates.add(new int[]{i, j});
                        }
                    }

                }

            }
            RemovePlus(matrix,coordinates);
            for (int i = 0; i < matrix.length; i++) {
                for (int j = 0; j <matrix[i].length ; j++) {
                    if(matrix[i][j] != ' '){
                        System.out.print(matrix[i][j]);
                    }
                }
                System.out.println();
            }
        }


    }
    public static boolean IsPlusPossible(char[][]matrix, int currentRow, int currentCol){
        boolean isPossible = false;
        if(matrix[currentRow+1].length > currentCol +1){
            if(matrix[currentRow+2].length > currentCol){
                isPossible= true;
            }
        }
        return isPossible;
    }
    public static boolean IsLegitPlus(char[][] matrix, int currentRow, int currentCol){

        boolean isPlus = false;
        char topChar = Character.toLowerCase(matrix[currentRow][currentCol]);
        char midrowLeft = Character.toLowerCase(matrix[currentRow+1][currentCol-1]);
        char midrowCentre = Character.toLowerCase(matrix[currentRow+1][currentCol]);
        char midrowRight = Character.toLowerCase(matrix[currentRow+1][currentCol+1]);
        char botChar = Character.toLowerCase(matrix[currentRow+2][currentCol]);
        if(topChar==midrowLeft && topChar == midrowCentre && topChar == midrowRight && topChar == botChar){
            isPlus = true;
        }
        return isPlus;
    }
    public static void RemovePlus(char[][] matrix, List<int[]> coordinates){
        for (int i = 0; i < coordinates.size() ; i++) {
            int topCharRow = coordinates.get(i)[0];
            int topCharCol = coordinates.get(i)[1];
            matrix[topCharRow][topCharCol] = ' ';
            for (int j = topCharCol - 1; j <= topCharCol +1; j++) {
                matrix[topCharRow+1][j] = ' ';
            }
            matrix[topCharRow+2][topCharCol] = ' ';
        }
    }
}

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 11/15/2015.
 */
public class _03JavaExam {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] dimensions = reader.nextLine().split(" ");
        int rows = Integer.parseInt(dimensions[0]);
        int cols = Integer.parseInt(dimensions[1]);
        int[][] matrix = new int[rows][cols];
        int counter = 1;
        for (int i = 0; i < rows ; i++) {
            for (int j = 0; j < cols ; j++) {
                matrix[i][j] = counter;
                counter++;
            }
        }
        int n = Integer.parseInt(reader.nextLine());
        for (int i = 0; i < n; i++) {
            String[] commands = reader.nextLine().split(" ");
            int index = Integer.parseInt(commands[0]);
            String direction = commands[1];
            int rotations = Integer.parseInt(commands[2]);
            if (direction.equals("left") || direction.equals("right")){
                if(direction.equals("left")){
                    RotateLeft(matrix, index, rotations);
                }
                else{
                    RotateRight(matrix, index, rotations);
                }
            }
            else{
                if(direction.equals("up")){
                    RotateUp(matrix, index, rotations);
                }
                else{
                    RotateDown(matrix, index, rotations);
                }

            }
        }
       // PrintMatrix(matrix);
        int countered= 1;
        for (int i = 0; i < rows ; i++) {
            for (int j = 0; j < cols ; j++) {
                if(matrix[i][j]!=countered){
                    int[] swapCoordinates = FindPosForSwap(matrix, i, j, countered);
                    System.out.printf("Swap (%d, %d) with (%d, %d)", i, j, swapCoordinates[0], swapCoordinates[1]);
                    System.out.println();
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[swapCoordinates[0]][swapCoordinates[1]];
                    matrix[swapCoordinates[0]][swapCoordinates[1]] = temp;

                }
                else{
                    System.out.println("No swap required");
                }
                countered++;
            }
        }

    }

    // 1 2 3
    // 4 5 6
    // 7 8 9
    // 0 right 2
    // 1 down 51
    // 2 left 451
    // 3 2 1
    // 4 5 6
    //

    public static void PrintMatrix(int[][] board){
        for (int i = 0; i <board.length ; i++) {
            for (int j = 0; j <board[i].length ; j++) {
                System.out.print(board[i][j]);
            }
            System.out.println();
        }
    }
    public static void RotateLeft(int[][] matrix, int row, int rotations){
        // 1 2 3 4

        List<Integer> allNumbers = new ArrayList<>();
        for (int i = 0; i < matrix.length ; i++) {
            allNumbers.add(matrix[row][i]);
        }
        int[] someNums = new int[allNumbers.size()];
        List<Integer> someMoreNumbers = new ArrayList<>();
        int numberOfRotations = rotations % allNumbers.size();
        for (int i = numberOfRotations; i < allNumbers.size() ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < numberOfRotations ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < matrix.length; i++) {
            matrix[row][i] = someMoreNumbers.get(i);
        }



    }
    public static void RotateRight(int[][] matrix, int row, int rotations){
        // 1 2 3 4


        List<Integer> allNumbers = new ArrayList<>();
        for (int i = 0; i < matrix.length ; i++) {
            allNumbers.add(matrix[row][i]);
        }
        int[] someNums = new int[allNumbers.size()];
        List<Integer> someMoreNumbers = new ArrayList<>();
        int numberOfRotations = rotations % allNumbers.size();
        for (int i = allNumbers.size() - numberOfRotations; i < allNumbers.size() ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < allNumbers.size()-numberOfRotations ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < matrix.length; i++) {
            matrix[row][i] = someMoreNumbers.get(i);
        }

    }
    public static void RotateUp(int[][] matrix, int col, int rotations){
        List<Integer> allNumbers = new ArrayList<>();

        for (int i = 0; i < matrix.length ; i++) {
           allNumbers.add(matrix[i][col]);
        }
        int numberOfRotations = rotations % allNumbers.size();
        List<Integer> someMoreNumbers = new ArrayList<>();

        for (int i = numberOfRotations; i < allNumbers.size() ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < numberOfRotations ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < matrix.length; i++) {
            matrix[i][col] = someMoreNumbers.get(i);
        }


    }
    public static void RotateDown(int[][] matrix, int col, int rotations){
        List<Integer> allNumbers = new ArrayList<>();

        for (int i = 0; i < matrix.length ; i++) {
            allNumbers.add(matrix[i][col]);
        }
        int numberOfRotations = rotations % allNumbers.size();
        List<Integer> someMoreNumbers = new ArrayList<>();

        for (int i = allNumbers.size() - numberOfRotations; i < allNumbers.size() ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < allNumbers.size()-numberOfRotations ; i++) {
            someMoreNumbers.add(allNumbers.get(i));
        }
        for (int i = 0; i < matrix.length; i++) {
            matrix[i][col] = someMoreNumbers.get(i);

        }

    }
    public static int[] FindPosForSwap(int[][] matrix, int currentRow, int currentCol, int numberToSwap){
        int[] coordinates = new int[2];
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j <matrix[i].length ; j++) {
                if(matrix[i][j] == numberToSwap){
                    coordinates[0] = i;
                    coordinates[1] = j;
                    return coordinates;
                }
            }
        }
        return coordinates;
    }
}

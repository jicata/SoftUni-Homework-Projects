import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 11/14/2015.
 */
public class _RandomParachute {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        List<String> rows = new ArrayList<>();
        String landscapeLines = reader.nextLine();
        while(!landscapeLines.equals("END")){
            rows.add(landscapeLines);
            landscapeLines = reader.nextLine();
        }
        char[][] landscape = new char[rows.size()][];
        for (int i = 0; i < rows.size() ; i++) {
            landscape[i] = rows.get(i).toCharArray();
        }
        //PrintMatrix(landscape);
        int playerRow=0;
        int playerCol=0;
        for (int i = 0; i < landscape.length ; i++) {
            for (int j = 0; j < landscape[i].length ; j++) {
                if(landscape[i][j] == 'o'){
                    playerRow = i;
                    playerCol = j;
                    break;
                }
            }
        }
        boolean isAlive = true;
        while(isAlive){
            playerRow ++;
            int rightWindPower=0;
            int leftWindPower =0;
            for (int i = 0; i <landscape[playerRow].length ; i++) {
                if(landscape[playerRow][i] == '>'){
                    rightWindPower++;
                }
                else if(landscape[playerRow][i] == '<'){
                    leftWindPower++;
                }
            }
            if(rightWindPower>leftWindPower){
                rightWindPower -=leftWindPower;
                playerCol+=rightWindPower;
            }
            else if(rightWindPower < leftWindPower){
                leftWindPower -=rightWindPower;
                playerCol-=leftWindPower;
            }
            char playrPos = landscape[playerRow][playerCol];
            if(playrPos == '/' || playrPos == '\\' || playrPos == '|'){
                isAlive = false;
                System.out.println("Got smacked on the rock like a dog!");
                System.out.println(playerRow + " " + playerCol);
                break;
            }
            else if(playrPos == '~'){
                isAlive = false;
                System.out.println("Drowned in the water like a cat!");
                System.out.println(playerRow + " " + playerCol);
                break;
            }
            else if(playrPos == '_'){
                isAlive = false;
                System.out.println("Landed on the ground like a boss!");
                System.out.println(playerRow + " " + playerCol);
                break;
            }


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
}

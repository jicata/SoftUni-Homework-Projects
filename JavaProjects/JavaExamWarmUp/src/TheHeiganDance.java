import java.util.Scanner;

/**
 * Created by Maika on 11/3/2015.
 */
public class TheHeiganDance {
    public static void main(String[] args) {
        double heigansHP = 3000000d;
        int playerHP = 18500;
        double playerDmg;
        boolean playerIsAlive = true;
        boolean heiganIsAlive = true;
        Scanner reader = new Scanner(System.in);
        char[][] playField = new char[15][15];
        playerDmg = Double.parseDouble(reader.nextLine());
        String rawInput = reader.nextLine();
        boolean plagueLives = false;
        int lastCloudRow = 0;
        int lastCloudCol = 0;
        int playerRow = 7;
        int playerCol = 7;
        String causeOfDeath = "";
        while(true){
            heigansHP-=playerDmg;
            if(plagueLives){
             playerHP-=3500;
                plagueLives= false;
                if(playerHP <= 0){
                    causeOfDeath = "Plague Cloud";
                    playerIsAlive = false;

                }
            }

            CleanMatrix(playField);
            if(playerIsAlive && heigansHP <= 0){
                System.out.println("Heigan: Defeated!");
                System.out.println("Player: " + playerHP);
                System.out.println("Final position: "+ playerRow + ", " + playerCol);
                break;
            }
            if(!playerIsAlive && heigansHP <= 0){
                System.out.println("Heigan: Defeated!");
                System.out.println("Player: Killed by " + causeOfDeath);
                System.out.println("Final position: "+ playerRow + ", " + playerCol);
                break;
            }
            if(!playerIsAlive && heigansHP > 0){
                System.out.printf("Heigan: %.2f\n", heigansHP);
                System.out.println("Player: Killed by " + causeOfDeath);
                System.out.println("Final position: " +playerRow +", " + playerCol);
                break;
            }


            String[] spellAndCooRdinates = rawInput.split(" ");
            String spellName = spellAndCooRdinates[0];
            int spellRow = Integer.parseInt(spellAndCooRdinates[1]);
            int spellCol = Integer.parseInt(spellAndCooRdinates[2]);
            if(spellName.equals("Cloud")){
                lastCloudRow = spellRow;
                lastCloudCol = spellCol;
                PlagueCloud(playField, spellRow, spellCol);
                if(playField[playerRow][playerCol] == 'P'){
                    boolean isSafe = false;
                    if(PlayerMovesUp(playField, playerRow, playerCol)){
                        playerRow -=1;
                        isSafe = true;
                    }
                    else if(!isSafe && PlayerMovesRight(playField, playerRow, playerCol)){
                        playerCol += 1;
                        isSafe =true;
                    }
                    else if(!isSafe && PlayerMovesDown(playField, playerRow, playerCol)){
                        playerRow+=1;
                        isSafe = true;
                    }
                    else if(!isSafe && PlayerMovesLeft(playField, playerRow, playerCol)){
                        playerCol -=1;
                        isSafe = true;
                    }
                    if (isSafe == false){
                        plagueLives = true;
                        playerHP -=3500;
                    }

                }


                if(playerHP <= 0){
                    causeOfDeath = "Plague Cloud";
                    playerIsAlive = false;

                }
                CleanMatrix(playField);

            }

            else{
                Eruption(playField, spellRow, spellCol);
                if(playField[playerRow][playerCol] == 'E'){
                    boolean isSafe = false;
                    if(PlayerMovesUp(playField, playerRow, playerCol)){
                        playerRow -=1;
                        isSafe = true;
                    }
                    else if(!isSafe && PlayerMovesRight(playField, playerRow, playerCol)){
                        playerCol += 1;
                        isSafe =true;
                    }
                    else if(!isSafe && PlayerMovesDown(playField, playerRow, playerCol)){
                        playerRow+=1;
                        isSafe = true;
                    }
                    else if(!isSafe && PlayerMovesLeft(playField, playerRow, playerCol)){
                        playerCol -=1;
                        isSafe = true;
                    }
                    if (!isSafe){
                        playerHP -=6000;
                    }

                }
                if(playerHP <= 0){

                    causeOfDeath = "Eruption";
                    playerIsAlive = false;


                }
                CleanMatrix(playField);
            }
            if(playerIsAlive){
                rawInput = reader.nextLine();
            }
            else{
                System.out.printf("Heigan: %.2f\n", heigansHP);
                System.out.println("Player: Killed by " + causeOfDeath);
                System.out.println("Final position: " +playerRow +", " + playerCol);
                break;
            }



        }



    }
    public static void PlagueCloud(char[][] board, int spellRow, int spellCol){
        int topRow = Math.max(spellRow-1,0);
        int botRow = Math.min(spellRow+1, 14);
        int leftCol = Math.max(spellCol-1, 0);
        int rightCol = Math.min(spellCol+1, 14);
        for (int i = topRow; i <= botRow ; i++) {
            for (int l = leftCol; l <= rightCol ; l++) {
                board[i][l] = 'P';
            }
        }
    }
    public static void Eruption(char[][] board, int spellRow, int spellCol){
        int topRow = Math.max(spellRow-1,0);
        int botRow = Math.min(spellRow+1, 14);
        int leftCol = Math.max(spellCol-1, 0);
        int rightCol = Math.min(spellCol+1, 14);
        for (int i = topRow; i <= botRow ; i++) {
            for (int l = leftCol; l <= rightCol ; l++) {
                board[i][l] = 'E';
            }
        }
    }
    public static void PrintMatrix(char[][] board){
        for (int i = 0; i < 15 ; i++) {
            for (int j = 0; j < 15 ; j++) {
                System.out.print(board[i][j]);
            }
            System.out.println();
        }
    }
    public static void CleanMatrix(char[][] board){
        for (int i = 0; i < 15 ; i++) {
            for (int j = 0; j < 15 ; j++) {
                board[i][j] = ' ';
            }

        }
    }
    public static void PlayerCollisionCheck(char[][] board, int playerRow, int playerCol, int playerHealth){
        boolean isSafe = true;
        boolean up = false;
        boolean right = false;
        boolean down = false;
        boolean left = false;

        while (board[playerRow][playerCol] == 'E' || board[playerRow][playerCol] == 'P'){
            isSafe = false;
            //MOVE UP
            if(playerRow - 1 < 0){
                isSafe = false;
            }
            else if(( board[playerRow-1][playerCol] == 'E' ||  board[playerRow-1][playerCol] == 'P')){
                isSafe = false;
            }
            else{
                isSafe = true;
                up = true;
                break;

            }
            //MOVE RIGHT
            if(!isSafe && playerCol + 1 > 15){
                isSafe = false;
            }
            else if(board[playerRow][playerCol+1] == 'E' || board[playerRow][playerCol+1] == 'P')
            {
                isSafe = false;
            }
            else{
                isSafe = true;
                right = true;
                break;
            }
            //MOVE DOWN
            if(!isSafe && playerRow + 1 > 15){
                isSafe = false;
            }
            else if(board[playerRow+1][playerCol] == 'E' || board[playerRow+1][playerCol] == 'P')
            {
                isSafe = false;
            }
            else{
                isSafe = true;
                down = true;
                break;
            }
            //MOVE LEFT
            if(!isSafe && playerCol - 1 < 0 ){
                isSafe = false;
            }
            else if(board[playerRow][playerCol-1] == 'E' || board[playerRow][playerCol-1] == 'P')
            {
                isSafe = false;
            }
            else{
                isSafe = true;
                left = true;
                break;
            }
            if (!isSafe){
                if (board[playerRow][playerCol] == 'E'){
                    playerHealth -= 6000;
                    break;
                }
                else{
                    playerHealth -=3500;
                    break;
                }

            }

        }
        if (isSafe){
            if (up){
                playerRow -=1;
            }
            else if(right){
                playerCol +=1;
            }
            else if(down){
                playerRow+=1;
            }
            else {
                playerCol -=1;
            }
        }





    }
    public static boolean PlayerMovesUp(char[][] board, int playerRow, int playerCol){
        boolean isSafe = false;
        if(playerRow - 1 < 0){
            return isSafe;
        }
        else if(( board[playerRow-1][playerCol] == 'E' ||  board[playerRow-1][playerCol] == 'P')){
            return isSafe;
        }
        else{
            isSafe = true;

        }
        return isSafe;
    }
    public static boolean PlayerMovesRight(char[][] board, int playerRow, int playerCol){
        boolean isSafe = false;
        if(!isSafe && playerCol + 1 > 14){
            isSafe = false;
        }
        else if(board[playerRow][playerCol+1] == 'E' || board[playerRow][playerCol+1] == 'P')
        {
            isSafe = false;
        }
        else{
            isSafe = true;

        }
        return isSafe;
    }
    public static boolean PlayerMovesDown(char[][] board, int playerRow, int playerCol){
        boolean isSafe = false;
        if(!isSafe && playerRow + 1 > 14){
            return isSafe;
        }
        else if(board[playerRow+1][playerCol] == 'E' || board[playerRow+1][playerCol] == 'P')
        {
            return isSafe;
        }
        else{
            isSafe = true;

        }
        return isSafe;
    }
    public static boolean PlayerMovesLeft(char[][] board, int playerRow, int playerCol){
        boolean isSafe = false;
        if(!isSafe && playerCol - 1 < 0){
            return isSafe;
        }
        else if(board[playerRow][playerCol-1] == 'E' || board[playerRow][playerCol-1] == 'P')
        {
            return isSafe;
        }
        else{
            isSafe = true;

        }
        return isSafe;
    }
}

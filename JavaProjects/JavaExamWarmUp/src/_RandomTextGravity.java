import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 11/10/2015.
 */
public class _RandomTextGravity {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int lineLenght = Integer.parseInt(reader.nextLine());
        String userInput = reader.nextLine();
        char[] properInput = userInput.toCharArray();
        List<char[]> middleStage = new ArrayList<>();
        int counter = 0;
        int listCounter = 0;
        while(counter < properInput.length){
            middleStage.add(new char[lineLenght]);
            for (int i = 0; i < lineLenght ; i++) {
                if(counter < properInput.length){
                    middleStage.get(listCounter)[i] = properInput[counter];
                }
                else{
                    middleStage.get(listCounter)[i] = ' ';
                }

                counter++;
            }
            listCounter ++;
        }
        char[][] properArrayBro = new char[middleStage.size()][];
        for (int i = 0; i < middleStage.size() ; i++) {
            properArrayBro[i] = middleStage.get(i);
        }
        //PrintMatrix(properArrayBro);
        if(properArrayBro.length > 1){
            GravityRules(properArrayBro);
        }
       // System.out.println();
        //PrintMatrix(properArrayBro);

        PrintHTMLTableMatrix(properArrayBro);



    }
    public static void GravityRules(char[][] charArray){
        for (int row = charArray.length-1; row > 0 ; row--) {
            for (int col = 0; col < charArray[row].length ; col++) {
                if(charArray[row][col] == ' '){
                    if(charArray[row-1][col] !=' '){
                        charArray[row][col] = charArray[row-1][col];
                        charArray[row-1][col] = ' ';
                    }
                    else{
                        int currentRow = row -1;
                        while(charArray[currentRow][col] !=' ' || currentRow > 0){

                            if(charArray[currentRow][col]!=' '){
                                charArray[row][col] = charArray[currentRow][col];
                                charArray[currentRow][col] = ' ';
                                break;
                            }
                            currentRow--;
                        }
                    }
                }
            }
        }
    }
    public static void PrintMatrix(char[][] deYumSon){
        for (int i = 0; i < deYumSon.length ; i++) {
            for (int j = 0; j < deYumSon[i].length; j++) {
                System.out.print(deYumSon[i][j]);
            }
            System.out.println();
        }
    }
    public static void PrintHTMLTableMatrix(char[][] bruh){
        System.out.print("<table>");
        for (int i = 0; i < bruh.length ; i++) {
            System.out.print("<tr>");
            for (int j = 0; j < bruh[i].length; j++) {
                System.out.print("<td>"+bruh[i][j]+"</td>");

            }
            System.out.print("</tr>");
//            if(i < bruh.length-1){
//                System.out.println();
//            }


        }
        System.out.print("</table>");
    }
}

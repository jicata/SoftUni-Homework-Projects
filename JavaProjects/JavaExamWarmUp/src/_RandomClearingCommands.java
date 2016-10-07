import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 11/11/2015.
 */
public class _RandomClearingCommands {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userData = reader.nextLine();
        List<String> youngStrings = new ArrayList<>();
        while(!userData.equals("END")){
            youngStrings.add(userData);
            userData = reader.nextLine();
        }
        char[][] adolescentStrings = new char[youngStrings.size()][];
        for (int i = 0; i < youngStrings.size() ; i++) {
            adolescentStrings[i] = youngStrings.get(i).toCharArray();
        }
        //PrintMatrix(adolescentStrings);
        for (int i = 0; i < adolescentStrings.length ; i++) {
            for (int j = 0; j <adolescentStrings[0].length ; j++) {
                char currentChar = adolescentStrings[i][j];
                if(currentChar == 'v'){
                    MoveDown(adolescentStrings, i,j);

                }
                else if(currentChar == '^'){
                    MoveUp(adolescentStrings, i,j);

                }
                else if(currentChar == '>'){
                    MoveRight(adolescentStrings, i,j);

                }
                else if(currentChar == '<'){
                    MoveLeft(adolescentStrings, i,j);

                }
            }
        }
        //PrintMatrix(adolescentStrings);
        for (int i = 0; i <adolescentStrings.length ; i++) {
            StringBuilder sb = new StringBuilder();
            System.out.print("<p>");
            for (int j = 0; j <adolescentStrings[i].length ; j++) {

                sb.append(adolescentStrings[i][j]);
            }
            String printMe = HTMLEscapism(sb.toString());
            System.out.print(printMe);
            System.out.print("</p>");
            System.out.println();
        }
    }
    public static String HTMLEscapism(String nonEscaped){
        StringBuilder escapedXML = new StringBuilder();
        for (int i = 0; i < nonEscaped.length(); i++) {
            char c = nonEscaped.charAt(i);
            switch (c) {
                case '<':
                    escapedXML.append("&lt;");
                    break;
                case '>':
                    escapedXML.append("&gt;");
                    break;
                case '\"':
                    escapedXML.append("&quot;");
                    break;
                case '&':
                    escapedXML.append("&amp;");
                    break;
                case '\'':
                    escapedXML.append("&apos;");
                    break;
                default:
                    if (c > 0x7e) {
                        escapedXML.append("&#" + ((int) c) + ";");
                    } else
                        escapedXML.append(c);
            }
        }
        return escapedXML.toString();
    }
    public static void PrintMatrix(char[][] lala){
        for (int i = 0; i < lala.length ; i++) {
            for (int j = 0; j <lala[0].length ; j++) {
                System.out.print(lala[i][j]);
            }
            System.out.println();
        }
    }
    public static void MoveDown(char[][] leArray, int row, int col){
        for (int i = row; i < leArray.length -1 ; i++) {
            if (leArray[i+1][col] != '<' && leArray[i+1][col] != '>' && leArray[i+1][col] != 'v' && leArray[i+1][col] != '^' ){
                leArray[i+1][col] = ' ';
            }
            else{
                break;
            }
        }
    }
    public static void MoveRight(char[][] leArray, int row, int col){
        for (int i = col; i < leArray[row].length - 1 ; i++) {
            if (leArray[row][i+1] != '<' && leArray[row][i+1] != '>' && leArray[row][i+1] != 'v' && leArray[row][i+1] != '^' ){
                leArray[row][i+1] = ' ';
            }
            else{
                break;
            }
        }
    }
    public static void MoveUp(char[][] leArray, int row, int col){
        for (int i = row; i > 0 ; i--) {
            if (leArray[i-1][col] != '<' && leArray[i-1][col] != '>' && leArray[i-1][col] != 'v' && leArray[i-1][col] != '^' ){
                leArray[i-1][col] = ' ';
            }
            else{
                break;
            }
        }
    }
    public static void MoveLeft(char[][] leArray, int row, int col){
        for (int i = col; i > 0 ; i--) {
            if (leArray[row][i-1] != '<' && leArray[row][i-1] != '>' && leArray[row][i-1] != 'v' && leArray[row][i-1] != '^' ){
                leArray[row][i-1] = ' ';
            }
            else{
                break;
            }
        }
    }

}

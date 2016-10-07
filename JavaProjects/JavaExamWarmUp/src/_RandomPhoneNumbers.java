import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/11/2015.
 */
public class _RandomPhoneNumbers {
    public static void main(String[] args) {
        Scanner reader= new Scanner(System.in);
        Pattern pattern = Pattern.compile("([A-Z](?:[a-zA-Z]*)?)[^a-zA-Z\\+]*?(?=\\+|\\d{2,})(\\+?\\d{1,}[\\d\\(\\)\\/\\.\\-\\s]*\\d)");
        StringBuilder peonPeon = new StringBuilder();
        String userData = reader.nextLine();
        List<String[]> nameAndPhone = new ArrayList<>();
        boolean numbersPresent = false;
        while(!userData.equals("END")){
            peonPeon.append(userData);
            userData = reader.nextLine();
        }
        Matcher matcher = pattern.matcher(peonPeon);
        while(matcher.find()){
            numbersPresent = true;
            String phonec= matcher.group(2).replaceAll("[\\)\\(\\-\\.\\/\\s]","");
            nameAndPhone.add(new String[]{matcher.group(1), phonec});

        }
        if(numbersPresent){
            System.out.print("<ol>");
            for (int i = 0; i <nameAndPhone.size(); i++) {
                String name = nameAndPhone.get(i)[0];
                String phone = nameAndPhone.get(i)[1];
                System.out.printf("<li><b>%s:</b> %s</li>", name, phone);
//
            }
            System.out.print("</ol>");

        }
        else{
            System.out.println("<p>No matches!</p>");
        }

    }
}

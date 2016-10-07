import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/11/2015.
 */
public class _RandomUppercaseWords {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        List<String> userStrings = new ArrayList<>();
        String rawData = reader.nextLine();
        while(!rawData.equals("END")){
            StringBuilder sb = new StringBuilder(rawData);
            Pattern pattern = Pattern.compile("([a-zA-Z]*)");
            Matcher matcher = pattern.matcher(rawData);
            int lastIndex = 0;
            while(matcher.find()){
                String currentString = matcher.group(1);
                int startIndex =sb.indexOf(currentString, lastIndex);
                lastIndex = startIndex+1;

                if(AllCapitals(currentString)){
                    String reversed  = Reverse(currentString);
                    sb.replace(startIndex, startIndex +currentString.length(),"");
                    sb.insert(startIndex, reversed);

                }
//                String baasi = "T";
//                int arr = kur.indexOf("T");
//                kur.replace(arr,arr+baasi.length(),"");
//                kur.insert(arr,"fuckfuck");
//                System.out.println(kur);

            }

            System.out.println(HTMLEscapism(sb.toString()));

            userStrings.add(rawData);
            rawData = reader.nextLine();
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
    public static boolean AllCapitals(String checkUp){
        boolean allUpper = false;
        for (int i = 0; i < checkUp.length(); i++) {
            if(Character.isUpperCase(checkUp.charAt(i))){
                allUpper = true;
            }
            else{
                allUpper = false;
                break;
            }
        }
        return allUpper;
    }
    public static String Reverse(String allCapital){
        String oldString = allCapital;
        StringBuilder newString = new StringBuilder();
        for (int i = allCapital.length() - 1; i >= 0 ; i--) {
            newString.append(allCapital.charAt(i));
        }
        if(newString.toString().equals(oldString)){
            StringBuilder finalString = new StringBuilder();
            for (int i = 0; i < newString.length() ; i++) {
                finalString.append(newString.charAt(i));
                finalString.append(newString.charAt(i));
            }
            return finalString.toString();
        }
        else {
            return newString.toString();
        }

    }
}

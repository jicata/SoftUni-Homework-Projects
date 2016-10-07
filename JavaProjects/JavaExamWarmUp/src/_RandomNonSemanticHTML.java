import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/9/2015.
 */
public class _RandomNonSemanticHTML {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String rawUserInput = reader.nextLine();
        String properTag = "";
        String propa = "";
        while(!rawUserInput.equals("END")){
            //if(rawUserInput.contains("<div")){

//            String[] properSplitData = rawUserInput.split(" ");
//            for (int i = 0; i <properSplitData.length ; i++) {
//                if(properSplitData[i].contains("id") || properSplitData[i].contains("class")){
//                    int firstInd = properSplitData[i].indexOf('"');
//                    int lastInd = properSplitData[i].lastIndexOf('"');
//                    properTag = "<" + properSplitData[i].substring(firstInd+1,lastInd);
//                    properSplitData[i] = "";
//                }
//                properSplitData[0] = properTag;
//             }
//            }
            Pattern closingBracket = Pattern.compile("((?:\\s+)?>)");
            Matcher closingBracketMatcher = closingBracket.matcher(rawUserInput);
            Pattern patternClose = Pattern.compile("(<\\/div>(?:\\s*)?<!--(?:\\s*)?(\\w+)(?:\\s*)?-->)");
            Matcher matcherClose = patternClose.matcher(rawUserInput);
            Pattern patternOpen = Pattern.compile("<(div)(?:.)*(\\s(?:id|class)(?:\\s*)?=(?:\\s*)?\"(\\w+)\")");
            Matcher matcherOpen = patternOpen.matcher(rawUserInput);
            int whiteSpaceCount = rawUserInput.indexOf('<');
            if(matcherOpen.find()){
                String forLater = rawUserInput.substring(0, whiteSpaceCount);
                String workable = rawUserInput.substring(whiteSpaceCount);
                propa = workable.replaceAll(matcherOpen.group(1), matcherOpen.group(3));
                propa = propa.replaceAll(matcherOpen.group(2), "");
                propa = propa.replaceAll("\\s+", " ");

                if(closingBracketMatcher.find()){
                    propa = propa.replaceAll(closingBracketMatcher.group(1), ">");
                }

                System.out.println(forLater+propa);
            }
            else if(matcherClose.find()){
                propa = rawUserInput.replaceAll(matcherClose.group(1),"</" + matcherClose.group(2) + ">");


                if(closingBracketMatcher.find()){
                    propa = propa.replaceAll(closingBracketMatcher.group(1), ">");
                }
                System.out.println(propa);
            }
            else{
                System.out.println(rawUserInput);
            }




            rawUserInput= reader.nextLine();
        }
    }
}

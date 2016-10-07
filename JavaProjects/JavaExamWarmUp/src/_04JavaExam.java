import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/15/2015.
 */
public class _04JavaExam {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userInput = reader.nextLine();
        Pattern pattern = Pattern.compile("\\{\"Project\": (?:\\[\"(.*?)\"\\]), \"Type\": (?:\\[\"(.*?)\"\\]), \"Message\": (?:\\[\"(.*?)\"\\])}");
        TreeMap<String, List<Error>> logs = new TreeMap<>();
        String projectName = "";
        String errorType = "";
        String errorMessage = "";

        while(!userInput.equals("END")){
            Matcher matcher = pattern.matcher(userInput);


            if(matcher.find()){
                projectName = matcher.group(1);
                errorType = matcher.group(2);
                errorMessage = matcher.group(3);
            }
            if(!logs.containsKey(projectName)){
                logs.put(projectName, new ArrayList<>());
                logs.get(projectName).add(new Error(errorType, errorMessage));
            }
            else{
                logs.get(projectName).add(new Error(errorType, errorMessage));
            }

            userInput = reader.nextLine();
        }
        TreeMap<String, List<Error>> sorted = SortByValue(logs);
        for (Map.Entry<String, List<Error>> outerPair : sorted.entrySet()){
            String key = outerPair.getKey();
            List<Error> errorList = outerPair.getValue();
            System.out.println(key+":");
            System.out.println("Total Errors: "+errorList.size());
            int criticalCount = 0;
            int warningCount = 0;
            for (Error error : errorList){
                if(error.type.equals("Critical")){
                    criticalCount++;
                }
                else if(error.type.equals("Warning")){
                    warningCount++;
                }
            }
            System.out.println("Critical: " + criticalCount);
            System.out.println("Warnings: "+ warningCount);

            System.out.println("Critical Messages:");
            if(criticalCount == 0){
                System.out.println("--->None");
            }
            else{
                List<String> sortedMessaged = new ArrayList<>();
                for (Error error : errorList){
                    if(error.type.equals("Critical")){
                        sortedMessaged.add(error.message);
                    }

                }
                sortedMessaged.sort(Comparator.<String>naturalOrder());
                //sortedMessaged.sort((s1, s2) -> Math.abs(s1.length() - "intelligent".length()) - Math.abs(s2.length() - "intelligent".length()));
                sortedMessaged.sort((s1, s2) -> s1.length() - s2.length());
                for (String error : sortedMessaged){
                    System.out.println("--->"+error);
                }
            }
            System.out.println("Warning Messages:");
            if(warningCount == 0){
                System.out.println("--->None");
            }
            else{
                List<String> sortedMessages = new ArrayList<>();
                for (Error error : errorList){
                    if(error.type.equals("Warning")){
                        sortedMessages.add(error.message);
                    }

                }
                sortedMessages.sort(Comparator.<String>naturalOrder());
                //sortedMessaged.sort((s1, s2) -> Math.abs(s1.length() - "intelligent".length()) - Math.abs(s2.length() - "intelligent".length()));
                sortedMessages.sort((s1, s2) -> s1.length() - s2.length());
                for (String error : sortedMessages){
                    System.out.println("--->"+error);
                }
            }
            System.out.println();
        }


    }
    public static TreeMap<String, List<Error>> SortByValue(TreeMap<String, List<Error>> map) {
        ValueComparatorr vc =  new ValueComparatorr(map);
        TreeMap<String,List<Error>> sortedMap = new TreeMap<String,List<Error>>(vc);
        sortedMap.putAll(map);
        return sortedMap;
    }

    public static class ValueComparatorr implements Comparator<String> {
        Map<String, List<Error>> map;
        //switchback toInt

        public ValueComparatorr(Map<String, List<Error>> base) {
            this.map = base;
        }

        public int compare(String a, String b) {
            if (map.get(a).size() <= map.get(b).size()) {
                return 1;
            } else {
                return -1;
            } // returning 0 would merge keys
        }
    }
    public static class Error{
        public String type;
        public String message;

        public Error(String type, String message) {
            this.type = type;
            this.message = message;
        }
    }

}


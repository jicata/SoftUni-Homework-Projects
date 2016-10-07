import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/6/2015.
 */
public class _04SrabskoUnleashed {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        Pattern pattern = Pattern.compile("(\\D+) @(\\D+) (\\d+) (\\d+)");
        LinkedHashMap<String, LinkedHashMap<String, Integer>> powerOfSrapsko = new LinkedHashMap<>();

        String rawData = reader.nextLine();
        while(!rawData.equals("End")){
            Matcher matcher = pattern.matcher(rawData);
            if(matcher.find()){
                String performer = matcher.group(1);
                String venue = matcher.group(2);
                int totalTicketRevenue = Integer.parseInt(matcher.group(3)) *Integer.parseInt(matcher.group(4));
                if(!powerOfSrapsko.containsKey(venue)){
                    powerOfSrapsko.put(venue, new LinkedHashMap<String, Integer>(){{
                        put(performer, totalTicketRevenue);
                    }});
                }
                else if(powerOfSrapsko.containsKey(venue) && !powerOfSrapsko.get(venue).containsKey(performer)){
                    powerOfSrapsko.get(venue).put(performer, totalTicketRevenue);
                }
                else if(powerOfSrapsko.containsKey(venue) && powerOfSrapsko.get(venue).containsKey(performer)){
                    int money = powerOfSrapsko.get(venue).get(performer);
                    powerOfSrapsko.get(venue).put(performer, money + totalTicketRevenue);
                }

            }

            rawData = reader.nextLine();
        }
        for (Map.Entry<String, LinkedHashMap<String,Integer>> outerKey : powerOfSrapsko.entrySet()){
            System.out.println(outerKey.getKey());
            TreeMap<String,Integer> sorted = SortByValue(powerOfSrapsko.get(outerKey.getKey()));
            for (Map.Entry<String, Integer> innerKey : sorted.entrySet()){
                System.out.println("#  "+ innerKey.getKey()+" -> " + innerKey.getValue());
            }
        }
    }
    public static TreeMap<String, Integer> SortByValue(HashMap<String, Integer> map) {
        ValueComparator vc =  new ValueComparator(map);
        TreeMap<String,Integer> sortedMap = new TreeMap<String,Integer>(vc);
        sortedMap.putAll(map);
        return sortedMap;
    }
}


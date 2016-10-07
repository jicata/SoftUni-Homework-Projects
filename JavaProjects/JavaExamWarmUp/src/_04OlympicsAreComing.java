import java.util.*;

/**
 * Created by Maika on 11/6/2015.
 */
public class _04OlympicsAreComing {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String rawUserData = reader.nextLine();
        LinkedHashMap<String, Integer> countryWins = new LinkedHashMap<>();
        HashMap<String, List<String>> countryAthletes = new HashMap<>();

        while(!rawUserData.equals("report")){
            String[] properData = rawUserData.trim().replaceAll("\\s+", " ").split("\\|");
            String athlete = properData[0].trim();
            String country = properData[1].trim();
            if (!countryWins.containsKey(country)){
                countryWins.put(country, 1);
            }
            else{
                int wins = countryWins.get(country);
                countryWins.put(country, wins+1);
            }
            if(!countryAthletes.containsKey(country)){
                countryAthletes.put(country, new ArrayList<String>(){{
                    add(athlete);
                }});
            }
            else if (countryAthletes.containsKey(country) && !countryAthletes.get(country).contains(athlete)){
                countryAthletes.get(country).add(athlete);
            }




            rawUserData = reader.nextLine();
        }
        TreeMap<String, Integer> sorted = SortByValue(countryWins);
        for (Map.Entry<String, Integer> keyPair : sorted.entrySet()){
            String toPrint = String.format("%s (%d participants): %d wins", keyPair.getKey(), countryAthletes.get(keyPair.getKey()).size(), keyPair.getValue());
            System.out.println(toPrint);
        }
    }
    public static TreeMap<String, Integer> SortByValue(HashMap<String, Integer> map) {
        ValueComparator vc =  new ValueComparator(map);
        TreeMap<String,Integer> sortedMap = new TreeMap<String,Integer>(vc);
        sortedMap.putAll(map);
        return sortedMap;
    }
}



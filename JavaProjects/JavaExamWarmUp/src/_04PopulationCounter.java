import java.util.*;

/**
 * Created by Maika on 11/6/2015.
 */
public class _04PopulationCounter {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String rawData = reader.nextLine();
        LinkedHashMap<String, Long> countryTotalPop = new LinkedHashMap<>();
        HashMap<String, LinkedHashMap<String, Long>> cityPop = new HashMap<>();
        while(!rawData.equals("report")){
            String[] properData = rawData.split("\\|");
            String country = properData[1];
            String city = properData[0];
            long population = Long.parseLong(properData[2]);
            //country + total pop map
            if (!countryTotalPop.containsKey(country)){
                countryTotalPop.put(country,population);
            }
            else{
                long totalPop = countryTotalPop.get(country);
                countryTotalPop.put(country, totalPop+population);

            }
            //city + pop map
            if(!cityPop.containsKey(country)){
                cityPop.put(country, new LinkedHashMap<String, Long>(){{
                    put(city, population);
                }});
            }
            else{
                cityPop.get(country).put(city, population);
            }

            rawData = reader.nextLine();
        }
        TreeMap<String,Long> sortedOuter = SortByValue(countryTotalPop);
        for (Map.Entry<String, Long> outerPair : sortedOuter.entrySet()){
            System.out.println(outerPair.getKey() + " (total population: "+ outerPair.getValue() +")");
            TreeMap<String, Long> sortedInner = SortByValue(cityPop.get(outerPair.getKey()));
            for (Map.Entry<String, Long> innerPair : sortedInner.entrySet()){

                String toPrint = String.format("=>%s: %d", innerPair.getKey(), innerPair.getValue());
                System.out.println(toPrint);
            }

        }

    }
    public static TreeMap<String, Long> SortByValue(HashMap<String, Long> map) {
        ValueComparatorLong vc =  new ValueComparatorLong(map);
        TreeMap<String,Long> sortedMap = new TreeMap<String,Long>(vc);
        sortedMap.putAll(map);
        return sortedMap;
    }
}

class ValueComparatorLong implements Comparator<String>{
    Map<String, Long> map;
    //switchback toInt

    public ValueComparatorLong(Map<String, Long> base) {

        this.map = base;
    }

    public int compare(String a, String b) {
        if (map.get(a) <= map.get(b)) {
            return 1;
        } else {
            return -1;
        } // returning 0 would merge keys
    }
}
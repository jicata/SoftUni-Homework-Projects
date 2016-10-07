import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

/**
 * Created by Maika on 11/14/2015.
 */
public class _04Nuts {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        TreeMap<String, LinkedHashMap<String, Integer>> broNuts = new TreeMap<>();
        int n = Integer.parseInt(reader.nextLine());
        for (int i = 0; i < n; i++) {
            String rawData = reader.nextLine();
            String[] specificData = rawData.replaceAll("kg", "").split(" ");
            String companyName = specificData[0];
            String nutName = specificData[1];
            int nutQuantity = Integer.parseInt(specificData[2]);
            if(!broNuts.containsKey(companyName)){
                broNuts.put(companyName, new LinkedHashMap<String, Integer>(){{
                    put(nutName, nutQuantity);
                }});
            }
            else if(broNuts.containsKey(companyName) && !broNuts.get(companyName).containsKey(nutName)){
                broNuts.get(companyName).put(nutName, nutQuantity);
            }
            else if(broNuts.containsKey(companyName) && broNuts.get(companyName).containsKey(nutName)){
                int quantity = broNuts.get(companyName).get(nutName);
                broNuts.get(companyName).put(nutName, quantity + nutQuantity);
            }

        }
        for (Map.Entry<String, LinkedHashMap<String, Integer>> outerPair : broNuts.entrySet()){
            System.out.print(outerPair.getKey() + ": ");
            int counter = 0;
            for (Map.Entry<String, Integer> innerPair : broNuts.get(outerPair.getKey()).entrySet()){
                if (counter < broNuts.get(outerPair.getKey()).size()-1){
                    System.out.print(innerPair.getKey() + "-" + innerPair.getValue() + "kg, ");
                }
                else{
                    System.out.print(innerPair.getKey()+"-"+innerPair.getValue()+"kg");
                }
                counter++;
            }
            counter=0;
            System.out.println();
        }
    }
}

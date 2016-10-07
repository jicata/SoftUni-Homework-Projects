import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.stream.Collectors;

/**
 * Created by Maika on 11/4/2015.
 */
public class _04LegendaryFarming2 {

    public static void main(String[] args) {
        final int MAX_MAT = 250;
        Scanner reader = new Scanner(System.in);
        boolean isComplete = false;
        LinkedHashMap<String,Integer> valuableMats = new LinkedHashMap<String,Integer>(){{
            put("fragments", 0);
            put("motes",0);
            put("shards", 0);

        }
        };
        TreeMap<String, Integer> junk = new TreeMap<>();
        String rawData = reader.nextLine().toLowerCase();
        String legendaryName = "";
        while(!isComplete){
            String[] mats = rawData.split(" ");
            for (int i = 0; i < mats.length ; i+=2) {
                String materialName = mats[i+1].toLowerCase();
                int matQuantity = Integer.parseInt(mats[i]);
                if (materialName.equals("motes") || materialName.equals("fragments")|| materialName.equals("shards")){
                    int quantitySoFar = valuableMats.get(materialName);
                    valuableMats.put(materialName, quantitySoFar + matQuantity);
                    if(valuableMats.get(materialName) >= MAX_MAT){
                        valuableMats.put(materialName, valuableMats.get(materialName) - MAX_MAT);
                        if (materialName.equals("fragments")){
                            legendaryName = "Valanyr";
                        }
                        else if(materialName.equals("shards")){
                            legendaryName = "Shadowmourne";
                        }
                        else{
                            legendaryName = "Dragonwrath";
                        }
                        isComplete = true;
                        break;
                    }
                }
                else{
                    if(!junk.containsKey(materialName)){
                        junk.put(materialName,matQuantity);
                    }
                    else{
                        junk.put(materialName, junk.get(materialName) + matQuantity);
                    }
                }
            }
            if(!isComplete){
                rawData = reader.nextLine().toLowerCase();
            }

        }
        if (isComplete){
            System.out.println(legendaryName + " obtained!");
            valuableMats.entrySet().stream()
                    .sorted((e1, e2) -> e2.getValue().compareTo(e1.getValue()))
                    .forEach(e -> System.out.println(e.getKey()+": " + e.getValue()));
            junk.entrySet().stream().forEach(k -> System.out.println(k.getKey() + ": " + k.getValue()));
            }

        }
    }


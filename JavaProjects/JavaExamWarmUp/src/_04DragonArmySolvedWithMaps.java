import java.util.*;

/**
 * Created by Maika on 10/31/2015.
 */
public class _04DragonArmySolvedWithMaps {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int numberOfDragons = Integer.parseInt(reader.nextLine());

        LinkedHashMap<String, TreeMap<String, Integer[]>> themDraggies = new LinkedHashMap<>();
        HashMap<String,String> typesAndAverage = new HashMap<>();
        for (int i = 0; i < numberOfDragons ; i++) {
            String userInput = reader.nextLine();
            String[] dragonCharacteristics = userInput.split(" ");
            String dragonType = dragonCharacteristics[0];
            String dragonName = dragonCharacteristics[1];
            int dragonDamage = 0;
            int dragonHealth = 0;
            int dragonArmor = 0;
            if (!dragonCharacteristics[2].equals("null")) {
                dragonDamage = Integer.parseInt(dragonCharacteristics[2]);
            } else {
                dragonDamage = 45;
            }
            if (!dragonCharacteristics[3].equals("null")) {
                dragonHealth = Integer.parseInt(dragonCharacteristics[3]);
            } else {
                dragonHealth = 250;
            }
            if (!dragonCharacteristics[4].equals("null")) {
                dragonArmor = Integer.parseInt(dragonCharacteristics[4]);
            } else {
                dragonArmor = 10;
            }
            if(themDraggies.containsKey(dragonType) && themDraggies.get(dragonType).containsKey(dragonName)){
                Integer[] dragonStats = new Integer[]{dragonDamage,dragonHealth,dragonArmor};
                themDraggies.get(dragonType).put(dragonName, dragonStats);
                continue;
            }

            if (!themDraggies.containsKey(dragonType)){
                themDraggies.put(dragonType, new TreeMap<>());
                themDraggies.get(dragonType).put(dragonName, new Integer[]{dragonDamage, dragonHealth, dragonArmor});
            }
            else{
                themDraggies.get(dragonType).put(dragonName, new Integer[]{dragonDamage, dragonHealth, dragonArmor});
            }

        }
        double avgDamage = 0;
        double avgHealth = 0;
        double avgArmor = 0;
        for (Map.Entry<String, TreeMap<String, Integer[]>> outerKeys : themDraggies.entrySet()){
            String key = outerKeys.getKey();
            TreeMap<String, Integer[]> innerMap = outerKeys.getValue();
            for(String innerKey : innerMap.keySet()){
                avgDamage += themDraggies.get(key).get(innerKey)[0];
                avgHealth += themDraggies.get(key).get(innerKey)[1];
                avgArmor+= themDraggies.get(key).get(innerKey)[2];
            }
            avgDamage = avgDamage / themDraggies.get(key).size();
            avgHealth = avgHealth / themDraggies.get(key).size();
            avgArmor = avgArmor / themDraggies.get(key).size();
            String totalAverage = String.format("::(%.2f/%.2f/%.2f)", avgDamage, avgHealth, avgArmor);
            typesAndAverage.put(key,totalAverage);
            avgDamage = 0;
            avgArmor = 0;
            avgHealth = 0;
        }
        for (Map.Entry<String, TreeMap<String, Integer[]>> outerKeys : themDraggies.entrySet()){
            System.out.println(outerKeys.getKey() +typesAndAverage.get(outerKeys.getKey()));
            for (Map.Entry<String, Integer[]> innerMap : themDraggies.get(outerKeys.getKey()).entrySet()){
                String weGotit = String.format("-%s -> damage: %d, health: %d, armor: %d"
                        ,innerMap.getKey(), innerMap.getValue()[0],innerMap.getValue()[1], innerMap.getValue()[2]);
                System.out.println(weGotit);
            }
        }

    }
}

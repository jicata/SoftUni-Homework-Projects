import java.text.Collator;
import java.util.*;

/**
 * Created by Maika on 10/31/2015.
 */
public class _04DragonArmySolvedWithClass {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int numberOfDragons = Integer.parseInt(reader.nextLine());
        List<Dragon> dragons = new ArrayList<>();
        LinkedHashMap<String, String> typesAndAverage = new LinkedHashMap<>();
        for (int i = 0; i < numberOfDragons ; i++) {
            String userInput = reader.nextLine();
            String[] dragonCharacteristics = userInput.split(" ");
            String dragonType = dragonCharacteristics[0];
            String dragonName = dragonCharacteristics[1];
            int dragonDamage = 0;
            int dragonHealth = 0;
            int dragonArmor = 0;
            if(!dragonCharacteristics[2].equals("null")){
                dragonDamage = Integer.parseInt(dragonCharacteristics[2]);
            }
            else{
                dragonDamage = 45;
            }
            if(!dragonCharacteristics[3].equals("null")){
                dragonHealth = Integer.parseInt(dragonCharacteristics[3]);
            }
            else{
                dragonHealth = 250;
            }
            if(!dragonCharacteristics[4].equals("null")){
                dragonArmor = Integer.parseInt(dragonCharacteristics[4]);
            }
            else{
                dragonArmor = 10;
            }
            int counter = 0;
            boolean duplicateDragon =false;
            for (Dragon dragon : dragons){

                if (dragon.type.equals(dragonType) && dragon.name.equals(dragonName)){
                    duplicateDragon = true;
                    dragons.get(counter).health = dragonHealth;
                    dragons.get(counter).damage = dragonDamage;
                    dragons.get(counter).armor = dragonArmor;
                }
                counter++;
            }
            counter = 0;
            if(!duplicateDragon){
                dragons.add(new Dragon(dragonType, dragonName,dragonDamage,dragonHealth, dragonArmor));
            }

            if (!typesAndAverage.containsKey(dragonType)){
                typesAndAverage.put(dragonType, new String());
            }

        }
        double avgDmg = 0;
        double avgHealth = 0;
        double avgArmor =0;
        int counter = 0;
        for (Map.Entry<String, String> keys : typesAndAverage.entrySet()){
            String key = keys.getKey();
            for (Dragon dragon : dragons){
                if(dragon.type.equals(key)){
                    counter++;
                    avgDmg += dragon.damage;
                    avgHealth +=dragon.health;
                    avgArmor +=dragon.armor;
                }
            }
            avgDmg = avgDmg / counter;
            avgHealth = avgHealth / counter;
            avgArmor = avgArmor / counter;

//            String avgDmgStr = String.valueOf(avgDmg);
//            String avgHealthStr = String.valueOf(avgHealth);
//            String avgArmorStr = String.valueOf(avgArmor);
            String totalAverage = String.format("::(%.2f/%.2f/%.2f)", avgDmg, avgHealth, avgArmor);
            avgDmg = 0;
            avgArmor = 0;
            avgHealth = 0;
            counter = 0;
            typesAndAverage.put(key, totalAverage);
        }

        LinkedList<Dragon> sortedDragons = new LinkedList<>();

        for (Map.Entry<String, String> keyValue : typesAndAverage.entrySet()){
            System.out.println(keyValue.getKey() + keyValue.getValue());
            for (Dragon dragon : dragons){
                if (dragon.type.equals(keyValue.getKey())){
                    sortedDragons.add(dragon);
                }
            }
            Collections.sort(sortedDragons, (o1, o2) -> o1.name.compareTo(o2.name));

            for (Dragon sortedDragon : sortedDragons){
                System.out.printf("-%s -> damage: %d, health: %d, armor: %d", sortedDragon.name, sortedDragon.damage, sortedDragon.health, sortedDragon.armor);
                System.out.println();
            }
            sortedDragons.clear();

        }




    }
    public static class Dragon{
        public String type;
        public String name;
        public int damage;
        public int health;
        public int armor;

        public Dragon(String type, String name, int damage, int health, int armor) {
            this.type = type;
            this.name = name;
            this.damage = damage;
            this.health = health;
            this.armor = armor;
        }
    }
}

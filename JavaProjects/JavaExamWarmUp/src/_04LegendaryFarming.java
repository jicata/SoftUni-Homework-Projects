import java.awt.*;
import java.util.*;
import java.util.function.Function;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;
import java.util.stream.Stream;


public class _04LegendaryFarming {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userData = reader.nextLine().toLowerCase();
        //List<Material> materials = new ArrayList<>();
        LinkedHashMap<String, Integer> valuableMaterial = new LinkedHashMap<String, Integer>();
        valuableMaterial.put("fragments", 0);
        valuableMaterial.put("motes", 0);
        valuableMaterial.put("shards", 0);


        TreeMap<String, Integer> junkMaterial = new TreeMap<>();
        boolean isObtained = false;
        while (!isObtained) {
            Pattern pattern = Pattern.compile("(\\d+) (\\w+)");
            Matcher matcher = pattern.matcher(userData);
            while (matcher.find()) {
                int quantity = Integer.parseInt(matcher.group(1));
                String materialName = matcher.group(2);
                if (materialName.equals("shards") || materialName.equals("fragments") || materialName.equals("motes")) {
                    int quantitySoFar = valuableMaterial.get(materialName);
                    valuableMaterial.put(materialName, quantitySoFar + quantity);
                    for (Map.Entry<String, Integer> keyPair : valuableMaterial.entrySet()) {
                        String key = keyPair.getKey();
                        int quantityy = keyPair.getValue();
                        if (quantityy >= 250) {
                            if (key.equals("shards")) {
                                System.out.println("Shadowmourne obtained!");
                                int materialLeft = valuableMaterial.get("shards") - 250;
                                valuableMaterial.put("shards", materialLeft);
                                isObtained = true;
                                valuableMaterial.entrySet().stream()
                                        .sorted(Collections.reverseOrder(Map.Entry.comparingByValue()))
                                        .forEachOrdered(k -> System.out.println(k.getKey() + ": " + k.getValue()));


                            }
                            if (key.equals("fragments")) {
                                int materialLeft = valuableMaterial.get("fragments") - 250;
                                valuableMaterial.put("fragments", materialLeft);
                                isObtained = true;
                                System.out.println("Valanyr obtained!");
                                valuableMaterial.entrySet().stream()
                                        .sorted(Collections.reverseOrder(Map.Entry.comparingByValue()))
                                        .forEachOrdered(k -> System.out.println(k.getKey() + ": " + k.getValue()));


                            }
                            if (key.equals("motes")) {
                                int materialLeft = valuableMaterial.get("motes") - 250;
                                valuableMaterial.put("motes", materialLeft);
                                isObtained = true;
                                System.out.println("Dragonwrath obtained!");
                                valuableMaterial.entrySet().stream()
                                        .sorted(Collections.reverseOrder(Map.Entry.comparingByValue()))
                                        .forEachOrdered(k -> System.out.println(k.getKey() + ": " + k.getValue()));
                            }
                        }
                    }

                } else if (!isObtained) {
                    if (!junkMaterial.containsKey(materialName)) {
                        junkMaterial.put(materialName, quantity);
                    } else {
                        int currentQuantity = junkMaterial.get(materialName);
                        junkMaterial.put(materialName, currentQuantity + quantity);
                    }

                }


            }
            if(!isObtained){
                userData = reader.nextLine().toLowerCase();
            }
            else{
                break;
            }




        }
        if(junkMaterial.size() > 0){
            for (Map.Entry<String, Integer> keyPair : junkMaterial.entrySet()) {
                System.out.println(keyPair.getKey()+ ": " + keyPair.getValue());


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
// class ValueComparator implements Comparator<String>{
//    Map<String, Integer> map;
//
//    public ValueComparator(Map<String, Integer> base) {
//        this.map = base;
//    }
//
//    public int compare(String a, String b) {
//        if (map.get(a) <= map.get(b)) {
//            return 1;
//        } else {
//            return -1;
//        } // returning 0 would merge keys
//    }
//}



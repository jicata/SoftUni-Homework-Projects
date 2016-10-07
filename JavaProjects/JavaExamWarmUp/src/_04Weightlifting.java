import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

/**
 * Created by Maika on 11/7/2015.
 */
public class _04Weightlifting {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int n = Integer.parseInt(reader.nextLine());
        TreeMap<String, TreeMap<String, Long>> lifters = new TreeMap<>();
        for(int i = 0; i < n; i++){
            String rawdata = reader.nextLine();
            String[] properData = rawdata.split(" ");
            String lifterName = properData[0];
            String excercise = properData[1];
            long kilograms = Long.parseLong(properData[2]);

            if(!lifters.containsKey(lifterName)){
                lifters.put(lifterName, new TreeMap<String, Long>(){{
                    put(excercise, kilograms);
                }});
            }
            else if(lifters.containsKey(lifterName) && !lifters.get(lifterName).containsKey(excercise)){
                lifters.get(lifterName).put(excercise,kilograms);
            }
            else if(lifters.containsKey(lifterName) && lifters.get(lifterName).containsKey(excercise)){
                long kilos = lifters.get(lifterName).get(excercise);
                lifters.get(lifterName).put(excercise, kilos + kilograms);
            }

        }
        int counter = 0;
        for (Map.Entry<String,TreeMap<String, Long>> outerPair : lifters.entrySet()){
            System.out.print(outerPair.getKey() + " : ");
            for (Map.Entry<String, Long> innerPair : lifters.get(outerPair.getKey()).entrySet()){

               if(counter < lifters.get(outerPair.getKey()).size()-1){
                   System.out.print(innerPair.getKey() + " - " + innerPair.getValue()+  " kg, ");
               }
                else{
                   System.out.print(innerPair.getKey() + " - " + innerPair.getValue()+" kg");
               }
                counter++;
            }
            counter = 0;
            System.out.println();
        }
    }


}

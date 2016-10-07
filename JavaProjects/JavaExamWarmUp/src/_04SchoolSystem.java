import java.util.*;

/**
 * Created by Maika on 11/7/2015.
 */
public class _04SchoolSystem {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int n = Integer.parseInt(reader.nextLine());
        TreeMap<String, TreeMap<String, List<Double>>> schoolSys = new TreeMap<>();
        for (int i = 0; i < n ; i++) {
            String userInput = reader.nextLine();
            String[] properData = userInput.split(" ");

            String fullName = properData[0] +" " + properData[1];
            String subjectName = properData[2];
            double grade = Double.parseDouble(properData[3]);

            if(!schoolSys.containsKey(fullName)){
                schoolSys.put(fullName, new TreeMap<String, List<Double>>(){{
                    put(subjectName, new ArrayList<Double>(){{
                        add(grade);
                    }});
                }});
            }
            else if(schoolSys.containsKey(fullName) && !schoolSys.get(fullName).containsKey(subjectName)){
                schoolSys.get(fullName).put(subjectName, new ArrayList<Double>(){{
                    add(grade);
                }});
            }
            else if(schoolSys.containsKey(fullName) && schoolSys.get(fullName).containsKey(subjectName)){
                schoolSys.get(fullName).get(subjectName).add(grade);
            }



        }

        int counter = 0;
        for (Map.Entry<String, TreeMap<String, List<Double>>> outerPair : schoolSys.entrySet()){
            System.out.print(outerPair.getKey() + ": [");
            for (Map.Entry<String, List<Double>> innerPair : schoolSys.get(outerPair.getKey()).entrySet()){
                double totalSumMarks = innerPair.getValue()
                        .stream()
                        .mapToDouble(Double::doubleValue)
                        .sum();
                double avg = totalSumMarks / innerPair.getValue().size();
                if (counter < schoolSys.get(outerPair.getKey()).size()-1){
                    System.out.printf("%s - %.2f, ",innerPair.getKey(),avg);
                }
                else{
                    System.out.printf("%s - %.2f]",innerPair.getKey(),avg);
                }
                counter++;
            }
            System.out.println();
            counter=0;
        }
    }
}

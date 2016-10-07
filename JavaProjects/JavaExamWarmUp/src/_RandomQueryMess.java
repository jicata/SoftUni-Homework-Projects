import java.util.*;

/**
 * Created by Maika on 11/9/2015.
 */
public class _RandomQueryMess {
    public static void main(String[] args) {

        Scanner reader = new Scanner(System.in);
        LinkedHashMap<String, ArrayList<String>> queries = new LinkedHashMap<>();
        List<String> firstSplit = new ArrayList<>();
        String kur = reader.nextLine();
        while(!kur.equals("END")){
            if(kur.contains("?")){
                kur = kur.substring(kur.indexOf('?')+1);
            }
            String penis = kur.replaceAll("%20|\\+", " ");
            String[]kurche = penis.split("&");

            for (int i = 0; i < kurche.length ; i++) {
                firstSplit.add(kurche[i]);
            }

            for (int j = 0; j < firstSplit.size() ; j++) {
                String[] finalSplit = firstSplit.get(j).split("=");
                for (int i = 0; i <finalSplit.length ; i+=2) {
                    String key = finalSplit[i].trim().replaceAll("\\s+", " ");
                    String value = finalSplit[i+1].trim().replaceAll("\\s+", " ");
                    if(!queries.containsKey(key)){
                        queries.put(key, new ArrayList<String>(){{
                            add(value);
                        }});
                    }
                    else{
                        queries.get(key).add(value);
                    }
                }

            }
            firstSplit.clear();
            int cunner = 0;
            for (Map.Entry<String, ArrayList<String>> outerPair : queries.entrySet()){
                System.out.print(outerPair.getKey() + "=[");
                for (String innerVal : outerPair.getValue()){
                    if(cunner < outerPair.getValue().size() -1){
                        System.out.print(innerVal+", ");
                    }
                    else{
                        System.out.print(innerVal+"]");
                    }
                    cunner++;

                }
                cunner = 0;
            }
            System.out.println();
            queries.clear();
            kur = reader.nextLine();
        }



        }
    }


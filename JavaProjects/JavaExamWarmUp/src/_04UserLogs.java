import sun.reflect.generics.tree.Tree;

import javax.xml.crypto.dsig.keyinfo.KeyValue;
import java.util.*;

/**
 * Created by Maika on 10/31/2015.
 */
public class _04UserLogs {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userLog = reader.nextLine();
        TreeMap<String,LinkedHashMap<String, Integer>> collectedLogs = new TreeMap<>();

        while(!userLog.equals("end")){
            String[] logDetails = userLog.split(" ");
            String userName = logDetails[2].replace("user=","");
            String userIP = logDetails[0].replace("IP=", "");
            if (!collectedLogs.containsKey(userName)){
                collectedLogs.put(userName, new LinkedHashMap<>());
                collectedLogs.get(userName).put(userIP, 1);
            }
            else {
                Integer count = 0;
                if(collectedLogs.get(userName).containsKey(userIP)){
                    count = collectedLogs.get(userName).get(userIP);
                }
                collectedLogs.get(userName).put(userIP, count +1);
            }

            userLog = reader.nextLine();
        }
        int counter = 0;
        for (Map.Entry<String,LinkedHashMap<String,Integer>> key : collectedLogs.entrySet()){
            System.out.println(key.getKey()+":");
            LinkedHashMap<String,Integer> value = key.getValue();
            for (Map.Entry<String, Integer> innerKey : value.entrySet()){

                counter++;
                if (counter == collectedLogs.get(key.getKey()).size()){
                    System.out.print(innerKey.getKey() + " => " + innerKey.getValue() + ".");
                }
                else{
                    System.out.print(innerKey.getKey() + " => " + innerKey.getValue() + ", ");
                }

            }
            counter=0;
            System.out.println();


        }

    }
}

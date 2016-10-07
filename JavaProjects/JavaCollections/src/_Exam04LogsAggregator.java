import java.util.*;
import java.util.Map.Entry;

/**
 * Created by Maika on 10/27/2015.
 */
public class _Exam04LogsAggregator {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int numberOfLogs = Integer.parseInt(reader.nextLine());
        TreeMap<String, Integer> durations = new TreeMap<>();
        HashMap<String, TreeSet<String>> ipAdresses = new HashMap<>();
        for (int i = 0; i < numberOfLogs ; i++) {
            String rawData = reader.nextLine();
            String[] siftedData = rawData.split(" ");

            String name = siftedData[1];
            int duration = Integer.parseInt(siftedData[2]);
            String IPadrasse = siftedData[0];

            Integer oldDuration = durations.get(name);
            if (oldDuration == null){
                oldDuration = 0;
            }
            durations.put(name, duration+oldDuration);

            TreeSet<String> Ips = ipAdresses.get(name);
            if (Ips == null){
                Ips = new TreeSet<>();
            }
            Ips.add(IPadrasse);
            ipAdresses.put(name, Ips);

        }
        //user/duration/isp
        for (Entry<String, Integer> userAndDurations : durations.entrySet()){

            String userName = userAndDurations.getKey();
            Integer duration = userAndDurations.getValue();
            TreeSet<String> IPs = ipAdresses.get(userName);
            System.out.println(userName + ": " + duration+" " + IPs);
        }
    }
}

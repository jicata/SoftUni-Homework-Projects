import java.util.Comparator;
import java.util.Map;

class ValueComparator implements Comparator<String> {
    Map<String, Integer> map;
    //switchback toInt

    public ValueComparator(Map<String, Integer> base) {
        this.map = base;
    }

    public int compare(String a, String b) {
        if (map.get(a) <= map.get(b)) {
            return 1;
        } else {
            return -1;
        } // returning 0 would merge keys
    }
}
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.*;

/**
 * Created by Maika on 10/28/2015.
 */
public class asd {
    public static void main(String[] args) {
       StringBuilder kur = new StringBuilder("IList<T> implements IEnumerable<T>. GoPHP is a PHP library.");
        String baasi = "T";
        int arr = kur.indexOf("T");
        kur.replace(arr,arr+baasi.length(),"");
        kur.insert(arr,"fuckfuck");
        System.out.println(kur);
    }



}

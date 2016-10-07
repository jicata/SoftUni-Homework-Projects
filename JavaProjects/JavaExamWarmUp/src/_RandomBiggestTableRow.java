import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 11/14/2015.
 */
public class _RandomBiggestTableRow {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String useless = reader.nextLine();
        String uselessTwo = reader.nextLine();
        Pattern pattern = Pattern.compile("((?:\\.|[0-9]+\\.?)(?:[0-9])?[0-9]+?)");
        List<Double> currentList = new ArrayList<>();
        List<Double> biggestList = new ArrayList<>();
        double currentSum = 0;
        double biggestSum = Integer.MIN_VALUE;
        boolean someValue = false;
        //LinkedHashMap<String, List<Double>> townAndValue = new LinkedHashMap<>();
        String rawData = reader.nextLine();
        while(!rawData.equals("</table>")) {

            Matcher matcher = pattern.matcher(rawData);
            while(matcher.find()){
                someValue = true;
                double value = Double.parseDouble(matcher.group(1));
                if(value !=0){
                    currentList.add(value);
                }

                currentSum+=value;
            }
            if(currentSum > biggestSum){
                biggestList = new ArrayList<>(currentList);
                biggestSum = currentSum;
            }
            currentList.clear();
            currentSum=0;
            rawData = reader.nextLine();

        }
        if(someValue){
            System.out.print(biggestSum+" = ");
            for (int i = 0; i < biggestList.size(); i++) {
                if(i<biggestList.size() - 1){
                    System.out.print(biggestList.get(i) + " + ");
                }
                else{
                    System.out.print(biggestList.get(i));
                }

            }

        }
        else {
            System.out.println("no data");
        }

    }
}

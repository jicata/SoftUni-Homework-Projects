
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _14SuperMagicalBullshite {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String stringA = reader.nextLine();
        String stringB = reader.nextLine();
        //HeyIJustMetYouAndThisIsCrazyButHeresMyMethodSoCallMeMaybe(stringA,stringB);
        System.out.println(HeyIJustMetYouAndThisIsCrazyButHeresMyMethodSoCallMeMaybe(stringA,stringB));
    }
    public static boolean HeyIJustMetYouAndThisIsCrazyButHeresMyMethodSoCallMeMaybe(String one,String two){
        boolean exchangeable = false;
        Map<Character, Character> thatsWhereIKeepEm = new HashMap<Character, Character>();
        char[] firstString = one.toCharArray();
        char[] secondString = two.toCharArray();
        char value = ' ';

        for (int i = 0; i < firstString.length ; i++) {
            if(!thatsWhereIKeepEm.containsKey(firstString[i])){
                thatsWhereIKeepEm.put(firstString[i], secondString[i]);
            }
            else{
                value = thatsWhereIKeepEm.get(firstString[i]);
                if(value == secondString[i]){
                    exchangeable = true;
                }
                else{
                    exchangeable = false;
                    return  exchangeable;
                }
            }
        }
        return  exchangeable;
    }
}

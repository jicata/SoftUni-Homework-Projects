import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
    // malka greshka v uslovieto
    // pri input
    // Gosho Pesho
    // output-a e
    // 53253 a ne 54363
    // G * P = 5680
    // o * e = 11211
    // s * s = 13225
    // h * h = 10816
    // o * o = 12321
    // = 53253
public class _12CharacterMultiplier {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userStringOne = reader.nextLine();
        String userStringTwo = reader.nextLine();
        System.out.println(CharacterMultiplier(userStringOne, userStringTwo));
    }
    public static int CharacterMultiplier(String stringOne, String stringTwo){
        int sum = 0;
        int charProduct = 1;

        int startIndex = 0;

        char[] stringOneArray = stringOne.toCharArray();
        char[] stringTwoArray = stringTwo.toCharArray();
        if (stringOneArray.length > stringTwoArray.length){
            for (int i = 0; i < stringTwoArray.length; i++) {
                charProduct = stringOneArray[i] * stringTwoArray[i];
                sum += charProduct;
            }
            startIndex = stringOneArray.length -(stringOneArray.length - stringTwoArray.length);
            for (int i = startIndex; i < stringOneArray.length; i++) {
                sum+= stringOneArray[i];
            }

        }
        else if(stringOneArray.length< stringTwoArray.length){
            for (int i = 0; i < stringOneArray.length; i++) {
                charProduct = stringOneArray[i] * stringTwoArray[i];
                sum += charProduct;
            }
            startIndex = stringTwoArray.length - (stringTwoArray.length - stringOneArray.length);
            for (int i = startIndex; i < stringTwoArray.length; i++) {
                sum+= stringTwoArray[i];
            }


        }
        else{
            for (int i = 0; i <stringOneArray.length ; i++) {
                charProduct = stringOneArray[i] * stringTwoArray[i];
                sum += charProduct;
            }
        }
        return  sum;
    }
    //POSLEPIS
    //ako chetesh tova....
    //znachi sum predal domashnoto navreme i vsichko e OK!
    // :D
}

import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _08OddAndEvenPairs {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String stringArray = reader.nextLine();
        String[] theArray = stringArray.split(" ");
        if (theArray.length % 2 == 0){
            for (int i = 0; i < theArray.length-1 ; i+=2) {
                int firstNumber = Integer.parseInt(theArray[i]);
                int secondNumber = Integer.parseInt(theArray[i+1]);
                if (firstNumber % 2 == 0 && secondNumber % 2 ==0){
                    System.out.printf("%d, %d -> both are even", firstNumber, secondNumber);
                    System.out.println();
                }
                else if(firstNumber % 2 != 0 && secondNumber %2 !=0){
                    System.out.printf("%d, %d -> both are odd", firstNumber, secondNumber);
                    System.out.println();
                }
                else{
                    System.out.printf("%d, %d -> different", firstNumber, secondNumber);
                    System.out.println();
                }


            }
        }
        else{
            System.out.println("Invalid length");
        }

    }
}

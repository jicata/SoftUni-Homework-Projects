import java.util.Map;
import java.util.Scanner;

/**
 * Created by Maika on 10/16/2015.
 */
public class _04CalculateExpressions {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        double[] threeNumbers = new double[3];
        for (int i = 0; i < 3 ; i++) {
            threeNumbers[i] = Double.parseDouble(reader.nextLine());
        }
        double a = threeNumbers[0];
        double b = threeNumbers[1];
        double c = threeNumbers[2];
        double sqrtC = Math.sqrt((double)c);
        double formula1 = Math.pow((double) (a * a + b * b) / (a * a - b * b), ((double)(a+b+c) / sqrtC));
        double formula2 = Math.pow((double)(a*a + b*b - c*c*c), a-b);
        double averageABC = (a+b+c) / 3;
        double averagef1f2 = (formula1 + formula2) / 2;
        System.out.printf("%.2f",formula1);
        System.out.println();
        System.out.printf("%.2f", formula2);
        System.out.println();
        if (averageABC > averagef1f2)
        {
            System.out.printf("%.2f",averageABC - averagef1f2);
        }
        else if(averagef1f2>averageABC)
        {
            System.out.printf("%.2f", averagef1f2 - averageABC);
        }
        else
        {
            System.out.println("NaN");
        }
    }
}

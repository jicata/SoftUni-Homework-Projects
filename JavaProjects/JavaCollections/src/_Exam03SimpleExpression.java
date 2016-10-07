import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _Exam03SimpleExpression {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userFkdUpData = reader.nextLine();
        String okData = userFkdUpData.replaceAll("\\s+", "");

        String[]numbers = okData.split("[+-]");
        String[]operators = okData.split("[[^-+]]");
        List<String> actualOperators = new ArrayList<>();

        for (int i = 0; i < operators.length ; i++) {
            if (!operators[i].equals("")){
                actualOperators.add(operators[i]);
            }
        }
        int counter = 0;
        BigDecimal result = new BigDecimal("0");
        for (int i = 0; i < numbers.length ; i++) {

            if(i==0){
                BigDecimal number = new BigDecimal(numbers[i]);

                result = result.add(number);
                continue;
            }

            BigDecimal numberTwo = new BigDecimal(numbers[i]);
            String operator =  actualOperators.get(counter);
            counter++;
            if (operator.equals("-")){
                result= result.subtract(numberTwo);

            }
            else{
                result= result.add(numberTwo);
            }
        }



        DecimalFormat df = new DecimalFormat("#.#######");
        df.setRoundingMode(RoundingMode.FLOOR);


        System.out.println(result.toPlainString());
    }
}

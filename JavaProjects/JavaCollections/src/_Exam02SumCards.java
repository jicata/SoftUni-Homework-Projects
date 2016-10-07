import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _Exam02SumCards {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String[] cardsUnfiltered = reader.nextLine().split(" ");
        String[] cardsFiltered = new String[cardsUnfiltered.length];
        for (int i = 0; i < cardsUnfiltered.length ; i++) {
            StringBuilder sb = new StringBuilder(cardsUnfiltered[i]);
            if (sb.length() > 2){
                sb.deleteCharAt(2);
                cardsFiltered[i] = sb.toString();
            }
            else{
                sb.deleteCharAt(1);
                cardsFiltered[i] = sb.toString();
            }
        }
        for (int i = 0; i <cardsFiltered.length ; i++) {
            switch (cardsFiltered[i]){
                case "J": cardsFiltered[i] = "12";
                    break;
                case "Q": cardsFiltered[i] = "13";
                    break;
                case "K": cardsFiltered[i] = "14";
                    break;
                case "A": cardsFiltered[i] = "15";
                    break;
            }
        }
        int sum = 0;
        int value = 0;
        for (int i = 0; i < cardsFiltered.length ; i++) {
            value = Integer.parseInt(cardsFiltered[i]);
            if(cardsFiltered.length > 1){
                if (i==0 && value == Integer.parseInt(cardsFiltered[i+1])){
                    sum+=value*2;
                }
                else if(i==cardsFiltered.length -1 && value == Integer.parseInt(cardsFiltered[i-1])){
                    sum += value*2;
                }
                else if ((i!=0 && i< cardsFiltered.length-1) &&(value == Integer.parseInt(cardsFiltered[i-1]) ||value == Integer.parseInt(cardsFiltered[i+1]))){
                    sum += value*2;
                }
                else{
                    sum+=value;
                }
            }
            else{
                sum+=value;
            }

            
        }
        System.out.println(sum);

    }
}

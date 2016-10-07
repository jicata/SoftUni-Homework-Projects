import java.util.Scanner;

/**
 * Created by Maika on 11/15/2015.
 */
public class _01JavaExam {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int numberOfPeople = Integer.parseInt(reader.nextLine());
        int totalBeds=0;
        int totalMeals=0;
        int n = Integer.parseInt(reader.nextLine());
        for (int i = 0; i < n ; i++) {
            String accomodations = reader.nextLine();
            String[] accSpecifics = accomodations.split(" ");
            String accType = accSpecifics[0];
            int accQuantity = Integer.parseInt(accSpecifics[1]);
            String accDetails = accSpecifics[2];
            if(accType.equals("tents")){
                int totalTents;
                if(accDetails.equals("firstClass")){
                    totalTents = accQuantity * 3;
                }
                else{
                    totalTents = accQuantity * 2;
                }
                totalBeds +=totalTents;
            }
            if(accType.equals("rooms")){
                int totalRooms;
                if(accDetails.equals("triple")){
                    totalRooms = accQuantity * 3;

                }
                else if(accDetails.equals("double")){
                    totalRooms = accQuantity * 2;
                }
                else{
                    totalRooms = accQuantity;

                }
                totalBeds+=totalRooms;
            }
            if(accType.equals("food")){
                int totalFood;
                if(accDetails.equals("musaka")){
                    totalFood = accQuantity *2;
                    totalMeals +=totalFood;
                }

            }

        }
        if(totalBeds >= numberOfPeople){
            System.out.println("Everyone is happy and sleeping well. Beds left: "+(totalBeds-numberOfPeople));
        }
        else{
            System.out.println("Some people are freezing cold. Beds needed: "+(numberOfPeople-totalBeds));
        }
        if(totalMeals >= numberOfPeople){
            System.out.println("Nobody left hungry. Meals left: " + (totalMeals-numberOfPeople));
        }
        else{
            System.out.println("People are starving. Meals needed: "+(numberOfPeople-totalMeals));
        }
    }
}

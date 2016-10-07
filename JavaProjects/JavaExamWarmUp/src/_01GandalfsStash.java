import java.util.Scanner;
import java.util.regex.Pattern;
//•	Cram: 2 points of happiness;
//        •	Lembas: 3 points of happiness;
//        •	Apple: 1 point of happiness;
//        •	Melon: 1 point of happiness;
//        •	HoneyCake: 5 points of happiness;
//        •	Mushrooms: -10 points of happiness;
//        •	Everything else: -1 point of happiness;



public class _01GandalfsStash {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int happiness = Integer.parseInt(reader.nextLine());
        String stuffToConsume = reader.nextLine().toLowerCase();
        String properStuff = stuffToConsume.replaceAll("\\W|_"," ");

        String finalThing = properStuff.replaceAll("\\s+", " ");
        String[] letsDoIt = finalThing.split(" ");

        for (int i = 0; i < letsDoIt.length ; i++) {
            String particularItem = letsDoIt[i];
            switch (particularItem){
                case "cram": happiness+=2;
                    break;
                case "lembas": happiness+=3;
                    break;
                case "apple": happiness+=1;
                    break;
                case "melon": happiness+=1;
                    break;
                case "honeycake": happiness +=5;
                    break;
                case "mushrooms": happiness-=10;
                    break;
                default: happiness-=1;
                    break;
            }
        }
        System.out.println(happiness);
        if(happiness< -5){
            System.out.println("Angry");
        }
        else if(happiness >= -5 && happiness <= 0 ){
            System.out.println("Sad");
        }
        else if(happiness > 0 && happiness <=15){
            System.out.println("Happy");
        }
        else if(happiness > 15){
            System.out.println("Special JavaScript mood");
        }


    }
}

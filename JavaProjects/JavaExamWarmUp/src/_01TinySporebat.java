import java.util.Scanner;

/**
 * Created by Maika on 11/3/2015.
 */
public class _01TinySporebat {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int playerHealth = 5800;
        String rawData = reader.nextLine();
        int counter = 0;
        boolean isDead = false;
        while(!rawData.equals("Sporeggar")){
            int currentCharDmg = 0;
            char[] opa = rawData.toCharArray();
            for (int i = 0; i < opa.length; i++) {
                currentCharDmg = opa[i];
                if (i < opa.length-1){
                    if(opa[i] == 'L'){
                        playerHealth+=200;
                    }
                    else{
                        playerHealth -= currentCharDmg;

                    }
                    if(playerHealth <= 0){
                        isDead = true;
                        System.out.println("Died. Glowcaps: "+counter);
                        break;
                    }
                }

                else if (i == opa.length-1){
                    counter+=Integer.parseInt(String.valueOf(opa[i]));
                }
            }
            rawData = reader.nextLine();
        }
        if(!isDead){
            System.out.println("Health left: " + playerHealth);
            if (counter >= 30){
                System.out.println("Bought the sporebat. Glowcaps left: " + (counter - 30));
            }
            else{
                System.out.println("Safe in Sporeggar, but another " +(30 - counter) + " Glowcaps needed.");
            }
        }

    }
}

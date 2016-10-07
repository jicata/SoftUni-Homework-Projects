/**
 * Created by Maika on 10/28/2015.
 */
public class _01WorkInClass {
    public static void main(String[] args) {
        GameCharacter Kris_Zliq = new Mage("Kris Zliq");
        GameCharacter Stefanof_Trezveniq = new Warrior("Stefanof Trezveniq");
        int roundCount = 0;
        while (true){
            System.out.println("Round: " + ++roundCount);
            try{
                if (roundCount % 2 !=0){
                    Stefanof_Trezveniq.attack(Kris_Zliq);
                    Kris_Zliq.attack(Stefanof_Trezveniq);
                }
                else{
                    Stefanof_Trezveniq.attack(Kris_Zliq);
                    Kris_Zliq.attack(Stefanof_Trezveniq);

                }
            }
            catch (IllegalStateException g){
                System.out.println(g);
                break;
            }
        }
        System.out.println("The battle has concluded!");
        System.out.println("And the winner is...");
        if (Kris_Zliq.getEnergy() > Stefanof_Trezveniq.getEnergy()){
            System.out.println("Kris Zliq!!!");
            System.out.println("Winner winner chicken dinner!");
            System.out.println("Take a few moments to celebrate");
        }
        else{
            System.out.println("Stefanof_Trezveniq!!!");
            System.out.println("Winner winner chicken dinner!");
            System.out.println("Take a few moments to celebrate");
        }



    }
}

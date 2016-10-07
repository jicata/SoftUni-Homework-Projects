import com.sun.javaws.exceptions.InvalidArgumentException;

import java.time.LocalDate;
import java.util.Date;
import java.util.Locale;

/**
 * Created by Maika on 11/1/2015.
 */
public class EverythingOneLevche {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.ADULT);
        Customer krisko = new Customer("Kris_Manqka", 16, 500.0);
        Aplliance arduinoShield = new Aplliance("Wi-Fi Arduino shield", 160.0, 5, AgeRestriction.NONE);
        try {
            PurchaseManager.ProcessPurchase(krisko, cigars);
        } catch (InvalidArgumentException e) {
            e.printStackTrace();
        }


    }
    public static class PurchaseManager {
        public static void ProcessPurchase(Customer customer, Product product) throws InvalidArgumentException{
            int customerAge = customer.getAge();
            double balance = customer.getBalance();
            AgeRestriction ageRestriction = product.getAgeRestriction();
            double productPrice = product.getPrice();
            int productQuantity = product.getQuantity();


            if (productQuantity <= 0){
                throw  new InvalidArgumentException(new String[]{product.getName() + " is out of stock"});
            }
            else if (balance < productPrice ){
                throw new InvalidArgumentException(new String[]{"ei mursho bedna"});
            }
            else if(ageRestriction == AgeRestriction.ADULT && customer.getAgeType() != AgeRestriction.ADULT){
                throw new InvalidArgumentException(new String[]{"You ain't getting none, beat it kid!"});
            }
            else if(product instanceof FoodProduct && ((FoodProduct) product).getExpirationDate().compareTo(LocalDate.now()) > 0 ){
                throw new InvalidArgumentException(new String[]{"MA TOI UMRQL MA!!!"});

            }
            else{
                product.setQuantity(product.getQuantity() -1);
                customer.setBalance(customer.getBalance() - productPrice);
                System.out.println(customer.getName() + " just bought a " +  product.getName());
                System.out.println("We have " +product.getQuantity()+ " " + product.getName() +"s left.");
            }
        }
    }
}

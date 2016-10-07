/**
 * Created by Maika on 11/1/2015.
 */
public class Aplliance extends ElectronicsProduct {
    private final int GUARANTEE_APLIANCE = 6;
    private final int MINIMAL_QUANTITY = 50;

    public Aplliance(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction);

        super.setGuaranteePeriod(this.getGuaranteePeriod());
        CheckQuantity();

    }
    public void CheckQuantity(){
        int quantity = super.getQuantity();
        if (quantity < MINIMAL_QUANTITY){
            super.setPrice(1.05 * this.getPrice());
        }

    }

}

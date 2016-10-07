/**
 * Created by Maika on 10/31/2015.
 */
public class Computer extends  ElectronicsProduct {
    private final int GUARANTEE_COMPUTER = 24;
    private final int QUANTITY_MIN = 1000;
    public Computer(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction);
        super.setGuaranteePeriod(this.GUARANTEE_COMPUTER);
        checkGuarantee();
    }
    public void checkGuarantee(){
        int availableQuantity = super.getQuantity();
        double price = super.getPrice();
        if(availableQuantity > QUANTITY_MIN){
            price = price * 0.95;
            super.setPrice(price);
        }

    }
}

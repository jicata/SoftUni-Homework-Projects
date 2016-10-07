import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;
import java.util.Date;

/**
 * Created by Maika on 10/31/2015.
 */
public class FoodProduct extends Product implements Expirable {
    private LocalDate expirationDate;

    public FoodProduct(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction);
    }
    public FoodProduct(String name, double price, int quantity, AgeRestriction ageRestriction, LocalDate expirationDate) {
        this(name, price, quantity, ageRestriction);
        this.expirationDate = expirationDate;
        this.checkExpirationDate(super.getPrice());

    }



    public void setExpirationDate(LocalDate expirationDate) {
        this.expirationDate = expirationDate;

    }
    @Override
    public LocalDate getExpirationDate() {
        return this.expirationDate;
    }
    public void checkExpirationDate(double price){
        LocalDate currentDate = LocalDate.now();
        LocalDate expirationDate = this.expirationDate;
        long daysTillExpirationDate = ChronoUnit.DAYS.between(currentDate, expirationDate);
        if (daysTillExpirationDate <= 15) {
            double newPrice = price * 0.7;
            super.setPrice(newPrice);
        } else {
            super.setPrice(price);
        }
    }
}

/**
 * Created by Maika on 11/1/2015.
 */
public class Customer {
    private String name;
    private int age;
    private double balance;
    private AgeRestriction ageType;



    public Customer(String name, int age, double balance) {
        this.name = name;
        this.age = age;
        this.balance = balance;
    }
    public AgeRestriction getAgeType() {
        return ageType;
    }

    public void setAgeType(AgeRestriction ageType) {
        if (getAge() < 18){
            this.ageType = AgeRestriction.TEENAGER;
        }
        else{
            this.ageType = AgeRestriction.ADULT;
        }

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public double getBalance() {
        return balance;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }
}

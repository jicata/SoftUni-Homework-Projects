/**
 * Created by Maika on 10/28/2015.
 */
public class Mage extends GameCharacter {
    private static final int BASE_HEALTH = 5000;
    private static final int BASE_POWER = 150;
    private static final int BASE_ENERGY = 2500;
    private static final int BASE_ATTACK_COST = 250;
    public Mage(int health, int power, int energy, int attackCost, String name) {
        super(health, power, energy, attackCost, name);
    }

    public Mage(String name){
        this(BASE_HEALTH,BASE_POWER,BASE_ENERGY,BASE_ATTACK_COST, name);

    }

    @Override
    public void attack(GameCharacter other) {
        boolean isCritical = Math.random() < 0.5;
        if (other == this){
            throw new IllegalStateException("Cannot attack self");
        }
        if(this.getEnergy() < this.getAttackCost()){
           throw new IllegalStateException(this.getName() + " is out of energy. Battle over.");
        }
        int damage = this.getPower();
        if(isCritical){
            System.out.println("Critical hit by the mage!");
            damage = damage*2;

        }
        this.setEnergy( this.getEnergy() - getAttackCost());
        other.respond(damage);

    }

    @Override
    public void respond(int damage) {
        boolean hasTeleported = Math.random() < 0.5;

        if(hasTeleported){
            System.out.println("Eh, too fast!");
        }
        else {
            this.setHealth(this.getHealth() - damage);
            System.out.println("Successful attack. " + damage + " dealt!");
        }


    }

}

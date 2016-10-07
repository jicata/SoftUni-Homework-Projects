/**
 * Created by Maika on 10/29/2015.
 */
public class Warrior extends  GameCharacter {

    private static final int  BASE_HEALTH = 5000;
    private static final int BASE_POWER = 200;
    private static final int BASE_ENERGY = 1000;
    private static final int BASE_ATTACK_COST = 150;




    public Warrior(int health, int power, int energy, int attackCost, String name) {
        super(health, power, energy, attackCost, name);
    }

    public Warrior(String name){
        this(BASE_HEALTH,BASE_POWER,BASE_ENERGY,BASE_ATTACK_COST, name);
    }

    @Override
    public void attack(GameCharacter other) {
        boolean powerSurge = Math.random() < 0.3;
        if (other == this){
            throw new IllegalStateException("Cannot attack self");
        }
        if(this.getEnergy() < this.getAttackCost()){
            throw new IllegalStateException(this.getName() + " is out of energy. Battle over.");
        }
        if (powerSurge){
            System.out.println(this.getName() + " FEEL THE POWER OF MY SWORD. FREE ATTACK.");
        }
        else{
            this.setEnergy(this.getEnergy() - this.getAttackCost());

        }
        other.respond(this.getPower());

    }

    @Override
    public void respond(int damage) {
        boolean shieldBlock = Math.random() < 0.6;
        if(shieldBlock){
            System.out.println("Attack was blocked");
            damage = damage/2;
        }
        this.setHealth(this.getHealth() - damage);
        System.out.println(damage + " damage dealt!");

    }


}

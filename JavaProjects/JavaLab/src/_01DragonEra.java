import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _01DragonEra {
    public static int dragonEra = 0;
    public static int TypeOfYear = 0;
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int startingDragons = Integer.parseInt(reader.nextLine());

        List<Dragon> dragons = new ArrayList<>();
        for (int i = 0; i < startingDragons; i++) {
            Dragon dragon = new Dragon("Dragon_" + (i+1), 0);
            int numberOfEggs = Integer.parseInt(reader.nextLine());

            for (int j = 0; j < numberOfEggs; j++) {
                Egg egg = new Egg(0, dragon);
                dragon.lay(egg);
            }
            dragons.add(dragon);

        }
        dragonEra = startingDragons+1;
        int totalYears = Integer.parseInt(reader.nextLine());
        for (int i = 0; i < totalYears ; i++) {
            String typeOfYear = reader.nextLine();
            YearTypes yearFactor = YearTypes.valueOf(typeOfYear);
            TypeOfYear = yearFactor.ordinal();

            for (Dragon dragon : dragons){
                passAge(dragon);
            }
        }
        for (Dragon drake : dragons){
            System.out.println(drake.name);
            PrintAncestry(drake);

        }
    }
    public static void PrintAncestry(Dragon drake){
        for (Dragon child : drake.children){
            System.out.println("  "+child.name);
        }
    }
    public static void passAge(Dragon dragon){
        dragon.age();
        dragon.lay();
        if(dragon.isAlive){
            for (Egg egg : dragon.eggs){
                egg.age();
                egg.hatch();
            }
            for (Dragon dragoon : dragon.children){
                passAge(dragoon);
            }
        }


    }
        enum YearTypes{
            Bad,
            Normal,
            Good

        }
        public static class Dragon{
            boolean isAlive = true;
            public static final int AGE_DEATH = 6;
            public static final int LAY_EGG_START = 3;
            public static final int LAY_EGG_END = 4;

            String name;

            int age;
            List<Egg> eggs = new ArrayList<>();
            List<Dragon> children = new ArrayList<>();
            public Dragon(String name, int age){
                this.name = name;
                this.age = age;
            }
            public void lay(Egg egg){
                this.eggs.add(egg);
            }
            public void age(){
                if(this.isAlive){
                    this.age++;
                }
                if(this.age == AGE_DEATH){
                    this.isAlive = false;
                }
            }
            public void lay(){
                if(this.age >= LAY_EGG_START && this.age <= LAY_EGG_END){
                    Egg egg = new Egg(-1, this);
                    this.eggs.add(egg);
                }
            }
            public void increaseOffspring(Dragon drake){
                this.children.add(drake);
            }



        }
        public static class Egg{
            int age;
            Dragon parent;
            public static final int AGE_HATCH = 2;


            public Egg(int age, Dragon parent){
                this.age = age;
                this.parent = parent;
            }
            public void age(){
                this.age++;
            }
            public void hatch(){

                if (this.age == AGE_HATCH){
                    for (int i = 0; i < TypeOfYear ; i++) {
                        Dragon babyDragon = new Dragon(this.parent.name +"/" + "Dragon_" + _01DragonEra.dragonEra, -1);
                        this.parent.increaseOffspring(babyDragon);
                        dragonEra++;
                    }

                }




            }




        }



    }







import java.util.*;

/**
 * Created by Maika on 11/10/2015.
 */
public class _RandomVladkosNotebook {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        TreeMap<String, Player> vladkoNotebook = new TreeMap<>();
        String rawData = reader.nextLine();

        while(!rawData.equals("END")){
            String[] specificData = rawData.split("\\|");
            String color = specificData[0];
            if(!vladkoNotebook.containsKey(color)){
                vladkoNotebook.put(color, new Player(-1, "", new ArrayList<String>(),0,0,0));
            }
            if(specificData[1].equals("win") || specificData[1].equals("loss")){
                String opponent = specificData[2];
                if(specificData[1].equals("win")){

                    Player player = vladkoNotebook.get(color);
                    player.wins ++;
                    player.opponents.add(opponent);
                    vladkoNotebook.put(color, player);
                }
                else {

                    Player player = vladkoNotebook.get(color);
                    player.losses ++;
                    player.opponents.add(opponent);
                    vladkoNotebook.put(color,player);

                }

            }
            else if(specificData[1].equals("name") || specificData[1].equals("age")){
                if (specificData[1].equals("name")){
                    String name = specificData[2];
                    Player player = vladkoNotebook.get(color);
                    player.name = name;
                    vladkoNotebook.put(color, player);
                }
                else{
                    int age = Integer.parseInt(specificData[2]);
                    Player player = vladkoNotebook.get(color);
                    player.age = age;
                    vladkoNotebook.put(color, player);
                }
            }


            rawData = reader.nextLine();

        }

        boolean theresData = false;
        for(Map.Entry<String, Player> players : vladkoNotebook.entrySet()){
            String key = players.getKey();
            Player player = players.getValue();
            if(!vladkoNotebook.get(players.getKey()).name.equals("") && vladkoNotebook.get(players.getKey()).age!=-1){
                theresData = true;
                System.out.println("Color: " +players.getKey());
                System.out.println("-age: " + vladkoNotebook.get(key).age);
                System.out.println("-name: " + vladkoNotebook.get(key).name);
                System.out.print("-opponents: ");
                if(vladkoNotebook.get(key).opponents.size() <= 0){
                    System.out.print("(empty)");
                    System.out.println();
                }
                else{

                    Collections.sort(vladkoNotebook.get(key).opponents);
                    for (int i = 0; i < vladkoNotebook.get(key).opponents.size() ; i++) {
                        if(i<vladkoNotebook.get(key).opponents.size()-1 )
                        System.out.print(vladkoNotebook.get(key).opponents.get(i) +", ");
                        else{
                            System.out.print(vladkoNotebook.get(key).opponents.get(i));
                        }

                    }
                    System.out.println();
                }
                double losses = vladkoNotebook.get(key).losses+1;
                double wins = vladkoNotebook.get(key).wins +1;
                double rank = wins / losses;
                System.out.printf("-rank: %.2f", rank);
                System.out.println();

//                -age: 99
//                -name: VladoKaramfilov
//                -opponents: Kiko, Kiko, Kiko, Manov, Manov, Yana, Yana, Yana
              //  && vladkoNotebook.get(key).opponents.size() >1//



            }
        }
        if(!theresData){
            System.out.println("No data recovered.");
        }


    }
    public static class Player{
        //String color;
        int age;
        String name;
        List<String> opponents = new ArrayList<>();
        int wins;
        int losses;
        int rank;

        public Player(int age, String name, List<String> opponents, int wins, int losses, int rank) {
            this.rank = rank;

            this.age = age;
            this.name = name;
            this.opponents = opponents;
            this.wins = wins;
            this.losses = losses;
        }
    }
}




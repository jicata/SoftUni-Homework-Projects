package kur;

import java.util.Scanner;

/**
 * Created by Maika on 10/14/2015.
 */
public class _07GhettoNumbers {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String userInput = reader.next();
        String maManDrizzle = "";
        for (int i = 0; i <userInput.length() ; i++) {
            char[] aha = userInput.toCharArray();
            int number = Integer.parseInt(Character.toString(aha[i]));
            switch (number) {
                case 0 : maManDrizzle+="Gee";
                    break;
                case 1 : maManDrizzle+="Bro";
                    break;
                case 2 : maManDrizzle+="Zuz";
                    break;
                case 3 : maManDrizzle+="Ma";
                    break;
                case 4: maManDrizzle+="Duh";
                    break;
                case 5: maManDrizzle+="Yo";
                    break;
                case 6: maManDrizzle+="Dis";
                    break;
                case 7: maManDrizzle+="Hood";
                    break;
                case 8: maManDrizzle+="Jam";
                    break;
                case 9: maManDrizzle+="Mack";
                    break;
            }
        }
        System.out.println(maManDrizzle);


    }
}

package kur;

import java.util.Scanner;

/**
 * Created by Maika on 10/12/2015.
 */
public class _05PrintChar {
    public static void main(String[] args) {
        Scanner mainaBrat = new Scanner(System.in);
        int input = mainaBrat.nextInt();
        if (input > 26) {
            input = 26;
        }
        for (int i = 0; i < (input*2) -1; i++) {
            char Bo = 'a';
            if (i < input){

                for (int j = 0; j <i +1 ; j++) {
                    System.out.print(Bo + " ");
                    Bo++;
                }
            }
            else {
                for (int j = (input*2) - i-1; j > 0 ; j--) {
                    System.out.print(Bo + " ");
                    Bo++;
                }
            }
            System.out.println();
        }
    }
}

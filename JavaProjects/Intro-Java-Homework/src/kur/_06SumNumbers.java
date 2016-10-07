package kur;

import java.util.Scanner;

/**
 * Created by Maika on 10/14/2015.
 */
public class _06SumNumbers {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int sum = 0;
        int input = reader.nextInt();
        for (int i = 0; i <= input; i++) {
            sum+= i;
        }
        System.out.println(sum);
    }
}

package kur;

import java.util.Scanner;

/**
 * Created by Maika on 10/14/2015.
 */
public class _8GetAverage {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        float a = reader.nextFloat();
        float b = reader.nextFloat();
        float c = reader.nextFloat();
        //String result = String.format("%.2f", AverageUp(a,b,c));
        System.out.printf("%.2f", AverageUp(a,b,c));


    }
    public  static float AverageUp(float a, float b , float c){
        float average = 0;
        average = (a+b+c)/3;
        return average;
    }
}

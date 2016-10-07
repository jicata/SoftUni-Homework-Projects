import java.util.Scanner;

/**
 * Created by Maika on 10/26/2015.
 */
public class _Exam01StuckNumbers {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int count = Integer.parseInt(reader.nextLine());
        String[] rawData = reader.nextLine().split(" ");
        int[] numberArray = new int[rawData.length];
        boolean match = false;
        for (int i = 0; i < rawData.length ; i++) {
            numberArray[i] = Integer.parseInt(rawData[i]);
        }
        for (int i = 0; i < rawData.length ; i++) {
            String a = rawData[i];
            for (int j = 0; j < rawData.length ; j++) {
               String b = rawData[j];
                if (b.equals(a))
                {
                    continue;
                }
                else{
                    for (int k = 0; k < rawData.length ; k++) {
                        String c = rawData[k];
                        if (c.equals(a) || c.equals(b)){
                            continue;
                        }
                        else{
                            for (int l = 0; l < rawData.length ; l++) {
                                String d = rawData[l];
                                if(d.equals(a) || d.equals(b) || d.equals(c)){
                                    continue;
                                }
                                else{
                                    if ((a+b).equals(c+d)){
                                        match = true;
                                        System.out.printf("%s|%s==%s|%s",a,b,c,d);
                                        System.out.println();
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        if(match == false){
            System.out.println("No");
        }
    }
}

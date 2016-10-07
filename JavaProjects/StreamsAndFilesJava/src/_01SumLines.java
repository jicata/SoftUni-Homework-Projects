import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;

/**
 * Created by Maika on 10/20/2015.
 */
public class _01SumLines {
    public static void main(String[] args) {
        String readingPath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\SumLinesRead.txt";
        File littleTxtFile = new File(readingPath);
        try (
                BufferedReader reader = new BufferedReader(new FileReader(littleTxtFile));
        ){
            String line = reader.readLine();
            while(line!= null){
                char[] closerLook = line.toCharArray();
                int ascii = 0;
                for (int i = 0; i < closerLook.length ; i++) {

                    ascii += closerLook[i];
                }
                System.out.println(ascii);

                line = reader.readLine();
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}

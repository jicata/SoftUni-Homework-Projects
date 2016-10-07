import java.io.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Maika on 10/20/2015.
 */
//are drunk again
public class _02ALLCaptains {
    public static void main(String[] args) {
        String path = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\ALLCAPITalS.txt";
         File aFile = new File(path);
        try(
                BufferedReader bfr = new BufferedReader(new FileReader(path));




        ) {
            String line = bfr.readLine();
            List<String> allTheLines = new ArrayList<String>();
            while(line!=null){
                String allCapital = line.toUpperCase();
                allTheLines.add(allCapital);


                line = bfr.readLine();

            }


            FileWriter writer = new FileWriter(aFile);
            PrintWriter actualWriter = new PrintWriter(writer, true);
            for (int i = 0; i < allTheLines.size() ; i++) {

               actualWriter.println(allTheLines.get(i));
                System.out.println(allTheLines.get(i));
            }
            actualWriter.close();
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}

import java.io.*;

/**
 * Created by Maika on 10/20/2015.
 */
public class _04CopyJPG {
    public static void main(String[] args) {
        String inputpath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\Cat.jpg";
        String outputPath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\CatCat.jpg";
        File input = new File(inputpath);
        File output = new File(outputPath);
        try (
                FileInputStream reader = new FileInputStream(input);
                FileOutputStream writer = new FileOutputStream(output);
        ){
            byte[] buffer = new byte[4096];
            while(true){
                int kappa = reader.read(buffer);
                if (kappa == -1){
                    break;
                }
                writer.write(buffer,0,kappa);

            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

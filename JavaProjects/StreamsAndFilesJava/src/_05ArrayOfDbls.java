import java.io.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Maika on 10/20/2015.
 */
public class _05ArrayOfDbls {
    public static void main(String[] args) {
        String savePath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\doubles.list";
        String readFromPath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\doubles.list";
        File file = new File(savePath);
        List<Double> highscore = new ArrayList<>();
        highscore.add(3.14);
        highscore.add(13.37);
        highscore.add(9.11);
        highscore.add(4.20);
        highscore.add(6.9);

        try (
                ObjectOutputStream objectWriter = new ObjectOutputStream(new FileOutputStream(file));
                ObjectInputStream objectReader = new ObjectInputStream(new FileInputStream(file));
        ){
            objectWriter.writeObject(highscore);
            System.out.println("High score " + objectReader.readObject());





        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}

import com.sun.javafx.binding.StringFormatter;

import java.io.*;

/**
 * Created by Maika on 10/19/2015.
 */
public class _01DunnoYet {
    public static void main(String[] args) {
        String readPath ="C:/Users/Maika/Desktop/softa we/java/java FUNdamentals/readingFiles/users.txt";
        String writePath ="C:/Users/Maika/Desktop/softa we/java/java FUNdamentals/readingFiles/results.txt";
        File file = new File(readPath);
        File newFile = new File(writePath);
        try (
                BufferedReader reader = new BufferedReader(new FileReader(file));
                PrintWriter writer = new PrintWriter(new FileWriter(newFile), true);
        )
        {
            String line = reader.readLine();
            while(line!= null){

                String[] individualTimes = line.split(" ");
                int totalMinutes = 0;
                for (int i = 1; i <individualTimes.length ; i++) {
                    String[] hoursAndMinutes = individualTimes[i].split(":");
                    int hours = Integer.parseInt(hoursAndMinutes[0]);
                    int minutes = Integer.parseInt(hoursAndMinutes[1]);
                    totalMinutes += (hours*60) + minutes;
                }
                int totalHours = totalMinutes / 60;
                int finalMinutes = totalMinutes % 60;

                String output = String.format("%s %d %d", individualTimes[0], totalHours, finalMinutes);
                writer.println(output);




                line = reader.readLine();
            }

        }
        catch (Exception e) {
            e.printStackTrace();
        }

    }

}

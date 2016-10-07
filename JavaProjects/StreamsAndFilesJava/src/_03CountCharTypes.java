import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Maika on 10/20/2015.
 */
public class _03CountCharTypes {
    public static void main(String[] args) {
        String inputPath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\words.txt";
        String outputPath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\count-chars.txt";
        File input = new File(inputPath);
        File output = new File(outputPath);
        Pattern pattern = Pattern.compile("([aeiou])|([^\\s,\\.\\?aeoui])|([\\.\\?,])");

        try (
                BufferedReader reader = new BufferedReader(new FileReader(input));
        ){
            String line = reader.readLine();
            StringBuilder fullText = new StringBuilder();
            while (line!= null){
                fullText.append(line);
                line = reader.readLine();
            }
            String textBro = fullText.toString();
            Matcher matcher = pattern.matcher(textBro);
            String vowels = " ";
            String consonats = " ";
            String other = " ";
            while(matcher.find()){
                if(matcher.group(1) != null){
                    vowels += matcher.group(1);
                }
                if (matcher.group(2) != null){
                    consonats += matcher.group(2);
                }
                if (matcher.group(3) != null){
                    other += matcher.group(3);
                }
            }

            FileWriter fw = new FileWriter(output);
            PrintWriter writer = new PrintWriter(fw);
            writer.println("Vowels: " + (vowels.length() -1));
            writer.println("Consonants: " + (consonats.length() -1));
            writer.println("Punctuation: " + (other.length() -1));


            writer.close();

        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}

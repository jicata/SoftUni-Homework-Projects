import javax.imageio.stream.FileCacheImageInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

/**
 * Created by Maika on 10/21/2015.
 */
public class _07ZipArchive {
    public static void main(String[] args) {
        String pathWords = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\words.txt";
        String pathLines = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\SumLinesRead.txt";
        String pathChars = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\count-chars.txt";
        String[] paths = {pathWords, pathLines, pathChars};
        String zipPath = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\text-files.zip";
        File endGame = new File(zipPath);

        try(
                FileOutputStream outputter = new FileOutputStream(zipPath);
                ZipOutputStream zipper = new ZipOutputStream(outputter);

        ) {
            byte[] buffer = new byte[4096];
            for (int i = 0; i <paths.length ; i++) {
                File file = new File(paths[i]);
                FileInputStream inputter = new FileInputStream(file);
                zipper.putNextEntry(new ZipEntry(file.getName()));
                int length;
                while(true){
                    length = inputter.read(buffer, 0, buffer.length);
                    if (length < 0){
                        break;
                    }
                    zipper.write(buffer, 0, length);
                }
                zipper.closeEntry();
            }


        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}

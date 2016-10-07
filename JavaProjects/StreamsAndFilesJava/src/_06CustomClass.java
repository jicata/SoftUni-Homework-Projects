import java.io.*;
import java.io.Serializable;
public class _06CustomClass {

    public static void main(String[] args) {
        String path = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\writingFiles\\course.save";
        File file = new File(path);
        Course Sept2015 = new Course();
        Sept2015.name = "Fundamentals";
        Sept2015.students = 450;
        try(
                ObjectOutputStream writer = new ObjectOutputStream(new FileOutputStream(file));
                ObjectInputStream reader = new ObjectInputStream(new FileInputStream(file));
        ) {
            writer.writeObject(Sept2015);


            Course aha = (Course) reader.readObject();

            System.out.println(aha.name);
            System.out.println(aha.students);


        } catch (Exception e) {
            e.printStackTrace();
        }

    }


    public static  class Course implements Serializable {
        private String name;
        private Integer students;



    }
}


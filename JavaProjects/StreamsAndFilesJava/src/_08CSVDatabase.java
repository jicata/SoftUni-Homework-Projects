import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Maika on 10/21/2015.
 */
//DISCLAIMER!!!!
    // decided to fuck around a bit with this one last problem
    // created a class to hold all the students' info in order
    // to manipulate the data tad bit easier
    // code may be hard to read, but I've employed pretty much
    // the same approach as the one we've already used
    // in the Functional Programming class in Advanced C#
    // enjoy
public class _08CSVDatabase {
    public static void main(String[] args) {
        String pathStudents ="C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\students.txt";
        String pathGrades = "C:\\Users\\Maika\\Desktop\\softa we\\java\\java FUNdamentals\\readingFiles\\grades.txt";
        File studentsFile = new File(pathStudents);
        File gradesFile = new File(pathGrades);
        Scanner consoleReader = new Scanner(System.in);
        List<Student> students = new ArrayList<Student>();


        try(
            BufferedReader studentsReader = new BufferedReader(new FileReader(studentsFile));
            BufferedReader gradesReader = new BufferedReader(new FileReader(gradesFile));

        ) {

            String lineSt = studentsReader.readLine();
            String lineGr = gradesReader.readLine();
            lineSt = studentsReader.readLine();
            lineGr = gradesReader.readLine();
            while(lineSt != null){
                //reading from students.txt
                String[] studentDetails = lineSt.split(",");
                String[] gradesDetails = lineGr.split(",");
                int id = Integer.parseInt(studentDetails[0]);
                String firstName = studentDetails[1];
                String lastName = studentDetails[2];
                int age = Integer.parseInt(studentDetails[3]);
                String homeTown = studentDetails[4];

                //reading from grades.txt
                String[] course1AndGrades = gradesDetails[1].split(" ");
                String courseName = course1AndGrades[0];
                HashMap<String, ArrayList<Double>> course1 = new HashMap<>();
                course1.put(courseName,new ArrayList<>());
                for (int i = 1; i < course1AndGrades.length ; i++) {
                    course1.get(courseName).add(Double.parseDouble(course1AndGrades[i]));
                }
                List<Double> grades = new ArrayList<>();
                for (int i = 1; i < course1AndGrades.length ; i++) {
                    grades.add(Double.parseDouble(course1AndGrades[i]));
                }
                String[] course2AndGrades = gradesDetails[2].split(" ");
                String course2Name = course2AndGrades[0];
                List<Double> grades2 = new ArrayList<>();
                for (int i = 1; i < course2AndGrades.length ; i++) {
                    grades2.add(Double.parseDouble(course2AndGrades[i]));
                }

                //putting all the studentsInfo in a list of Student
                students.add(new Student(
                        id,
                        firstName,
                        lastName,
                        age,
                        homeTown,
                        course1,
                        course2Name,
                        grades2

                ));

                lineSt = studentsReader.readLine();
                lineGr = gradesReader.readLine();
            }
            // using user Input to traverse our database
            String userInput = consoleReader.nextLine();
            while(!userInput.equals("end")){
                String[] userCommands = userInput.split(" ");
                if(userCommands[0].equals("Search")){
                    if (userCommands[2].equals("full")){
                        SearchByFullName(students, userCommands[4], userCommands[5]);
                    }
                    if (userCommands[2].equals("id")){
                        SearchById(students, Integer.parseInt(userCommands[3]));
                    }
                }
                if(userCommands[0].equals("Delete")){
                    DeleteById(students,Integer.parseInt(userCommands[3]));
                }

                if (userCommands[0].equals("Insert")){
                    if (userCommands[1].equals("student")){
                        String firstName = userCommands[2];
                        String lastName = userCommands[3];
                        int age = Integer.parseInt(userCommands[4]);
                        String townName = userCommands[5];
                        if(userCommands.length>6){
                            townName += " "+userCommands[6];
                        }
                        students.add(InsertStudentByName(students, firstName, lastName, age, townName));
                    }
                    if(userCommands[1].equals("grade")){
                        int id = Integer.parseInt(userCommands[4]);
                        String courseName = userCommands[5];
                        double grade = Double.parseDouble(userCommands[6]);
                        InsertGradeById(students,id,courseName,grade);

                    }
                }
                //since it's not quite clear
                //what the "Update" command
                //is supposed to do
                //I figured I'd use it to
                //update the final file

                if(userCommands[0].equals("Update")){
                    PrintWriter studentWriter = new PrintWriter(new FileWriter(studentsFile));
                    PrintWriter gradesWriter = new PrintWriter(new FileWriter(gradesFile));
                    studentWriter.println("ID,FirstName,LastName,Age,Home-town");
                    gradesWriter.println("ID,Course1 grades, Course2 grades");

                    for (int i = 0; i < students.size(); i++) {
                        String eachLineStudens = String.format("%d,%s,%s,%d,%s",
                                students.get(i).getStudentId(),
                                students.get(i).getFirstName(),
                                students.get(i).getLastName(),
                                students.get(i).getAge(),
                                students.get(i).getHomeTown());
                        studentWriter.println(eachLineStudens);
                       // String IdAndCourseName = String.format("%d,%s", students.get(i).getStudentId(),students.get(i).getCourse1Name());
                        gradesWriter.println(students.get(i).getStudentId() + (students.get(i).getCourse1() + " " + students.get(i).course2Name + " " + students.get(i).getCourse2Grades()));
                        studentWriter.flush();
                        gradesWriter.flush();



                    }
                    studentWriter.close();
                    gradesWriter.close();



                }

                userInput = consoleReader.nextLine();
            }
            for (Student person : students){
                System.out.println(person.getFirstName());
               // System.out.println(person.getCourse1Grades());
            }



        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public static class Student {

        int studentId;
        String firstName;
        String lastName;
        int age;
        String  homeTown;
        HashMap<String, ArrayList<Double>> course1; //using a HashMap is one way to aggregate course name and grades
        String course2Name;
        List<Double> course2Grades; // using a String and a List is another
        public Student(
                int studentId,
                String firstName,
                String lastName,
                int age,
                String  homeTown,
                HashMap<String, ArrayList<Double>> course1,
                String course2Name,
                List<Double> course2Grades
        ){
            this.setStudentId(studentId);
            this.setFirstName(firstName);
            this.setLastName(lastName);
            this.setAge(age);
            this.setHomeTown(homeTown);
            this.setCourse1(course1);
            this.setCourse2Name(course2Name);
            this.setCourse2Grades(course2Grades);

        }

        public void setStudentId(int studentId) {
            this.studentId = studentId;
        }

        public int getStudentId() {
            return studentId;
        }

        public void setFirstName(String s){
            this.firstName = s;
        }
        public String getFirstName(){
            return firstName;
        }
        public void setLastName(String lastName){
            this.lastName = lastName;
        }
        public String getLastName(){
            return lastName;
        }
        public void setAge(int n){
            this.age = n;
        }
        public int getAge(){
            return age;
        }
        public void setHomeTown(String homeTown){
            this.homeTown = homeTown;
        }
        public String getHomeTown(){
            return homeTown;
        }
        public void setCourse1(HashMap<String,ArrayList<Double>> course){
            this.course1 = course;
        }
        public HashMap<String, ArrayList<Double>> getCourse1(){
            return course1;
        }
        public void setCourse2Name(String courseName){
            this.course2Name = courseName;
        }
        public  String getCourse2Name(){
            return  course2Name;
        }
        public  void setCourse2Grades(List<Double> courseGrades){
            this.course2Grades = courseGrades;
        }
        public List<Double> getCourse2Grades(){
            return course2Grades;
        }



    }
    public static void SearchByFullName(List<Student> students, String firstName, String lastName){
        boolean found = false;
        for (int i = 0; i <students.size() ; i++) {
            if (students.get(i).getFirstName().equals(firstName) && students.get(i).getLastName().equals(lastName)){
                found = true;
                String nameFirst = students.get(i).getFirstName();
                String nameLast = students.get(i).getLastName();
                int age = students.get(i).getAge();
                String town = students.get(i).getHomeTown();
                HashMap<String, ArrayList<Double>> course1 = students.get(i).getCourse1();
                String courseName2 = students.get(i).getCourse2Name();
                List<Double> course2Grades = students.get(i).getCourse2Grades();
                String fullName = String.format("%s %s (age: %d, town: %s)", nameFirst, nameLast,age,town);

                String course2AndGrades = courseName2;
                System.out.println(fullName);
                System.out.println("# " + students.get(i).getCourse1());
                System.out.println("# " + course2AndGrades + ": " + course2Grades);
                return;
            }
        }
        if(found == false){
            System.out.println("Student not found");
            return;
        }
    }
    public static void SearchById(List<Student> students, int ID){
        boolean found = false;
        for (int i = 0; i <students.size() ; i++) {
            if (students.get(i).getStudentId() == ID){
                found = true;
                String nameFirst = students.get(i).getFirstName();
                String nameLast = students.get(i).getLastName();
                int age = students.get(i).getAge();
                String town = students.get(i).getHomeTown();
                HashMap<String, ArrayList<Double>> course1 = students.get(i).getCourse1();
                String courseName2 = students.get(i).getCourse2Name();
                List<Double> course2Grades = students.get(i).getCourse2Grades();
                String fullName = String.format("%s %s (age: %d, town: %s)", nameFirst, nameLast,age,town);

                String course2AndGrades = courseName2;
                System.out.println(fullName);
                System.out.println("# " + students.get(i).getCourse1());
                System.out.println("# " + course2AndGrades + ": " + course2Grades);
                return;
            }
        }
        if(found == false){
            System.out.println("Student not found");
            return;
        }
    }
    public static void DeleteById(List<Student> students, int ID){
        boolean found = false;
        for (int i = 0; i < students.size() ; i++) {
            if(students.get(i).getStudentId() == ID){
                found = true;
                students.remove(i);
            }
        }
        if (found = false){
            System.out.println("Student not found");
        }

    }
    public static Student InsertStudentByName(List<Student> students, String firstName, String lastName, int age, String homeTown){
        int maxId = Integer.MIN_VALUE;
        for (int i = 0; i <students.size(); i++) {
            if (students.get(i).getStudentId() > maxId){
                maxId = students.get(i).getStudentId();
            }
        }
        Student person = new Student(
                maxId + 1,
                firstName,
                lastName,
                age,
                homeTown,
                new HashMap<>(),
                "Rakia",
                new ArrayList<Double>()
        );
        person.course1.put("Skara", new ArrayList<Double>());

        return person;

    }
    public static void InsertGradeById(List<Student> students, int id, String courseName, double grade){
        boolean flag = false;
        for (int i = 0; i <students.size() ; i++) {
            if (students.get(i).getStudentId() == id){
                flag = true;
                if(students.get(i).getCourse1().containsKey(courseName)){
                    students.get(i).getCourse1().get(courseName).add(grade);
                }
                else if(students.get(i).getCourse2Name().equals(courseName)){
                    students.get(i).course2Grades.add(grade);
                }
            }
        }
        if (flag == false){
            System.out.println("Student does not exist");
        }
    }



}



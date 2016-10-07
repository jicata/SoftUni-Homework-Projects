import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _01DSharp {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        int numberOfLines = Integer.parseInt(reader.nextLine());
        Pattern stringCheck = Pattern.compile("(?:\"(.+)\";)");
        boolean lastIf = false;
        boolean flag = false;
        List<String> statements = new ArrayList<>();
        for (int i = 0; i < numberOfLines; i++) {
            String userInput = reader.nextLine();
            String[] userCommands = userInput.split(" ");
            Matcher stringMatch = stringCheck.matcher(userInput);
            if (stringMatch.find()) {
                if (userCommands[0].equals("if")) {
                    if (userCommands[2].equals("out")) {
                        String properString= stringMatch.group(1);;
                        Pattern pattern = Pattern.compile("\\((\\d+)(\\W+)(\\d+)\\)");
                        Matcher matcher = pattern.matcher(userInput);
                        int firstNumber = 0;
                        int secondNumber = 0;
                        String operator = "";
                        while (matcher.find()) {
                            if(matcher.group(1) != null){
                                firstNumber = Integer.parseInt(matcher.group(1));
                            }
                            if(matcher.group(3) != null){
                                secondNumber = Integer.parseInt(matcher.group(3));
                            }
                            if(matcher.group(2) != null){
                                operator = matcher.group(2);
                            }

                        }
                        if (operator.equals(">") && firstNumber > secondNumber) {


                            statements.add(properString);

                            lastIf = true;
                        }
                        else if (operator.equals("<") && firstNumber < secondNumber ) {

                            statements.add(properString);
                            lastIf = true;
                        }
                        else if (operator.equals("==") && firstNumber == secondNumber) {

                            statements.add(properString);
                            lastIf = true;
                        }
                        else {
                            lastIf = false;
                        }
                    }

                    if (userCommands[2].equals("loop")) {
                        String properString= stringMatch.group(1);

                        Pattern pattern = Pattern.compile("\\((\\d+)(\\W+)(\\d+)\\)");
                        Matcher matcher = pattern.matcher(userInput);
                        int loopCounter = Integer.parseInt(userCommands[3]);
                        int firstNumber = 0;
                        int secondNumber = 0;
                        String operator = "";
                        while (matcher.find()) {
                            if(matcher.group(1) != null){
                                firstNumber = Integer.parseInt(matcher.group(1));
                            }
                            if(matcher.group(3) != null){
                                secondNumber = Integer.parseInt(matcher.group(3));
                            }
                            if(matcher.group(2) != null){
                                operator = matcher.group(2);
                            }

                        }
                        if (operator.equals(">") && firstNumber > secondNumber) {

                                for (int j = 0; j < loopCounter ; j++) {
                                    statements.add(properString);
                                }
                                lastIf = true;
                        }
                        else if (operator.equals("<") && firstNumber < secondNumber ) {

                                for (int j = 0; j < loopCounter ; j++) {
                                    statements.add(properString);
                                }
                                lastIf = true;
                        }
                        else if (operator.equals("==") && firstNumber == secondNumber) {

                                for (int j = 0; j < loopCounter ; j++) {
                                    statements.add(properString);
                                }
                                lastIf = true;
                        }
                        else{
                            lastIf = false;
                        }

                    }
                }

                if (userCommands[0].equals("else") && !lastIf) {
                    String properString= stringMatch.group(1);
                    if(userCommands[1].equals("out")){
                        statements.add(properString);


                    }
                    if(userCommands[1].equals("loop")){
                        int loopTimes = Integer.parseInt(userCommands[2]);
                        for (int j = 0; j <loopTimes ; j++) {
                            statements.add(properString);
                        }

                    }

                }

            }
            else {
                System.out.println("Compile time error @ line " + (i+1));
                flag = true;
                break;

            }

        }
        if(!flag){
            for (int i = 0; i < statements.size(); i++) {
                System.out.println(statements.get(i));
            }
        }

        }

    }


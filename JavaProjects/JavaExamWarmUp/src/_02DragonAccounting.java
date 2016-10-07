import javax.print.DocFlavor;
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.Deque;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

/**
 * Created by Maika on 10/27/2015.
 */
public class _02DragonAccounting {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        BigDecimal startingCapital = new BigDecimal(reader.nextLine());
        Deque<Worker> workers = new LinkedList<>();
        int dayInMonth = 1;
        int monthCount = 0;
        boolean flag = false;
        String corporateInfo = reader.nextLine();
        while(!corporateInfo.equals("END")) {

            String[] daysOrders = corporateInfo.split(";");
            long hiredWorkers = Integer.parseInt(daysOrders[0]);
            BigDecimal salary = new BigDecimal(daysOrders[2]);
            for (int i = 0; i < hiredWorkers; i++) {
                Worker worker = new Worker(salary, dayInMonth, 0);
                workers.add(worker);
            }
            RaiseUp(workers);
            if(dayInMonth == 30){
                for (Worker worker : workers){

                    BigDecimal totalWorkingDaysMonth = new BigDecimal(30).subtract(new BigDecimal(worker.dayOfHire-1));
                    BigDecimal totalSalary = worker.salary.divide(new BigDecimal(30), 9,RoundingMode.UP).setScale(7, RoundingMode.DOWN).multiply(totalWorkingDaysMonth);
                    startingCapital =  startingCapital.subtract(totalSalary);
                    worker.dayOfHire = 1;

                }
            }

            long firedWorkers = Integer.parseInt(daysOrders[1]);
            for (int i = 0; i < firedWorkers; i++) {
                workers.remove();
            }

            for (int i = 3; i < daysOrders.length ; i++) {
                String[] extraActivities = daysOrders[i].split(":");
                String event = extraActivities[0];

                BigDecimal eventMoney = new BigDecimal(extraActivities[1]);
                if (event.equals("Product development") || event.equals("Unconditional funding")){
                    startingCapital = startingCapital.add(eventMoney);
                }
                else{
                    startingCapital = startingCapital.subtract(eventMoney);
                }

            }
            if (startingCapital.compareTo(new BigDecimal(0)) < 0){

                DecimalFormat df = new DecimalFormat("#.####");
                df.setRoundingMode(RoundingMode.DOWN);
                System.out.println("BANKRUPTCY: " + startingCapital.setScale(4,RoundingMode.DOWN).abs());
                flag = true;
                break;
            }
//            System.out.println(dayInMonth);
//            DecimalFormat df = new DecimalFormat("#.####");
//            df.setRoundingMode(RoundingMode.DOWN);
//            System.out.println(df.format(Math.abs(KarlMarx.totalCapital)));

            if(dayInMonth == 30){
                dayInMonth = 1;
                monthCount++;
            }
            else{
                dayInMonth++;
            }
            for (Worker worker : workers){
                worker.tenureInDays++;
            }


            corporateInfo = reader.nextLine();
        }
        if(!flag){

            DecimalFormat df = new DecimalFormat("#.####");
            df.setRoundingMode(RoundingMode.DOWN);
            //Double trunc = Math.floor((KarlMarx.totalCapital * 10000)/10000);
            System.out.println(workers.size() + " " + startingCapital.setScale(4, RoundingMode.DOWN));
        }
    }


    public  static class Worker{
        BigDecimal salary;
        int dayOfHire;
        int tenureInDays;
        public Worker(BigDecimal salary, int dayOfHire, int tenureInDays){
            this.salary = salary;
            this.dayOfHire = dayOfHire;
            this.tenureInDays = tenureInDays;
        }
    }

    public static void RaiseUp(Deque<Worker> workers){
        BigDecimal regularRaise = new BigDecimal(1.006);
        for (Worker worker : workers){
            if(worker.tenureInDays % 365 ==0 && worker.tenureInDays!=0){
                worker.salary = worker.salary.multiply(regularRaise);
            }

        }
    }
}

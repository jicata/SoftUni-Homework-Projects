/*jshint esversion: 6 */
function calendar([day,month,year]){
    [day,month,year] = [day,month,year].map(Number);
    let date = new Date(year,month-1, day);
    let days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];



    let totalDaysOfLastMonth = new Date(year,month-1,0).getDate();
    let totalDaysOfCurrentMonth = new Date(year, month, 0).getDate();
    let totalDaysOfNextMonth = new Date(year,month+1,0).getDate();


    let firstDayOfCurrentMonth = days[new Date(year, month-1, 1).getDay()];
    let isPrevMonth = false;
    let startDayOfPrevMonth;
    if(firstDayOfCurrentMonth !="Sunday"){
        isPrevMonth = true;
        for(let day=totalDaysOfLastMonth; day>=0; day--){
            startDayOfPrevMonth = days[new Date(year, month-2, day).getDay()];

            if(startDayOfPrevMonth=="Sunday"){
                startDayOfPrevMonth = day;
                break;
            }
        }
    }

    let lastDayOfCurrentMonth = days[new Date(year, month, 0).getDay()];
    let endDayOfNextMonth;

    if(lastDayOfCurrentMonth!="Saturday") {
        for (let day = 1; day <= totalDaysOfNextMonth; day++) {
            endDayOfNextMonth = days[new Date(year, month, day).getDay()];
            if (endDayOfNextMonth == "Saturday") {
                endDayOfNextMonth = day;
                break;
            }
        }
    }

    let totalDays = 0;
    if(startDayOfPrevMonth!=undefined){
        totalDays += totalDaysOfLastMonth-startDayOfPrevMonth+1;
    }
    if(endDayOfNextMonth!=undefined){
        totalDays += endDayOfNextMonth;
    }
    totalDays+= totalDaysOfCurrentMonth;
    let totalRows = totalDays / 7;


    let monthCounter = 1;
    let nextMonthCounter = 1;
    let isNextMonth=false;
    let htmlToReturn = "<table>";
    htmlToReturn+="<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>"
    for(let row = 0; row < totalRows; row++){
        let calendarRow = "<tr>";
        for(let col=0;col<7;col++){
            if(isNextMonth){
                calendarRow +=`<td class="next-month">${nextMonthCounter}</td>`
                nextMonthCounter++;
            }
            else if(isPrevMonth){
                calendarRow+=`<td class=\"prev-month\">${startDayOfPrevMonth}</td>`
                startDayOfPrevMonth++;
                if(startDayOfPrevMonth>totalDaysOfLastMonth){
                    isPrevMonth = false;
                }
            }
            else{
                if(monthCounter!=day){
                    calendarRow+=`<td>${monthCounter}</td>`
                }
                else{
                calendarRow+=`<td class="today">${monthCounter}</td>`
                }
               monthCounter++;
                if(monthCounter>totalDaysOfCurrentMonth){
                    isNextMonth = true;
                }
            }
        }
        calendarRow+="</tr>";
       htmlToReturn+=calendarRow;
    }
    return htmlToReturn;




}
/*
<table>
<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>
<tr><td class="prev-month">28</td><td class="prev-month">29</td><td class="prev-month">30</td><td class="prev-month">31</td><td>1</td><td>2</td><td>3</td></tr>
    <tr><td class="today">4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td></tr>
    <tr><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td><td>16</td><td>17</td></tr>
    <tr><td>18</td><td>19</td><td>20</td><td>21</td><td>22</td><td>23</td><td>24</td></tr>
    <tr><td>25</td><td>26</td><td>27</td><td>28</td><td>29</td><td>30</td><td class="next-month">1</td></tr>
    </table>
*/
calendar([24,12,2012]);

/*
locale = "en-us",
    month = date.toLocaleString(locale, { month: "long" });*/

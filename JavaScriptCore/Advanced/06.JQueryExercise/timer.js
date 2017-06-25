/*jshint esversion: 6 */
function timer() {
    let startBtn = $("#start-timer");
    let stopBtn = $("#stop-timer");

    let seconds = $("#seconds");
    let minutes = $("#minutes");
    let hours = $("#hours");

    let timer = null;

    $(startBtn).click(startTimer);
    $(stopBtn).click(stopTimer);

    function stopTimer() {
        clearInterval(timer);
        timer = null;
    }


    function startTimer() {
        if (timer == null){
            timer = setInterval(() => {
                let secondsVal = Number($(seconds).val());
                let minutesVal = Number($(minutes).val());
                let hoursVal = Number($(hours).val());

                secondsVal++;
                if(secondsVal >= 60){
                    secondsVal = 0;
                    minutesVal++;
                }
                if(minutesVal >= 60){
                    minutesVal = 0;
                    hoursVal++;
                }
                $(seconds).text(("00" + secondsVal).slice (-2));
                $(minutes).text(("00" + minutesVal).slice (-2));
                $(hours).text(("00" + hoursVal).slice (-2));

                $(seconds).val(secondsVal);
                $(minutes).val(minutesVal);
                $(hours).val(hoursVal);
            },1000)
        }
    }
}
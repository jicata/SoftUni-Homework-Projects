function attachEventsListeners() {
    let allTheBtns = Array.from(document.getElementsByTagName("input")).filter(x=>x.id.indexOf('Btn') != -1);
    let allTheInputs = Array.from(document.getElementsByTagName("input")).filter(x=>x.id.indexOf('Btn') == -1);
    console.log(allTheBtns.length);

    for(let btn of allTheBtns){
        btn.addEventListener('click',converter)
    }

    function converter() {
        let id = this.id;
        let minutes;
        let seconds;
        let hours;
        let days;

        switch (id){
            case 'minutesBtn': convertMinutes();
                break;
            case 'secondsBtn': convertSeconds();
                break;
            case 'daysBtn': convertDays();
                break;
            case 'hoursBtn':convertHours();
                break;
        }
        allTheInputs[0].value = days;
        allTheInputs[1].value = hours;
        allTheInputs[2].value = minutes;
        allTheInputs[3].value = seconds;

        function convertMinutes() {
            minutes = Number(allTheInputs[2].value);
            seconds = 60 * minutes;
            hours = minutes / 60;
            days = hours / 24;

        }

        function convertSeconds() {
            seconds = Number(allTheInputs[3].value);
            minutes =  seconds / 60;
            hours = minutes / 60;
            days = hours / 24;
        }
        function convertHours() {
            hours = Number(allTheInputs[1].value);
            days = hours / 24;
            minutes = hours * 60;
            seconds = minutes * 60;

        }
        function convertDays() {
            days = Number(allTheInputs[0].value);
            hours = days * 24;
            minutes = hours * 60;
            seconds = minutes * 60;
        }

    }
}
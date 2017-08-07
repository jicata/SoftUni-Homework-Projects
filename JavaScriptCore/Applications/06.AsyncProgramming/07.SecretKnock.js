/*jshint esversion: 6 */
function knockEmDown() {
    $("#result").append(`<p>Knock Knock.</p>`)
    $("#buttonche").click(allHellBreaksLoose);

    function allHellBreaksLoose(kur,nextUrl) {

        let appId = `kid_BJXTsSi-e`;
        let kinveyUrl = `https://baas.kinvey.com/appdata/kid_BJXTsSi-e/`;
        let queryString = "knock?query=";
        let base64auth = btoa(`guest:guest`);
        let authHeader = {"Authorization": "Basic " + base64auth};
        let urlPostFix;
        if (nextUrl) {
            urlPostFix = nextUrl;
        }
        else {
            urlPostFix = "Knock Knock.";
        }

        let credentials = {
            username: "guest",
            password: "guest"
        };

        let knockKnockRequest = {
            type:"GET",
            url: kinveyUrl + queryString + urlPostFix,
            headers : authHeader
        };
        $.ajax(knockKnockRequest)
            .then(processResponse)
            .catch(error);

        function processResponse(response) {
            urlPostFix = response.answer;
            $(`<p>${response.answer}</p>`)
                .appendTo($("#result"));
            if(response.message != undefined){

            $(`<p>${response.message}</p>)`)
                .appendTo($("#result"));

                allHellBreaksLoose(null,response.message);
            }

        }


        function error() {
            console.log("aha");
        }

    }
}
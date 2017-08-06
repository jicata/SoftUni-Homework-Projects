function attachEvents() {
    $("#submit").click(submitForecastRequest);

    function submitForecastRequest() {
        $("#forecast").removeAttr("style");
        let userInputLocation = $("#location").val().trim();
        let locationsUrl = "https://judgetests.firebaseio.com/locations.json";

        let locationsRequest = {
            url: locationsUrl
        };

        $.ajax(locationsRequest)
            .then(findSpecifiedLocation)
            .catch(error);


        function error() {
            $("#forecast").text("Error");
        }

        function findSpecifiedLocation(response) {
            for (let location of response) {
                if (location.name == userInputLocation) {
                    getForecastForLocation(location.code);
                    break;
                }
            }

            function getForecastForLocation(code) {

                getCurrentConditions(code);
                getThreeDayForecast(code);

                function getCurrentConditions(code) {
                    let currentDiv = $("#current");
                    let todayConditionsUrl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;
                    let todayRequest = {
                        url: todayConditionsUrl
                    };

                    $.ajax(todayRequest)
                        .then(renderTodayConditions)
                        .catch(error);

                    function renderTodayConditions(response) {
                        let locationName = response.name;
                        let forecast = response.forecast;
                        let lowTemp = forecast.low;
                        let highTemp = forecast.high;
                        let condition = forecast.condition;
                        let conditionSymbol = determineConditionSymbol(condition);

                        $(`<span class="condition symbol">${conditionSymbol}</span>`)
                            .appendTo(currentDiv);
                        $(`<span class="condition">`)
                            .append($(`<span class="forecast-data">${locationName}</span>`))
                            .append($(`<span class="forecast-data">${lowTemp}&#176;/${highTemp}&#176;</span>`))
                            .append($(`<span class="forecast-data">${condition}</span>`))
                            .appendTo(currentDiv);
                        console.log("hii");
                    }
                }


                function getThreeDayForecast(code) {
                    let upcomingDiv = $("#upcoming");
                    let upcomingConditionsUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
                    let upcomingRequest = {
                        url: upcomingConditionsUrl
                    };

                    $.ajax(upcomingRequest)
                        .then(renderUpcomingConditions)
                        .catch(error);

                    function renderUpcomingConditions(response) {
                        let forecast = response.forecast;
                        for (let singleForecast of forecast) {
                            let lowTemp = singleForecast.low;
                            let highTemp = singleForecast.high;
                            let condition = singleForecast.condition;
                            let conditionSymbol = determineConditionSymbol(condition);

                            $(`<span class="upcoming">`)
                                .append(`<span class="symbol">${conditionSymbol}</span>`)
                                .append(`<span class="forecast-data">${lowTemp}&#176;/${highTemp}&#176;</span>`)
                                .append($(`<span class="forecast-data">${condition}</span>`))
                                .appendTo(upcomingDiv);

                        }


                    }
                }
            }


            function determineConditionSymbol(condition) {
                switch (condition) {
                    case "Sunny":
                        return "&#x2600;";
                    case "Partly sunny":
                        return "&#x26C5;";
                    case "Overcast":
                        return "&#x2601;";
                    case "Rain":
                        return "&#x2614;";
                    default:
                        return "Error";
                }
            }

        }
    }
}


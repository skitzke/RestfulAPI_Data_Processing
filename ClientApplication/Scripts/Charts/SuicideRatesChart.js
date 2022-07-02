// Shows years
var years = [1979, 1986, 1987, 1990];

// Display data
var Albania = [0, 0, 73, 0];
var Argentina = [1802, 2284, 2286, 2140];
var Armenia = [0, 61, 81, 93];
var Australia = [1675,	2044, 2164, 2202];

var ctx = document.getElementById("SuicideRateChart");

var SuicideRatesChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: years,
        datasets: [
            {
                data: Albania,
                label: "Albania",
                borderColor: "#3e95cd",
                fill: false
            },
            {
                data: Argentina,
                label: "Argentina",
                borderColor: "#8e5ea2",
                fill: false
            },
            {
                data: Armenia,
                label: "Armenia",
                borderColor: "#3cba9f",
                fill: false
            },
            {
                data: Australia,
                label: "Australia",
                borderColor: "#e8c3b9",
                fill: false
            }
        ]
    }
});





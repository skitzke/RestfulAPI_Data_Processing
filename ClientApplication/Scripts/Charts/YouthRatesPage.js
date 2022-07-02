// Shows years
var years = [2010, 2011, 2012, 2013, 2014];

// Display data
var Afghanistan = [20.6000003815, 20.8999996185, 19.7000007629, 21.1000003815 , 20.7999992371];
var Albania = [25.7999992371, 27, 28.2999992371, 28.7000007629, 29.2000007629];
var Armenia = [38.2999992371, 38.7000007629, 35, 32.5, 35.0999984741];
var Australia = [11.3999996185, 11.3999996185, 11.6999998093, 12.1999998093, 13.1000003815];
var Angola = [10.8000001907, 10.6999998093, 10.6999998093, 10.6000003815, 10.5];

var ctx = document.getElementById("YouthRatesChart");

var YouthRatesChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: years,
        datasets: [
            {
                data: Afghanistan,
                label: "Afghanistan",
                borderColor: "#3e95cd",
                fill: false
            },
            {
                data: Albania,
                label: "Albania",
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
            },
            {
                data: Angola,
                label: "Angola",
                borderColor: "#c45850",
                fill: false
            }
        ]
    }
});





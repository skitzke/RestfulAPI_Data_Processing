// Shows years
var years = ['HDI' + 2010, 'HDI' + 2011, 'HDI' + 2012, 'HDI' + 2013, 'HDI' + 2014];

// Display data
var Afghanistan = [0.463, 0.471, 0.482, 0.487 , 0.491];
var Albania = [0.741, 0.752, 0.767, 0.771, 0.773];
var Algeria = [0.729, 0.736, 0.74, 0.745, 0.747];
var Andorra = [0.828, 0.827, 0.849, 0.85, 0.853];
var Angola = [0.52,	0.535, 0.543, 0.554, 0.564];

var ctx = document.getElementById("HDIChart");

var HDIChart = new Chart(ctx, {
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
                data: Algeria,
                label: "Algeria",
                borderColor: "#3cba9f",
                fill: false
            },
            {
                data: Andorra,
                label: "Andorra",
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





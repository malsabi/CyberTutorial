const data = {
    labels: [
        'Red',
        'Blue',
        'Yellow'
    ],
    datasets: [{
        label: 'My First Dataset',
        data: [300, 50, 100],
        backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)'
        ],
        hoverOffset: 4
    }]
};
const config = {
    type: 'doughnut',
    data: data,
};

//Start Counter animation
function AnimateCounters() {
    const counters = document.querySelectorAll('.counter');
    const speed = 2000;
    counters.forEach(counter => {
        const dataValue = counter.getAttribute('data-target');
        $({ Counter: 0 }).animate({
            Counter: dataValue
        },
            {
                duration: speed,
                easing: 'swing',
                step: function () {
                    $(counter).text(Math.ceil(this.Counter));
                }
            });
    });
}


//Execute the functions when the document page is ready.
$(document).ready(function () {
    console.log('document is ready');
    AnimateCounters();
});
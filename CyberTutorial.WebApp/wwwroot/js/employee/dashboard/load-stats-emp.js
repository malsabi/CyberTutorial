$(document).ready(function () {
    HandleDataTableStyle();
    HandleNavCollapseState();
});

function HandleNavCollapseState() {
    $(".collapse").on("shown.bs.collapse", function () {
        localStorage.setItem("coll_" + this.id, true);
        console.log('SHOW ' + this.id);
    });

    $(".collapse").on("hidden.bs.collapse", function () {
        localStorage.removeItem("coll_" + this.id);
        console.log('HIDE' + this.id);
    });

    $(".collapse").each(function () {
        console.log('EACH ' + this.id);
        if (localStorage.getItem("coll_" + this.id) === "true") {
            $(this).collapse("show");
        }
        else {
            $(this).collapse("hide");
        }
    });
}

function HandleDataTableStyle() {
    $(".data-table").each(function (_, table) {
        $(table).dataTable({
            "searching": false,
            "columns.searchable": false,
            "paging": true,
            "ordering": false,
            "info": false,
            "dom": 'frtip'
        });
    });
}

const charts = document.querySelectorAll(".chart");
charts.forEach(function (chart) {
    var ctx = chart.getContext("2d");
    new Chart(ctx, {
        type: "bar",
        data: {
            labels: ["Quiz1", "Quiz2", "Quiz3", "Quiz4", "Quiz5", "Quiz6"],
            datasets: [
                {
                    label: "Quiz Marks",
                    data: [12, 19, 3, 5, 2, 3],
                    backgroundColor: [
                        "rgb(255, 99, 132)",
                        "rgb(54, 162, 235)",
                        "rgb(255, 206, 86)",
                        "rgb(75, 192, 192)",
                        "rgb(153, 102, 255)",
                        "rgb(255, 159, 64)",
                    ],
                    borderWidth: 0,
                },
            ],
        },
        options: {
            maintainAspectRatio: false,
        }
    });
});

const pieCharts = document.querySelectorAll(".pieChart");
pieCharts.forEach(function (chart) {
    var ctx = chart.getContext("2d");
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: [
                'Quiz 1',
                'Quiz 2',
                'Quiz 3',
                'Quiz 4',
                'Quiz 5'
            ],
            datasets: [{
                label: 'Quiz Result Dataset',
                data: [2, 5, 8, 10, 7],
                backgroundColor: [
                    "rgb(255, 99, 132)",
                    "rgb(54, 162, 235)",
                    "rgb(255, 206, 86)",
                    "rgb(75, 192, 192)",
                    "rgb(153, 102, 255)",
                    "rgb(255, 159, 64)",
                ],
                borderWidth: 0,
                hoverOffset: 4
            }]
        },
        options: {
            maintainAspectRatio: false,
        }
    });
});
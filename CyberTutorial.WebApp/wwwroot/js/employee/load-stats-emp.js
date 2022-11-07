$(document).ready(function () {
    HandleDataTableStyle();
    HandleNavCollapseState();
});

const EmployeePerformanceChartId = 'EmployeePerformanceChart';
const EmployeeFinalResultChartId = 'EmployeeFinalResultChart';
const EmployeeCoursesId = '#EmployeeCourses';
const EmployeeAttemptsId = '#EmployeeAttempts';

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

const EmployeeCourses = JSON.parse($(EmployeeCoursesId).val());
const EmployeeAttempts = JSON.parse($(EmployeeAttemptsId).val());

console.log("EmployeeCourses", EmployeeCourses);
console.log("EmployeeAttempts", EmployeeAttempts);

//var employeePerformanceLabels = JSON.parse($('#EmployeePerformanceLabels').val());
//var employeePerformanceDataSets = toCamel(JSON.parse($('#EmployeePerformanceDatasets').val()));
//var employeePerformanceTotalQuizzes = $('#EmployeePerformanceTotalQuizzes').val();
//var employeePerformanceMaximumScore = $('#EmployeePerformanceMaximumScore').val();

//console.log("Labels: " + employeePerformanceLabels);
//console.log("Datasets: " + employeePerformanceDataSets);

//var employeeFinalResultLabels = JSON.parse($('#EmployeeFinalResultLabels').val());
//var employeeFinalResultDataSets = toCamel(JSON.parse($('#EmployeeFinalResultDatasets').val()));

//new Chart(document.getElementById(EmployeePerformanceChartId),
//{
//    type: "bar",
//    data:
//    {
//        labels: employeePerformanceLabels,
//        datasets: employeePerformanceDataSets,
//    },
//    options:
//    {
//        maintainAspectRatio: false,
//        scales:
//        {
//            y:
//            {
//                max: parseInt(employeePerformanceMaximumScore)
//            },
//            x:
//            {
//                max: parseInt(employeePerformanceTotalQuizzes)
//            }
//        }
//    }
//});

//new Chart(document.getElementById(EmployeeFinalResultChartId),
//{
//    type: "bar",
//    data:
//    {
//        labels: employeePerformanceLabels,
//        datasets: employeePerformanceDataSets,
//    },
//    options:
//    {
//        maintainAspectRatio: false,
//        scales:
//        {
//            y:
//            {
//                max: parseInt(employeePerformanceMaximumScore)
//            },
//            x:
//            {
//                max: parseInt(employeePerformanceTotalQuizzes)
//            }
//        }
//    }
//});
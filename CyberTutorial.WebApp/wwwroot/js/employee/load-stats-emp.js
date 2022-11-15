$(document).ready(function ()
{
    HandleDataTableStyle();
    HandleNavCollapseState();
});

const TopEmployeesTableId = '#TopEmployeesTable';
const EmployeePerformanceChartId = 'EmployeePerformanceChart';
const EmployeeFinalResultChartId = 'EmployeeFinalResultChart';
const EmployeeCoursesId = '#EmployeeCourses';
const EmployeeAttemptsId = '#EmployeeAttempts';

const plugin = {
    id: 'emptyChart',
    afterDraw(chart, args, options) {
        const { datasets } = chart.data;
        let hasData = false;
        for (let dataset of datasets) {
            if (dataset.data.length > 0) {
                hasData = true;
                break;
            }
        }
        if (!hasData) {
            const { chartArea: { left, top, right, bottom }, ctx } = chart;
            const centerX = (left + right) / 2;
            const centerY = (top + bottom) / 2;
            chart.clear();
            ctx.save();
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.font = '30px Arial';
            ctx.fillStyle = '#FFFFFF'
            ctx.fillText('No data available ', centerX, centerY);
            ctx.restore();
        }
    }
};

Chart.register(ChartDataLabels);
Chart.defaults.color = "#FFFFFF";
Chart.defaults.borderColor = '#FFFFFF';
Chart.register(plugin);

function HandleNavCollapseState()
{
    $(".collapse").on("shown.bs.collapse", function ()
    {
        localStorage.setItem("coll_" + this.id, true);
    });

    $(".collapse").on("hidden.bs.collapse", function ()
    {
        localStorage.removeItem("coll_" + this.id);
    });

    $(".collapse").each(function ()
    {
        if (localStorage.getItem("coll_" + this.id) === "true")
        {
        }
        else
        {
            $(this).collapse("hide");
        }
    });
}

function HandleDataTableStyle()
{
    $(TopEmployeesTableId).dataTable({
        "searching": false,
        "columns.searchable": false,
        "paging": true,
        "ordering": false,
        "info": false,
        "dom": 'frtip'
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
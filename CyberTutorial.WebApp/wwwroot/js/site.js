const LoadingActionContent = 'Loading..';

//Employee
const EmployeeAccountType = 'Employee';
//Company
const CompanyAccountType = 'Company';

//Modals
const RegisterModalId = '#RegisterModal';
const LoginModalId = '#LoginModal';
const CompanySuccessModalId = '#CompanySuccessModal';
const EmployeeSuccessModalId = '#EmployeeSuccessModal';

var settings = {
    validClass: "is-valid",
    errorClass: "is-invalid"
};
$.validator.setDefaults(settings);
$.validator.unobtrusive.options = settings;

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

function HandleModalEventHandlers()
{
    $(LoginModalId).on('show.bs.modal', e =>
    {
        $(RegisterModalId).modal('hide');
    });
    
    $(RegisterModalId).on('show.bs.modal', e =>
    {
        $(LoginModalId).modal('hide');
    });

    $(LoginModalId).on('hidden.bs.modal', e =>
    {
        ClearLoginForm();
    });
    
    $(RegisterModalId).on('hidden.bs.modal', e =>
    {
        ClearRegisterCompanyForm();
        ClearRegisterEmployeeForm();
    });

    $(CompanySuccessModalId).on('hidden.bs.modal', e =>
    {
        ClearRegisterCompanyForm();
        ClearRegisterEmployeeForm();
        $(RegisterModalId).modal('hide');
        $(LoginModalId).modal('show');
    });

    $(EmployeeSuccessModalId).on('hidden.bs.modal', e => {
        ClearRegisterCompanyForm();
        ClearRegisterEmployeeForm();
        $(RegisterModalId).modal('hide');
        $(LoginModalId).modal('show');
    });
}

function AnimateCounters()
{
    const counters = document.querySelectorAll('.counter');
    const speed = 2000;
    counters.forEach(counter =>
    {
        const dataValue = counter.getAttribute('data-target');
        $({ Counter: 0 }).animate({
            Counter: dataValue
        },
        {
            duration: speed,
            easing: 'swing',
            step: function ()
            {
                $(counter).text(Math.ceil(this.Counter));
            }
        });
    });
}

function HandleActiveNavLinks()
{
    document.querySelectorAll('.nav-link').forEach(link =>
    {
        const hrefValue = link.getAttribute('href');
        if (hrefValue != null)
        {
            if (hrefValue.toLowerCase() === location.pathname.toLowerCase())
            {
                link.classList.add('active');
            }
            else
            {
                link.classList.remove('active');
            }
        }
    });
}

$(document).ready(function ()
{
    HandleModalEventHandlers();
    AnimateCounters();
    HandleActiveNavLinks();
});
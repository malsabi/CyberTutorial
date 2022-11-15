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
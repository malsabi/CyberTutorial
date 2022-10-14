//Login
const LoginFormId = '#LoginForm';
const LoginButtonId = '#LoginButton';
const LoginContent = 'Sign In';
const LoadingActionContent = 'Loading..';
const LoginModalId = '#LoginModal';
const RedirectToEmployeeId = '#RedirectToEmployee';
const RedirectToCompanyId = '#RedirectToCompany';
const AuthenticationUrl = location.origin + '/Home/Authentication?';
const AuthenticationToastId = '#AuthenticationToast';

//Employee
const EmployeeAccountType = 'Employee';
//Company
const CompanyAccountType = 'Company';

//Register
const RegisterModalId = '#RegisterModal';
const RegisterCompanyFormId = '#RegisterCompanyForm';
const RegisterEmployeeFormId = '#RegisterEmployeeForm';
const RegisterCompanyButtonId = '#SignUpCompanyButton';
const RegisterEmployeeButtonId = '#SignUpEmployeeButton';
const RegisterContent = 'Sign Up';
const RegisterUrl = location.origin + '/Home/Register?';
const CompanySuccessModalId = '#CompanySuccessModal';
const CompanyErrorToastId = '#CompanyErrorToast';
const CompanyExistsToastId = '#CompanyExistsToast';
const EmployeeSuccessModalId = '#EmployeeSuccessModal';
const EmployeeErrorToastId = '#EmployeeErrorToast';
const CompanyNotFoundToastId = '#CompanyNotFoundToast';
const EmployeeFoundToastId = '#EmployeeFoundToast';

//Logout
const CompanyLogoutButtonId = '#LogoutCompanyButton';
const EmployeeLogoutButtonId = '#LogoutEmployeeButton';
const LogoutCompanyUrl = location.origin + '/Company/Logout';
const LogoutEmployeeUrl = location.origin + '/Employee/Logout';
const LogoutErrorToastId = '#LogoutErrorToast';
const RedirectToHomeId = '#RedirectToHome';

var settings = {
    validClass: "is-valid",
    errorClass: "is-invalid"
};
$.validator.setDefaults(settings);
$.validator.unobtrusive.options = settings;

Chart.register(ChartDataLabels);
Chart.defaults.color = "#FFFFFF";
Chart.defaults.borderColor = '#FFFFFF';

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
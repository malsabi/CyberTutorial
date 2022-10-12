//Login
const LoginFormId = '#LoginForm';
const LoginButtonId = '#LoginButton';
const LoginContent = 'Sign In';
const LoadingActionContent = 'Loading..';
const LoginModalId = '#LoginModal';
const RedirectToEmployeeId = '#RedirectToEmployee';
const RedirectToCompanyId = '#RedirectToCompany';
const AuthenticationUrl = 'Home/Authentication?';
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
const RegisterUrl = 'Home/Register?';
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
const LogoutCompanyUrl = 'Company/Logout';
const LogoutEmployeeUrl = 'Employee/Logout';
const LogoutErrorToastId = '#LogoutErrorToast';
const RedirectToHomeId = '#RedirectToHome';

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
        ClearRegisterForms();
    });

    $(CompanySuccessModalId).on('hidden.bs.modal', e =>
    {
        ClearRegisterForms();
        $(RegisterModalId).modal('hide');
        $(LoginModalId).modal('show');
    });

    $(EmployeeSuccessModalId).on('hidden.bs.modal', e => {
        ClearRegisterForms();
        $(RegisterModalId).modal('hide');
        $(LoginModalId).modal('show');
    });
}

function ClearRegisterForms()
{
    const registerCompanyForm = $(RegisterCompanyFormId);
    registerCompanyForm.trigger('reset');

    const registerEmployeeForm = $(RegisterEmployeeFormId);
    registerEmployeeForm.trigger('reset');
}

function ClearLoginForm()
{
    const loginForm = $(LoginFormId);
    loginForm.trigger('reset');
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

function ToggleSpinner(id, content, showSpinner = true)
{
    let button = document.getElementById(id.replace('#', ''));

    if (showSpinner)
    {
        button.setAttribute("disabled", "disabled");
        button.innerHTML = '<div class="d-flex align-items-center"><div class="spinner-grow spinner-grow-sm me-2" role="status" aria-hidden="true"></div>'.concat(content, '</div>');
        return;
    }

    button.removeAttribute("disabled");
    button.innerHTML = content;
}

function HandleLogin()
{
    $(LoginButtonId).on('click', e =>
    {
        e.preventDefault();
        const loginForm = $(LoginFormId);
        loginForm.validate();
        if (loginForm.valid())
        {
            ToggleSpinner(LoginButtonId, LoadingActionContent, true);
            $.ajax
            ({
                type: "POST",
                url: AuthenticationUrl,
                data: loginForm.serialize(),
                dataType: "JSON",
                success: function (response)
                {
                    console.log(response);
                    if (response.IsError)
                    {
                        $(AuthenticationToastId).toast("show");
                        return;
                    }
                    if (response.AccountType == EmployeeAccountType)
                    {
                        location.href = $(RedirectToEmployeeId).val();
                        return;
                    }
                    location.href = $(RedirectToCompanyId).val();
                },
                complete: function ()
                {
                    ToggleSpinner(LoginButtonId, LoginContent, false);
                }
            });
            return;
        }
        console.log('Invalid login form, please insert a valid data');
    });
}

function HandleRegisterCompany()
{
    $(RegisterCompanyButtonId).on('click', e =>
    {
        e.preventDefault();
        const registerForm = $(RegisterCompanyFormId);
        registerForm.validate();
        if (registerForm.valid())
        {
            ToggleSpinner(RegisterCompanyButtonId, LoadingActionContent, true);
            $.ajax
            ({
                type: "POST",
                url: RegisterUrl,
                data: registerForm.serialize(),
                dataType: "JSON",
                success: function (response)
                {
                    if (response.IsError)
                    {
                        $(CompanyExistsToastId).toast("show");
                        return;
                    }
                    $(CompanySuccessModalId).modal('show');
                    console.log(response);
                },
                error: function ()
                {
                    $(CompanyErrorToastId).toast('show');
                },
                complete: function (response)
                {
                    console.log(response);
                    ToggleSpinner(RegisterCompanyButtonId, RegisterContent, false);
                }
            });
            return;
        }
        console.log('Invalid register company form, please insert a valid data');
    });
}

function HandleRegisterEmployee()
{
    $(RegisterEmployeeButtonId).on('click', e =>
    {
        e.preventDefault();
        const registerForm = $(RegisterEmployeeFormId);
        registerForm.validate();
        if (registerForm.valid())
        {
            ToggleSpinner(RegisterEmployeeButtonId, LoadingActionContent, true);
            $.ajax
            ({
                type: "POST",
                url: RegisterUrl,
                data: registerForm.serialize(),
                dataType: "JSON",
                success: function (response)
                {
                    console.log(response);
                    if (response.IsError)
                    {
                        const error = response.Errors[0];
                        if (error.Type == '4') {
                            $(CompanyNotFoundToastId).toast('show');
                            return;
                        }
                        else if (error.Type == '3') {
                            $(EmployeeFoundToastId).toast('show');
                            return;
                        }
                        $(EmployeeErrorToastId).toast('show');
                    }
                    $(EmployeeSuccessModalId).modal('show');
                },
                error: function ()
                {
                    $(EmployeeErrorToastId).toast('show');
                },
                complete: function ()
                {
                    ToggleSpinner(RegisterEmployeeButtonId, RegisterContent, false);
                }
            });
            return;
        }
        console.log('Invalid register employee form, please insert a valid data');
    });
}

function HandleCompanyLogout()
{
    $(CompanyLogoutButtonId).on('click', e =>
    {
        e.preventDefault();
        $.ajax
        ({
            type: "GET",
            url: LogoutCompanyUrl,
            dataType: "JSON",
            success: function (response)
            {
                console.log(response);
                if (response.IsError)
                {
                    $(LogoutErrorToastId).toast('show');
                    return;
                }
                location.href = $(RedirectToHomeId).val();
            },
            error: function ()
            {
                $(LogoutErrorToastId).toast('show');
            }
        });
    });
}

function HandleEmployeeLogout()
{
    $(EmployeeLogoutButtonId).on('click', e =>
    {
        e.preventDefault();
        $.ajax
        ({
            type: "GET",
            url: LogoutEmployeeUrl,
            dataType: "JSON",
            success: function (response)
            {
                console.log(response);
                if (response.IsError)
                {
                    $(LogoutErrorToastId).toast('show');
                    return;
                }
                location.href = $(RedirectToHomeId).val();
            },
            error: function ()
            {
                $(LogoutErrorToastId).toast('show');
            }
        });
    });
}

$(document).ready(function ()
{
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
    HandleModalEventHandlers();
    AnimateCounters();
    HandleLogin();
    HandleRegisterCompany();
    HandleRegisterEmployee();
    HandleCompanyLogout();
    HandleEmployeeLogout();
});


Chart.register(ChartDataLabels);
Chart.defaults.color = "#FFFFFF";
Chart.defaults.borderColor = '#FFFFFF';

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
$(document).ready(function ()
{
    HandleLogin();
});

const LoginFormId = '#LoginForm';
const LoginButtonId = '#LoginButton';
const LoginUrl = location.origin + '/Authentication/Login?';
const LoginButtonContent = 'Sign In';
const LoginAlertId = '#LoginAlert';
const RedirectToCompanyId = '#RedirectToCompany';
const RedirectToEmployeeId = '#RedirectToEmployee';

function LoginAlert(message)
{
    const alertBox = $(LoginAlertId);
    alertBox.removeClass('d-none');
    alertBox.text(message);
    setTimeout(function ()
    {
        alertBox.addClass('d-none')
        alertBox.text('');
    }, 5000);
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
                    url: LoginUrl,
                    data: loginForm.serialize(),
                    dataType: "JSON",
                    success: function (response)
                    {
                        if (response.IsSuccess && response.Metadata != null)
                        {
                            if (response.Metadata.length != 1)
                            {
                                LoginAlert('Invalid metadata response.');
                                return;
                            }
                            if (response.Metadata[0] == "CompanyAccess")
                            {
                                location.href = $(RedirectToCompanyId).val();
                            }
                            else if (response.Metadata[0] == "EmployeeAccess")
                            {
                                location.href = $(RedirectToEmployeeId).val();
                            }
                            else
                            {
                                LoginAlert('Invalid metadata response.');
                            }
                            return;
                        }
                        LoginAlert(response.Message);
                    },
                    complete: function ()
                    {
                        ToggleSpinner(LoginButtonId, LoginButtonContent, false);
                    }
                });
            return;
        }
        LoginAlert('Invalid login form, please insert a valid data');
    });
}

function ClearLoginForm()
{
    const loginForm = $(LoginFormId);
    loginForm.trigger('reset');
}
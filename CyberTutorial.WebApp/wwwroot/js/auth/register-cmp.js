$(document).ready(function ()
{
    HandleRegisterCompany();
});

const RegisterCompanyFormId = '#RegisterCompanyForm';
const RegisterCompanyButtonId = '#SignUpCompanyButton';
const RegisterCompanyUrl = location.origin + '/Authentication/RegisterCompany?';
const RegisterCompanyButtonContent = 'Sign Up';
const RegisterCompanyAlertId = '#RegisterCompanyAlert';

function CompanyAlert(message)
{
    const alertBox = $(RegisterCompanyAlertId);
    alertBox.removeClass('d-none');
    alertBox.text(message);
    setTimeout(function ()
    {
        alertBox.addClass('d-none')
        alertBox.text('');
    }, 5000);
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
                    url: RegisterCompanyUrl,
                    data: registerForm.serialize(),
                    dataType: "JSON",
                    success: function (response)
                    {
                        if (response.IsSuccess)
                        {
                            $(CompanySuccessModalId).modal('show');
                            return;
                        }
                        CompanyAlert(response.Message);
                    },
                    complete: function (response)
                    {
                        ToggleSpinner(RegisterCompanyButtonId, RegisterCompanyButtonContent, false);
                    }
                });
            return;
        }
        CompanyAlert('Invalid register company form, please insert a valid data');
    });
}

function ClearRegisterCompanyForm()
{
    const registerCompanyForm = $(RegisterCompanyFormId);
    registerCompanyForm.trigger('reset');
}
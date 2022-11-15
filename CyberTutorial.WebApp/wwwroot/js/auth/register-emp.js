$(document).ready(function ()
{
    HandleRegisterEmployee();
});

const RegisterEmployeeFormId = '#RegisterEmployeeForm';
const RegisterEmployeeButtonId = '#SignUpEmployeeButton';
const RegisterEmployeeUrl = location.origin + '/Authentication/RegisterEmployee?';
const RegisterEmployeeButtonContent = 'Sign Up';
const RegisterEmployeeAlertId = '#RegisterEmployeeAlert';

function EmployeeAlert(message)
{
    const alertBox = $(RegisterEmployeeAlertId);
    alertBox.removeClass('d-none');
    alertBox.text(message);
    setTimeout(function ()
    {
        alertBox.addClass('d-none')
        alertBox.text('');
    }, 5000);
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
                    url: RegisterEmployeeUrl,
                    data: registerForm.serialize(),
                    dataType: "JSON",
                    success: function (response)
                    {
                        if (response.IsSuccess)
                        {
                            $(EmployeeSuccessModalId).modal('show');
                            return;
                        }
                        EmployeeAlert(response.Message);
                    },
                    complete: function ()
                    {
                        ToggleSpinner(RegisterEmployeeButtonId, RegisterEmployeeButtonContent, false);
                    }
                });
            return;
        }
        EmployeeAlert('Invalid register employee form, please insert a valid data');
    });
}

function ClearRegisterEmployeeForm()
{
    const registerEmployeeForm = $(RegisterEmployeeFormId);
    registerEmployeeForm.trigger('reset');
}
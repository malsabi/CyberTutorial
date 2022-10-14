$(document).ready(function () {
    HandleRegisterEmployee();
});

function HandleRegisterEmployee() {
    $(RegisterEmployeeButtonId).on('click', e => {
        e.preventDefault();
        const registerForm = $(RegisterEmployeeFormId);
        registerForm.validate();
        if (registerForm.valid()) {
            ToggleSpinner(RegisterEmployeeButtonId, LoadingActionContent, true);
            $.ajax
                ({
                    type: "POST",
                    url: RegisterUrl,
                    data: registerForm.serialize(),
                    dataType: "JSON",
                    success: function (response) {
                        console.log(response);
                        if (response.IsError) {
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
                    error: function () {
                        $(EmployeeErrorToastId).toast('show');
                    },
                    complete: function () {
                        ToggleSpinner(RegisterEmployeeButtonId, RegisterContent, false);
                    }
                });
            return;
        }
        console.log('Invalid register employee form, please insert a valid data');
    });
}

function ClearRegisterEmployeeForm() {
    const registerEmployeeForm = $(RegisterEmployeeFormId);
    registerEmployeeForm.trigger('reset');
}
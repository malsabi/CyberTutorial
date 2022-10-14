$(document).ready(function () {
    HandleRegisterCompany();
});

function HandleRegisterCompany() {
    $(RegisterCompanyButtonId).on('click', e => {
        e.preventDefault();
        const registerForm = $(RegisterCompanyFormId);
        registerForm.validate();
        if (registerForm.valid()) {
            ToggleSpinner(RegisterCompanyButtonId, LoadingActionContent, true);
            $.ajax
                ({
                    type: "POST",
                    url: RegisterUrl,
                    data: registerForm.serialize(),
                    dataType: "JSON",
                    success: function (response) {
                        if (response.IsError) {
                            $(CompanyExistsToastId).toast("show");
                            return;
                        }
                        $(CompanySuccessModalId).modal('show');
                        console.log(response);
                    },
                    error: function () {
                        $(CompanyErrorToastId).toast('show');
                    },
                    complete: function (response) {
                        console.log(response);
                        ToggleSpinner(RegisterCompanyButtonId, RegisterContent, false);
                    }
                });
            return;
        }
        console.log('Invalid register company form, please insert a valid data');
    });
}

function ClearRegisterCompanyForm() {
    const registerCompanyForm = $(RegisterCompanyFormId);
    registerCompanyForm.trigger('reset');
}
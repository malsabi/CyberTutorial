$(document).ready(function () {
    HandleLogin();
});

function HandleLogin() {
    $(LoginButtonId).on('click', e => {
        e.preventDefault();
        const loginForm = $(LoginFormId);
        loginForm.validate();
        if (loginForm.valid()) {
            ToggleSpinner(LoginButtonId, LoadingActionContent, true);
            $.ajax
                ({
                    type: "POST",
                    url: AuthenticationUrl,
                    data: loginForm.serialize(),
                    dataType: "JSON",
                    success: function (response) {
                        console.log(response);
                        if (response.IsError) {
                            $(AuthenticationToastId).toast("show");
                            return;
                        }
                        if (response.AccountType == EmployeeAccountType) {
                            location.href = $(RedirectToEmployeeId).val();
                            return;
                        }
                        location.href = $(RedirectToCompanyId).val();
                    },
                    complete: function () {
                        ToggleSpinner(LoginButtonId, LoginContent, false);
                    }
                });
            return;
        }
        console.log('Invalid login form, please insert a valid data');
    });
}

function ClearLoginForm() {
    const loginForm = $(LoginFormId);
    loginForm.trigger('reset');
}
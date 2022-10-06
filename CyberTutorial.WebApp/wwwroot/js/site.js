const LoginFormId = '#LoginForm';
const LoginButtonId = '#LoginButton';
const LoginContent = 'Login';
const LoginActionContent = 'Loading..';
const LoginModalId = '#LoginModal';
const RedirectToEmployeeId = '#RedirectToEmployee';
const AuthenticationUrl = 'Home/Authentication?';
const AuthenticationSuccessMessage = 'Login Successful.';
const AuthenticationToastId = '#AuthenticationToast';
const RegisterModalId = '#RegisterModal';

function HandleModalEventHandlers() {
    $(LoginModalId).on('hidden.bs.modal', e => {
        const loginForm = $(LoginFormId);
        loginForm.removeClass('was-validated');
        loginForm.trigger('reset');
    });
    $(RegisterModalId).on('show.bs.modal', e => {
        $(LoginModalId).modal('hide');
    });
}

function AnimateCounters() {
    const counters = document.querySelectorAll('.counter');
    const speed = 2000;
    counters.forEach(counter => {
        const dataValue = counter.getAttribute('data-target');
        $({ Counter: 0 }).animate({
            Counter: dataValue
        },
            {
                duration: speed,
                easing: 'swing',
                step: function () {
                    $(counter).text(Math.ceil(this.Counter));
                }
            });
    });
}

function ToggleSpinner(id, content, showSpinner = true) {
    let button = document.getElementById(id.replace('#', ''));

    if (showSpinner) {
        button.setAttribute("disabled", "disabled");
        button.innerHTML = '<div class="d-flex align-items-center"><div class="spinner-grow spinner-grow-sm me-2" role="status" aria-hidden="true"></div>'.concat(content, '</div>');
    }
    else {
        button.removeAttribute("disabled");
        button.innerHTML = content;
    }
}

function HandleLogin() {
    $(LoginButtonId).on('click', e => {
        e.preventDefault();
        const loginForm = $(LoginFormId);
        loginForm.addClass('was-validated');
        loginForm.validate();
        if (loginForm.valid()) {
            ToggleSpinner(LoginButtonId, LoginActionContent, true);
            $.ajax
                ({
                    type: "POST",
                    url: AuthenticationUrl,
                    data: loginForm.serialize(),
                    dataType: "JSON",
                    success: function (response) {
                        console.log(response);
                        if (response.success == AuthenticationSuccessMessage) {
                            location.href = $(RedirectToEmployeeId).val();
                        }
                        else {
                            $(AuthenticationToastId).toast("show");
                        }
                        ToggleSpinner(LoginButtonId, LoginContent, false);
                    },
                    error: function (response) {
                        console.log(response);
                        ToggleSpinner(LoginButtonId, LoginContent, false);
                    }
                });
        }
        else {
            console.log('Invalid data, please insert a valid data');
        }
    });
}

$(document).ready(function () {
    HandleModalEventHandlers();
    AnimateCounters();
    HandleLogin();
});
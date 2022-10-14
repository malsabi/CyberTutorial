$(document).ready(function () {
    HandleEmployeeLogout();
});

function HandleEmployeeLogout() {
    $(EmployeeLogoutButtonId).on('click', e => {
        e.preventDefault();
        $.ajax
            ({
                type: "GET",
                url: LogoutEmployeeUrl,
                dataType: "JSON",
                success: function (response) {
                    console.log(response);
                    if (response.IsError) {
                        $(LogoutErrorToastId).toast('show');
                        return;
                    }
                    location.href = $(RedirectToHomeId).val();
                },
                error: function () {
                    $(LogoutErrorToastId).toast('show');
                }
            });
    });
}
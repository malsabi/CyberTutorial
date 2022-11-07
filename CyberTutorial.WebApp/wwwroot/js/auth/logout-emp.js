$(document).ready(function ()
{
    HandleEmployeeLogout();
});

const LogoutEmployeeButtonId = '#LogoutEmployeeButton';
const LogoutEmployeeUrl = location.origin + '/Authentication/LogoutEmployee';
const LogoutEmployeeRedirectToHomeId = '#RedirectToHome';
const LogoutEmployeeErrorToastId = '#LogoutErrorToast';

function HandleEmployeeLogout()
{
    $(LogoutEmployeeButtonId).on('click', e =>
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
                    if (response.IsSuccess)
                    {
                        location.href = $(LogoutEmployeeRedirectToHomeId).val();
                        return;
                    }
                    $(LogoutEmployeeErrorToastId).toast('show');
                },
                error: function ()
                {
                    $(LogoutEmployeeErrorToastId).toast('show');
                }
            });
    });
}
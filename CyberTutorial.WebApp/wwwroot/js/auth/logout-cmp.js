$(document).ready(function ()
{
    HandleCompanyLogout();
});

const LogoutCompanyButtonId = '#LogoutCompanyButton';
const LogoutCompanyUrl = location.origin + '/Authentication/LogoutCompany';
const LogoutCompanyRedirectToHomeId = '#RedirectToHome';
const LogoutCompanyErrorToastId = '#LogoutErrorToast';

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
                    if (response.IsSuccess)
                    {
                        location.href = $(LogoutCompanyRedirectToHomeId).val();
                        return;
                    }
                    $(LogoutCompanyErrorToastId).toast('show');
                },
                error: function ()
                {
                    $(LogoutCompanyErrorToastId).toast('show');
                }
            });
    });
}
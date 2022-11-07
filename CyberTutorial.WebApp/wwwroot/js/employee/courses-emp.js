$(document).ready(function ()
{
    HandleApplyCourse();
});

ApplyCourseButtonId = '.ApplyCourseButton';
ApplyCourseUrl = location.origin + '/Employee/ApplyCourse';

function HandleApplyCourse()
{
    $(ApplyCourseButtonId).bind('click', function (e)
    {
        e.preventDefault();

        let courseId = $(this).data('course-id');
        console.log("CourseId", courseId);
        
        $.ajax
            ({
                type: "POST",
                url: ApplyCourseUrl,
                data: {courseId: courseId},
                dataType: "JSON",
                success: function (response)
                {
                    console.log(response);
                    if (response.IsSuccess)
                    {
                        location.reload();
                    }
                },
            });
    });
}
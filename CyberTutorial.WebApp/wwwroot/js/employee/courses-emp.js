$(document).ready(function ()
{
    HandleViewCourse();
    HandleApplyCourse();
});

const ApplyCourseButtonId = '.ApplyCourseButton';
const ApplyCourseUrl = location.origin + '/Employee/ApplyCourse';
const ViewCourseButtonId = '.ViewCourseButton';
const ViewCourseModalId = '#ViewCourseModal';
const ViewCourseModalLabelId = '#ViewCourseModalLabel';
const ViewCourseEmbedId = '#ViewCourseEmbed';

function HandleApplyCourse()
{
    $(ApplyCourseButtonId).bind('click', function (e)
    {
        e.preventDefault();
        let courseId = $(this).data('course-id');
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

function HandleViewCourse()
{
    $(ViewCourseButtonId).bind('click', function (e)
    {
        e.preventDefault();

        let courseName = $(this).data('course-name');
        let courseUrl = $(this).data('course-url');

        $(ViewCourseModalLabelId).text(courseName);
        $(ViewCourseEmbedId).replaceWith($(ViewCourseEmbedId).clone().attr('src', courseUrl));
        $(ViewCourseModalId).modal('show');
    });
}
$(document).ready(function ()
{
    HandleModalEventHandlers();
    HandleAvailableQuizzesTableStyle();
    HandleAttemptedQuizzesTableStyle();
    HandleActionButtonsToolTips();
    HandleViewMarks();
    HandleStartQuiz();
    HandleStartQuizModal();
});

const AvailableQuizzesTableId = '#AvailableQuizzesTable';
const ViewMarksButtonId = '.ViewMarksButton';
const StartQuizButtonId = '.StartQuizButton';
const ViewMarksUrl = location.origin + '/Employee/ViewMarks';
const ViewMarksModalId = '#ViewMarksModal';
const ViewMarksModalLabelId = '#ViewMarksModalLabel';
const ViewMarksModalResultId = '#ViewMarksModalResult';
const StartQuizModalId = '#StartQuizModal';
const StartQuizModalLabelId = '#StartQuizModalLabel';
const StartQuizModalBodyId = '#StartQuizModalBody';
const StartQuizModalButtonId = '#StartQuizModalButton';
const StartQuizUrl = location.origin + '/Employee/StartQuiz?quizId=';
const CanAttemptQuizUrl = location.origin + '/Employee/CanAttemptQuiz';
const AttemptedQuizzesTableId = '#AttemptedQuizzesTable';

function HandleModalEventHandlers()
{
    $(ViewMarksModalId).on('hidden.bs.modal', e =>
    {
        $(ViewMarksModalLabelId).text("");
        $(ViewMarksModalResultId).empty();
    });
}

function HandleAvailableQuizzesTableStyle()
{
    $(AvailableQuizzesTableId).DataTable();
}

function HandleAttemptedQuizzesTableStyle()
{
    $(AttemptedQuizzesTableId).DataTable();
}

function HandleActionButtonsToolTips()
{
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    tooltipTriggerList.map(function (tooltipTriggerEl)
    {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })
}

function HandleViewMarks()
{
    $(ViewMarksButtonId).bind('click', function (e)
    {
        e.preventDefault();

        let quizId = $(this).data('quiz-id');
        $.ajax
            ({
                type: "POST",
                url: ViewMarksUrl,
                data: { quizId: quizId },
                dataType: "JSON",
                success: function (response)
                {
                    if (response.IsSuccess)
                    {
                        let attemptsLength = response.Data.length;
                        if (attemptsLength == 0)
                        {
                            $(ViewMarksModalLabelId).text("No Attempts Found");
                            $(ViewMarksModalResult).text(response.Message);
                        }
                        else
                        {
                            $(ViewMarksModalLabelId).text(response.Data.length + " Attempts Found!");
                            $(ViewMarksModalResult).append(CreateMarksTable(response.Data));
                        }
                    }
                    else
                    {
                        $(ViewMarksModalLabelId).text("Error");
                        $(ViewMarksModalResult).text(response.Message);
                    }
                    $(ViewMarksModalId).modal('show');
                },
            });
    });
}

function HandleStartQuiz()
{
    $(StartQuizButtonId).bind('click', function (e)
    {
        e.preventDefault();
        let quizId = $(this).data('quiz-id');
        $.ajax
            ({
                type: "POST",
                url: CanAttemptQuizUrl,
                data: { quizId: quizId },
                dataType: "JSON",
                success: function (response)
                {
                    console.log(response);
                    if (response.IsSuccess && response.Data < 300)
                    {
                        $(StartQuizModalLabelId).text('Rules');
                        $(StartQuizModalBodyId).append('<p>1. Once you select your answer. it cant be undone.</p>');
                        $(StartQuizModalBodyId).append('<p>2. You cant open any tab or another application or you will get zero.</p>');
                        $(StartQuizModalBodyId).append('<p>3. You will have maximum of 3 attempts.</p>');
                        $(StartQuizModalBodyId).append('<p>4. You must answer all the questions in order to submit the quiz.</p>');
                        $(StartQuizModalBodyId).append('<div class="col-4 d-grid mx-auto"><button type="button" class="btn btn-lg btn-success rounded-pill" id="StartQuizModalButton" data-quiz-id="' + quizId + '">Start Quiz</button></div>');
                    }
                    else
                    {
                        $(StartQuizModalLabelId).text('Maximum Attempts Reached');
                        $(StartQuizModalBodyId).append('<p>Cannot start the quiz.</p>');
                        $(StartQuizModalBodyId).append('<p>You have exceeded the maximum number of attempts!.</p>');
                    }
                    $(StartQuizModalId).modal('show');
                },
            });
    });
}

function HandleStartQuizModal()
{
    $(document).on('click', StartQuizModalButtonId, function ()
    {
        let quizId = $(this).data('quiz-id');
        window.location.replace(StartQuizUrl + quizId);
    });
}

function CreateMarksTable(attempts)
{
    var wrapper = document.createElement("div");
    wrapper.classList.add("table-responsive");
    
    var headers = [" ", "Started At", "Completed At", "Score", "Correct Answers", "Incorrect Answers"];
    var table = document.createElement("table");
    table.id = "ViewMarksTable";
    table.classList.add("table", "table-bordered", "table-light");
    table.style.width = "100%";
    
    for (var i = 0; i < attempts.length; i++)
    {
        var row = table.insertRow(i);
        row.insertCell(0).innerHTML = i + 1;
        row.insertCell(1).innerHTML = attempts[i].StartedAt;
        row.insertCell(2).innerHTML = attempts[i].CompletedAt;
        row.insertCell(3).innerHTML = attempts[i].Score;
        row.insertCell(4).innerHTML = attempts[i].TotalCorrectAnswers;
        row.insertCell(5).innerHTML = attempts[i].TotalIncorrectAnswers;
    }

    var header = table.createTHead();
    var headerRow = header.insertRow(0);
    for (var i = 0; i < headers.length; i++)
    {
        headerRow.insertCell(i).innerHTML = headers[i];
    }

    wrapper.appendChild(table);
    return wrapper;
}
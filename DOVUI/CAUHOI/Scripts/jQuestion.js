function CreateQuestion() {
    var Content = document.getElementById("txtContent").value;
    var Level = document.getElementById("cbxLevel").value;
    var AnswerA = document.getElementById("txtAnswerA").value;
    var AnswerB = document.getElementById("txtAnswerB").value;
    var AnswerC = document.getElementById("txtAnswerC").value;
    var AnswerD = document.getElementById("txtAnswerD").value;
    var IsResult = document.getElementById("cbxResult").value;

    $.ajax({
        url: "/QuestionPage/Question/Create",
        type: "POST",
        data: { "Content": Content, "Level": Level, "AnswerA": AnswerA, "AnswerB": AnswerB, "AnswerC": AnswerC, "AnswerD": AnswerD, "IsResult": IsResult },
        success: function (data) {
            if (data.ID == "1") {
                alert(data.Desc);
                window.location.reload();
            } else {
                alert(data.Desc);
            }
        }
    });

}
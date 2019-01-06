
var tempOnClick = 1;

$(document).ready(function () {
    setTimeout(function () {
        $("#support").fadeOut();
        $("#divMoney").fadeOut();
        $("#mContent").fadeOut();
        Intro();
    }, 500);
});

function Intro() {
    playAudioID("adBG1");
    var temp = 1;

    var myInterval = setInterval(function () {
        if (temp == 1)
            $("#support").fadeIn(3000);
        else if (temp == 2) {
            GetListPrize();            
        }
        //else if (temp == 3)
        //    $("#mContent").fadeIn(3000);
        if (temp >= 3)
            clearInterval(myInterval);
        temp++;
    }, 1000);
}

function GetListPrize() {
    $.ajax({
        url: "/PlayPage/Play/GetListPrize",
        type: "POST"  
    }).done(function (data) {        
        var source = document.getElementById('Prize-template').innerHTML;
        var template = Handlebars.compile(source);
        var html = template(data);
        $('#lstPrize').html(html);
        
        $("#divMoney").fadeIn(2000);
        LoadMoney();
    });
}

function LoadMoney() {
    $("#trmoney5").css('color', 'yellow');
    $("#trmoney10").css('color', 'yellow');
    $("#trmoney15").css('color', 'yellow');

    setTimeout(function () {
        var i = 1;
        var intervalMoney = setInterval(function () {
            playAudioID("adTeStart");
            if (i >= 2)
                $("#trmoney" + (i - 1).toString()).css('background-image', 'none');

            $("#trmoney" + i.toString()).css('background-image', 'url(\'../Images/fMoney.png\')');

            if (i >= 15) {
                clearInterval(intervalMoney);
                setTimeout(function () {
                    $("#trmoney15").css('background-image', 'none');
                    LoadCotMoc();
                }, 1000);
            }

            i++;
        }, 400);
    }, 1000);
}

function LoadCotMoc() {
    var i = 5;
    var intervalCotMoc = setInterval(function () {
        playAudioID("adTeStart");
        $("#trmoney" + i.toString()).css('background-image', 'url(\'../Images/fMoney.png\')');

        if (i >= 15) {
            clearInterval(intervalCotMoc);
            setTimeout(function () {
                playAudioID("adC1");
                $("#divMoney").fadeOut(200);
            }, 1000);

            setTimeout(function () {
                $("#mContent").fadeIn(3000);
            }, 2000);
        }

        i = i + 5;
    }, 800);
}

function Support5050() {
    if (tempOnClick == 1) {
        $("#btn5050").css('visibility', 'hidden');

        playAudioID("ad5050");
        QuestionID = document.getElementById("frQuestionID").value;
        $.ajax({
            url: "/PlayPage/Play/Support5050",
            type: "POST",
            data: { "QuestionID": QuestionID },
            success: function (data) {
                var res = data.split(";");

                $("#tdAnswer" + res[0].toString()).css('visibility', 'hidden');
                $("#tdAnswer" + res[1].toString()).css('visibility', 'hidden');
            }
        });
    }
}

function SupportCall() {
    if (tempOnClick == 1) {
        $("#btnCall").css('visibility', 'hidden');
        var time = 29;
        playAudioID("adTeStart");
        tempOnClick = 0;

        setTimeout(function () {
            $("#frCall30S").fadeIn(10);

            playAudioID("adCall");
            var intervalCotMoc = setInterval(function () {
                $("#frDis30S").html(time.toString());

                if (time <= 0) {
                    $("#frCall30S").fadeOut(10);
                    tempOnClick = 1;
                    clearInterval(intervalCotMoc);
                }

                time--;
            }, 1000);
        }, 1000);
    }
}

function SupportHKG() {
    if (tempOnClick == 1) {
        playAudioID("adHKG");
        $("#btnHKG").css('visibility', 'hidden');
        setTimeout(function () {
            QuestionID = document.getElementById("frQuestionID").value;
            $.ajax({
                url: "/PlayPage/Play/SupportHKG",
                type: "POST",
                data: { "QuestionID": QuestionID },
                success: function (data) {
                    var res = data.split(";");
                    InitChart(res[0], res[1], res[2], res[3]);
                    playAudioID("adRight");
                    $("#frHKG").css('visibility', 'visible');
                }
            });

        }, 2000);
    }
}

function InitChart(A, B, C, D) {
    var barData = {
        labels: ["A", "B", "C", "D"],
        datasets: [
            {
                label: 'Ý Kiến Khán Giả',
                data: [A, B, C, D],
                backgroundColor: [
                    'blue',
                    'blue',
                    'blue',
                    'blue'
                ],
                //borderColor: [
                //    'rgba(255,99,132,1)',
                //    'rgba(54, 162, 235, 1)',
                //    'rgba(255, 206, 86, 1)',
                //    'rgba(75, 192, 192, 1)'                    
                //],
                borderWidth: 1
            }
        ]
    }

    var options = { scaleFontSize: 20, scaleFontColor: "#ff8540" }
    // get bar chart canvas
    var income = document.getElementById("fCanvas").getContext("2d");

    var myBarChart = new Chart(income, {
        type: 'bar',
        data: barData,
        option: options
    });
    //var myBarChart = new Chart(income).bar(barData, options);
}

function SelectDA(AnswerLevel) {
    if (tempOnClick == 1) {
        tempOnClick = 0;
        ChangeColor(AnswerLevel);
        playAudioID("adSelectDA");

        setTimeout(function () {
            CheckAnswer(AnswerLevel);
        }, 2000);

        $("#frHKG").css('visibility', 'hidden');
    }
}

function Stop(Type) {
    if (Type == 1)
        playAudioID("adWrong");

    Level = document.getElementById("frLevel").value;
    $.ajax({
        url: "/PlayPage/Play/Stop",
        type: "POST",
        data: { "Level": Level, "Type": Type },
        success: function (data) {

        }
    });

    setTimeout(function () {
        window.location.href = "/Home/Index";
    }, 5000);

}

function GetMoney(QuestionLevel) {
    $.ajax({
        url: "/PlayPage/Play/GetMoney",
        type: "POST",
        data: { "QuestionLevel": QuestionLevel },
        success: function (data) {
            var money = parseInt(data);
            $("#fMoney").html(money.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
        }
    });
}

function ChangeColor(AnswerLevel) {
    $("#A" + AnswerLevel).css('background-color', '#ff6a00');
}

function ResetColor(AnswerLevel) {
    $("#A" + AnswerLevel).removeAttr('style');

    $("#tdAnswer1").removeAttr('style');
    $("#tdAnswer2").removeAttr('style');
    $("#tdAnswer3").removeAttr('style');
    $("#tdAnswer4").removeAttr('style');
}

function GetQuestionLevel(Level) {
    //$("#fContent").fadeOut();
    //$("#fAnswerA").fadeOut();
    //$("#fAnswerB").fadeOut();
    //$("#fAnswerC").fadeOut();
    //$("#fAnswerD").fadeOut();

    $.ajax({
        url: "/PlayPage/Play/GetQuestionLevel",
        type: "POST",
        data: { "Level": Level },
        success: function (data) {
            //var obj = JSON.parse(data);            
            $.each(data, function (key, value) {
                //setTimeout(function () {                  

                if (key == 'QuestionID') {
                    $("#frQuestionID").val(value);
                }
                else {
                    $("#f" + key).html(value);
                    //$("#f" + key).fadeIn(1000);

                    if (key == 'Level') {
                        $("#frLevel").val(value);
                    }
                }
                //}, 1000); 
            });
        }
    });
}

function CheckAnswer(AnswerLevel) {
    var QuestionID = document.getElementById("frQuestionID").value;
    var Level = document.getElementById("frLevel").value;

    $.ajax({
        url: "/PlayPage/Play/CheckAnswer",
        type: "POST",
        data: { "QuestionID": QuestionID, "AnswerLevel": AnswerLevel },
        success: function (data) {
            if (data == "1") {
                if (parseInt(Level) == 15) {
                    playAudioID("adRight5");
                    GetMoney(Level);

                    setTimeout(function () {
                        Stop(3);
                    }, 2000);

                    loadPopup("Chúc mừng", "Bạn đã chiến thắng", 0);
                }
                else {
                    $("#A" + AnswerLevel).css('background-color', 'green');
                    var timeout = 2000;
                    if (parseInt(Level) == 5 || parseInt(Level) == 10) {
                        playAudioID("adRight5");
                        timeout = 8000;
                    }
                    else {
                        playAudioID("adRight");
                    }
                    GetMoney(Level);

                    setTimeout(function () {
                        GetQuestionLevel(parseInt(Level) + 1);
                        ResetColor(AnswerLevel);
                        tempOnClick = 1;
                    }, timeout);

                }
            }
            else {
                playAudioID("adWrong");
                $("#A" + AnswerLevel).css('background-color', 'red');
                setTimeout(function () {
                    Stop(2);
                }, 2000);
            }
        }
    });
}

function DisableAnswer() {
    ////document.getElementById("tdAnswer1").onclick = false;

    //for (var i = 1; i <= 4; i++) {
    //    document.getElementById("tdAnswer" + i.toString()).onclick = false;
    //}
}

function EnableAnswer() {
    //for (var i = 1; i <= 4; i++) {
    //    document.getElementById("tdAnswer" + i.toString()).onclick = SelectDA(i);
    //}
}

function playAudioID(id) {
    document.getElementById(id).play();
}
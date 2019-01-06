setTimeout(function () {
    playAudio();
}, 2000);

function playAudio() {
    var AccountID = document.getElementById("fAccountID");

    if (AccountID != null) {
        document.getElementById("adIntro").play();
    }
}

function RedirecLogin() {
    window.location.href = "/AccountPage/Account";
};

function RedirecRegister() {
    window.location.href = "/AccountPage/Account/Register";
};

function RedirecQLCH() {
    window.location.href = "/QuestionPage/Question";
};

function RedirecPlay() {
    window.location.href = "/PlayPage/Play";
};

function RedirecHistory() {
    window.location.href = "/HistoryPage/History";
};


function LogOut() {
    $.ajax({
        url: "/AccountPage/Account/RemoveSession",
        type: "POST"
    });

    window.location.reload(false);
};


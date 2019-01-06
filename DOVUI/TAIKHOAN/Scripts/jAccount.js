
function CheckLogin() {
    var Username = document.getElementById("txtUsername").value;
    var Password = document.getElementById("txtPassword").value;
    //StartLoading();
    $.ajax({
        url: "/AccountPage/Account/CheckLogin",
        type: "POST",
        data: { "Username": Username, "Password": Password },
        success: function (data) {
            //StopLoading();
            if (data == "1") {
                window.location.href = '/';
            } else {
                //alert("Tên đăng nhập hoặc Mật khẩu không đúng!");
                loadPopup("Tên đăng nhập hoặc Mật khẩu không đúng!", "", 1);
            }
        },
        error: function (jqXHR, exception) {
            alert(exception);
            //StopLoading();
        }
    });
}


function Register() {
    var Fullname = document.getElementById("txtFullname").value;
    var Username = document.getElementById("txtUsername").value;
    var Password = document.getElementById("txtPassword").value;
    //StartLoading();
    $.ajax({
        url: "/AccountPage/Account/CreateAccount",
        type: "POST",
        data: { "Fullname": Fullname, "Username": Username, "Password": Password },
        success: function (data) {
            //StopLoading();
            if (data == "1") {
                loadPopup("Đăng ký thành công", "", 1);
                setTimeout(function () {
                    window.location.href = '/AccountPage/Account';
                }, 2000);
            } else if (data == "2") {
                loadPopup("Tên đăng nhập đã tồn tại", "", 1);
            } else if (data == "3") {
                loadPopup("Họ và tên không được để trống", "", 1);
            } else if (data == "4") {
                loadPopup("Tên đăng nhập không được để trống", "", 1);
            } else if (data == "5") {
                loadPopup("Mật khẩu không được để trống", "", 1);
            }
        },
        error: function (jqXHR, exception) {
            alert(exception);
            //StopLoading();
        }
    });
}


function RedirecRegister() {
    window.location.href = "/AccountPage/Account/Register";
};


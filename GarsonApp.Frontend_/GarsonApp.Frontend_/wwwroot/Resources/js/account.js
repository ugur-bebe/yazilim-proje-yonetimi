
$("#btn-login").click(function () {

    $.ajax({
        url: "login_check?password=" + $("#password").val() + "&email=" + $("#email").val(),
        contentType: "application/json; charset=utf-8",
        type: "get",
        cache: false,
        success: function (data, textStatus, xhr) {
            statusCode = xhr.status;
            if (statusCode == 200) {
                window.location.href = "/index";
            }
            else {
                alert("Hatalı Giriş");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });

});
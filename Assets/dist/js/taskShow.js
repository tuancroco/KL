$('#task').click(function () {
    var t = this;
    $.ajax({
        type: "POST",
        url: '/Events/ShowTaskPercent',
        success: function (data) {
            var d = data;
            $(data).insertAfter($('#task'))
        }

    });
});
$('#clLogin').click(function () {
    var t = this;
    $.ajax({
        type: "POST",
        url: '/Events/ClickLogin',
        success: function (data) {
            var d = data;
            $(data).insertAfter($('#loginForm'))
        }

    });
});
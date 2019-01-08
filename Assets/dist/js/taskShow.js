$('a#task').click(function () {
    $.ajax({
        type: "POST",
        url:'',
        data:data,
        success: success,

    });
});
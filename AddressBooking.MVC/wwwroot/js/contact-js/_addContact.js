//
function AddContact() {
    var form = $("#contactForm");
    var actionUrl = "https://localhost:44382/api/Contact/AddContact";

    $.ajax({
        url: actionUrl,
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: form.serialize(),
        success: function (data, textstatus, jqXHR) {
            //process data
        },
        error: function (jqXHR, textstatus, exception) {
            //process exception
        }
    });
}


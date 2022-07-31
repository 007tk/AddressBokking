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
            console.log(data);
            $("#addContactModal").hide();
            location.reload();
        },
        error: function (jqXHR, textstatus, exception) {
            console.log(exception);
        }
    });
}


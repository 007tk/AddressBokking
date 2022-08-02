// Update Contact
function UpdateContact() {
    var form = $("#contactForm");
    var actionUrl = "https://localhost:44382/api/Contact/UpdateContact";

    $.ajax({
        url: actionUrl,
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: form.serialize(),
        success: function (data, textstatus, jqXHR) {
            console.log(data);
            location.reload();
        },
        error: function (jqXHR, textstatus, exception) {
            console.log(exception);
        }
    });
}
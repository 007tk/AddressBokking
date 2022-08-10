// Update Contact
$(function () {
    $("#btnUpdateSubmit").click(function () {
        if ($("#contactForm").valid()) {
            $('#contactForm').submit();
        }
        else {
            return false;
        }
    });

    $("#contactForm").on("submit", function (event) {
        event.preventDefault();
        var form = $("#contactForm");
        var actionUrl = "https://localhost:44382/api/Contact/UpdateContact";

        $.ajax({
            type: "POST",
            url: actionUrl,
            data: form.serialize(),
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            success: function (data, response) {
                console.log(data);
                alert("Contact updated");
            },
            error: function (jqXHR, textstatus, exception) {
                console.log(exception);
            }
        });
    });
})
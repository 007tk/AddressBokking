
$(function () {
    $("#btnSubmit").click(function () {
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
        var actionUrl = "https://localhost:44382/api/Contact/AddContact";
        var mergeUrl = "https://localhost:44382/api/Contact/MergeContact";

        $.ajax({
            type: "POST",
            url: actionUrl,
            data: form.serialize(),
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            success: function (data, response) {
                console.log(data);
                var results = data;
                if (results.includes("Found duplicate")) {
                    Swal.fire({
                        title: 'Oops we found a duplicate!',
                        text: "You won't be able to revert this!",
                        icon: 'warning',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Update Anyway!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: mergeUrl,
                                data: form.serialize(),
                                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                                success: function (data, response) {
                                    console.log(data);
                                }
                            });
                        }
                    })
                }
                else if (data === 'Contact Inserted') {
                    $("#addContactModal").hide();
                    location.reload();
                }
            },
            error: function (jqXHR, textstatus, exception) {
                console.log(exception);
            }
        });
    });
})
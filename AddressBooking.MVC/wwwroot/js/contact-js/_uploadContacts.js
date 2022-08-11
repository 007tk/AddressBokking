// Upload csv via ajax
$("#uploadCsvBtn").click(function () {
    var uploadCsvUrl = "https://localhost:44382/api/Contact/UploadContacts"
    var fileUpload = document.getElementById("contactsCsvFile");
    if (fileUpload.value != null) {
        var uploadFile = new FormData();
        var files = $("#contactsCsvFile").get(0).files;
        // Add the uploaded file content to the form data collection  
        if (files.length > 0) {
            uploadFile.append("CsvDoc", files[0]);
            $.ajax({
                url: uploadCsvUrl,
                contentType: false,
                processData: false,
                data: uploadFile,
                type: 'POST',
                success: function () {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Contacts uploaded successfully',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    setTimeout(function () {
                        location.reload();
                    }, 1500);
                },
                error: function (jqXHR, textstatus, exception) {
                    console.log(exception);
                }
            });
        }
    }
});

$("#contactsCsvFile").change(function () {
    var selectedText = $("#contactsCsvFile").val();
    var extension = selectedText.split('.');
    if (extension[1] != "csv") {
        $("#uploadContactsModal").focus();
        alert("Please choose a .csv file");
        return;
    }
    $("#uploadContactsModal").val(selectedText);

});
function deleteContact(data){
    var actionUrl = "https://localhost:44382/api/Contact/DeleteContact?id="+data;

    $.ajax({
        url: actionUrl,
        type: 'GET',
        dataType: 'json', // added data type
        success: function (res) {
            console.log(res);
            alert(res);
            $('#contactTable').DataTable().ajax.reload();
        }
    });
}
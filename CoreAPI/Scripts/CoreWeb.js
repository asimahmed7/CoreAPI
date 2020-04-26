
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "/api/CoreAPI/ListEmpoyees",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //alert(JSON.stringify(data));
                $("#DIV").html('');
                var DIV = '';
                $.each(data, function (i, item) {
                    var rows = "<tr>" +
                        "<td id='RegdNo'>" + item.empID + "</td>" +
                        "<td id='Name'>" + item.name + "</td>" +
                        "<td id='Email'>" + item.email + "</td>" +
                        "<td id='Department'>" + item.department + "</td>" +
                        "<td id='Chcek'>" + "</td>" +
                        "</tr>";
                    $('#Table').append(rows);
                }); //End of foreach Loop
                console.log(data);
            }, //End of AJAX Success function

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function

        });
});

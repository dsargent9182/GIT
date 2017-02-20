$().ready(function () {

    if (sessionStorage.getItem('accessToken') == null) {
        window.location.href = "Login.html";
    }

    $('#btnLoad').click(function () {
        $('#successModal').modal('show');
        $.ajax({
            //url: '/webapi3/api/values/',
            url: '/api/values/',
            method: 'GET',
            headers: {
                'Authorization': 'Bearer ' + sessionStorage.getItem('accessToken')
            },
            success: function (data) {
                $('#divData').removeClass('hidden');
                $('#successModal').modal('hide');
                $.each(data, function (index, value) {
                    var row = '<tr><td>' + value.FullMemberNumber + '</td>'
                    + '<td>' + value.Business + '</td>'
                    + '<td>' + value.ActivityDate + '</td>'
                    + '<td>' + value.ProductDescription + '</td>'
                    + '<td>' + value.MemberValue + '</td></tr>';
                    $('#tblBody').append(row);
                });
            },
            error: function (jqXHR) {
                $('#dvErrorText').text(jqXHR.responseText);
                $('#dvError').show('fade');
            }
        });
        //alert('hello');
    });

    $('#linkClose').click(function () {
        $('#dvError').hide('fade');
    });
    $('#btnLogOut').click(function () {
        sessionStorage.removeItem('accessToken');
        window.location.href = 'Login.html';
    });

});
$().ready(function () {
    $('#btnLogin').click(function () {
        $('#successModal').modal('show');

        $.ajax({
            //            url: '/webApi3/token',
            url: '/token',
            method: 'POST',
            contentType: 'application/json',
            data: {
                username: $('#txtUserName').val(),
                password: $('#txtPassword').val(),
                grant_Type: 'password'
            },
            success: function (response) {
                sessionStorage.setItem('accessToken', response.access_token);
                window.location.href = 'Data.html';
            },
            error: function (jqXHR) {
                $('#successModal').modal('hide');
                $('#dvErrorText').text(jqXHR.responseText);
                $('#dvError').show('fade');
            }
        });
    });

    $('#linkClose').click(function () {
        $('#dvError').hide('fade');
    });

});
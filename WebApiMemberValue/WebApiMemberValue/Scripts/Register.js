$().ready(function () {

    $('#btnRegister').click(function () {
        $.ajax({
            //url: '/webApi3/api/Account/Register',
            url: '/api/Account/Register',
            method: 'POST',
            data: {
                email: $('#txtEmail').val(),
                password: $('#txtPassword').val(),
                confirmPassword: $('#txtConfirmPassword').val(),
            },
            success: function () {
                $('#successModal').modal('show');
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

});
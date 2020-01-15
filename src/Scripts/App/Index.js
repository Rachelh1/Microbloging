$(document).ready(function () {
    $("#post").emojioneArea({
        hideSource: true,
        pickerPosition: "bottom",
    });
    $("#submit-btn").click(function (e) {
        e.preventDefault();

        var $container = $('#post-container');
        var $postTextInput = $('#post');
        var post = $postTextInput.val();

        var fd = new FormData();
        var files = $('#file')[0].files[0];
        fd.append('file', files);
        fd.append('post', post)

        $.ajax({
            url: '/home/post',
            type: 'post',
            data: fd,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response != 0) {

                    $container.prepend(response);
                    $postTextInput.val('');
                    $('.emojionearea-editor').html('');
                    $('#file').val(null)

                } else {
                    alert('file not uploaded');
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Error Thrown');
            }
        });
    });
});
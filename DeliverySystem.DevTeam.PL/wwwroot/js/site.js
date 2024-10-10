var UpdateNewRow;

function ShowSuccessFullyMessage(Message = 'Saved SuccessFully') {

    Swal.fire({
        icon: "success",
        title: "success",
        text: Message,
        customClass: {
            confirmButton: "btn btn-outline btn-outline-dashed btn-outline-primary btn-active-light-primary"
        }

    });

}


function ShowErrorMessage(Message = 'Something went wrong!') {

    Swal.fire({
        icon: "error",
        title: "error",
        text: Message,
        customClass: {
            confirmButton: "btn btn-outline btn-outline-dashed btn-outline-danger btn-active-light-danger"
        }

    });

}



function OnModalSuccess(item) {


    if (UpdateNewRow === undefined) {
        $('tbody').append(item);

    } else {
        $(UpdateNewRow).replaceWith(item);
    }



    ShowSuccessFullyMessage();
    $('#Modal').modal('hide');;
}

$(document).ready(function () {


    var Message = $('#Message').text();
    if (Message !== '') {

        ShowSuccessFullyMessage(Message);
    }



    // Handle Bootstrap Moadl


    $('body').delegate('.js-render-modal', 'click', function () {

        var Modal = $('#Modal');
        var btn = $(this);
        $('#ModalLabel').text(btn.data('title'));

        if (btn.data('update') !== undefined) {
            UpdateNewRow = btn.parents('tr');
            //console.log(UpdateNewRow);
        }
        $.get({
            url: btn.data('url'),

            success: function (form) {
                $('.modal-body').html(form);

                $.validator.unobtrusive.parse(Modal);

            },


            error: function () {
                ShowErrorMessage();
            },
        })

        Modal.modal('show');
    });

});

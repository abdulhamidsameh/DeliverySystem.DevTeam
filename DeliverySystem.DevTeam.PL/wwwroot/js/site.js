

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



$(document).ready(function () {


    var Message = $('#Message').text();
    if (Message !== '') {

        ShowSuccessFullyMessage(Message);
    }


});

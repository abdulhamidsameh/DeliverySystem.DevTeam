var UpdateNewRow;
var datatable;
var exportCols = [];

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


    if (UpdateNewRow !== undefined) {

        datatable.row(UpdateNewRow).remove().draw();
        UpdateNewRow == undefined;

          //$('tbody').append(item);

    }

    var NewRow = $(item);
    datatable.row.add(NewRow).draw();



    ShowSuccessFullyMessage();
    $('#Modal').modal('hide');;
}




$(document).ready(function () {


    var Message = $('#Message').text();
    if (Message !== '') {

        ShowSuccessFullyMessage(Message);
    }


    // Date Table

    KTUtil.onDOMContentLoaded(function () {
        KTDatatablesExample.init();
    });


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





    /// Toggle status 
    // On document ready

    $('body').delegate('.Js-toggle-status', 'click', function () {

        var btn = $(this);
        var id = btn.data('id');


        bootbox.confirm({
            message: 'Are you sure you want to change the status of this product?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {

                if (result) {
                    $.post({
                        url: btn.data('url'),

                        success: function (LastUpdatedOn) {
                            // js-update
                            var row = btn.parents('tr');
                            var status = row.find('.js-status');
                            var NewStatus = status.text().trim() === 'Deleted' ? 'Available' : 'Deleted'
                            status.text(NewStatus).toggleClass('badge badge-danger badge badge-primary');
                            row.find('.js-update').html(LastUpdatedOn);
                            row.addClass('animate__animated animate__bounce');
                            ShowSuccessFullyMessage();
                        },

                        error: function () {


                            ShowErrorMessage();
                        }
                    });
                }
            }
        });




    });
});



/// Data Table

var headers = $('th');
$.each(headers, function (i) {

    var col = $(this);

    if (!col.hasClass('js-no-export')) {
        exportCols.push(i);
        // هنا بنهندل جزء وهو بيطبع يخفي ال edit and status
        // كمال لو مش فاهم حاجه هنا عرفني عشان كل ده شغال Generic 
        // By Ahmed Farouk ................ 
    };
});





"use strict";

// Class definition
var KTDatatablesExample = function () {
    // Shared variables
    var table;


    // Private functions
    var initDatatable = function () {
        // Set date data order
        const tableRows = table.querySelectorAll('tbody tr');

        tableRows.forEach(row => {
            const dateRow = row.querySelectorAll('td');
            const realDate = moment(dateRow[3].innerHTML, "DD MMM YYYY, LT").format(); // select date from 4th column in table
            dateRow[3].setAttribute('data-order', realDate);
        });

        // Init datatable --- more info on datatables: https://datatables.net/manual/
        datatable = $(table).DataTable({
            "info": false,
            'order': [],
            'pageLength': 10,
        });
    }

    // Hook export buttons
    var exportButtons = () => {
        const documentTitle = $('.js-datatable').data('document-title');

        var buttons = new $.fn.dataTable.Buttons(table, {
            buttons: [
                {
                    extend: 'copyHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportCols
                    }
                },
                {
                    extend: 'excelHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportCols
                    }
                },
                {
                    extend: 'csvHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportCols
                    }
                },
                {
                    extend: 'pdfHtml5',
                    title: documentTitle,
                    exportOptions: {
                        columns: exportCols
                    }
                }
            ]
        }).container().appendTo($('#kt_datatable_example_buttons'));

        // Hook dropdown menu click event to datatable export buttons
        const exportButtons = document.querySelectorAll('#kt_datatable_example_export_menu [data-kt-export]');
        exportButtons.forEach(exportButton => {
            exportButton.addEventListener('click', e => {
                e.preventDefault();

                // Get clicked export value
                const exportValue = e.target.getAttribute('data-kt-export');
                const target = document.querySelector('.dt-buttons .buttons-' + exportValue);

                // Trigger click event on hidden datatable export buttons
                target.click();
            });
        });
    }

    // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
    var handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }

    // Public methods
    return {
        init: function () {
            table = document.querySelector('.js-datatable');

            if (!table) {
                return;
            }

            initDatatable();
            exportButtons();
            handleSearchDatatable();
        }
    };
}();





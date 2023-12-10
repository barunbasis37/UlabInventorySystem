$(document).ready(function () {
var table = $("#approvalItemProcessingList").DataTable({
    ajax: {
        url: "../api/Requisition/GetApprovedItemList",
        dataSrc: ""
    },
    columns: [
        {
            title: "Emp_Info",
            "data": "employeeId",
            "render": function (data, type, row, meta) {
                return row.employeeId + "<br/> (" + row.employeeName + ") <br/> (" + row.campus + "-" + row.floor + "-" + row.room + ")";

            },
            "width": "15%"
        },
        {
            title: "Device_Id",
            data: "deviceId"
        },
        {
            title: "Req_D Id",
            data: "requisitionDId"

        },
        {
            title: "Item_Info",
            "data": "item",
            "render": function (data, type, row, meta) {
                return row.item + "<br/> (" + row.model + ") <br/> (" + row.size + "-" + row.brand + ")<br/>(" + row.category + "-" +row.subcategory + ")";

            },
            "width": "20%"
        },
        {
            title: "Type",
            data: "requisitionType"

        },
        
        {
            title: "Department",
            data: "department"
        },
        
        {
            title: "Issued",
            data: "requisitionDId",
            render: function (data) {
                return "<button class='btn btn-success js-add' data-device-id=" + data + "> Issued </button>";
            }
        }
        
    ]

});



$("#approvalItemProcessingList tbody").on("click", ".js-add", function () {
    var _this = this;
    var button = $(this);
    var data = table.row(button.parents('tr')).data();

    var approvedRemarksData = $(this).parents('tr').first().find('input').val();

    var url = "../requisitionDetailsMultiple/issuedRequisitionDetails?requisitionDetailId=" + data.requisitionDId;


    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.status) {
                toastr.success('Successfully Issued Requisition');
                table.ajax.reload();
            } else {
                toastr.warning('Data Not updated. Contact Administrator');
            }
        },
        error: function () {
            toastr.error('System Error.Contact Administrator ');
        }
    });
});

});




















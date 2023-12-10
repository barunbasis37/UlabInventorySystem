$(document).ready(function () {
var table = $("#requisitionItemProcessingList").DataTable({
    ajax: {
        url: "../Api/Requisition/GetRequisitionItemList",
        type: "GET",
        datatype: "json",
        dataSrc: ""
    },
    columns: [
        {
            title: "Emp_Info",
            "data": "employeeId",
            "render": function (data, type, row, meta) {
                return "<b>ID:</b> " + row.employeeId + " (" + row.employeeName + ") <br/> <b>Location:</b> (" + row.campus + "-F: " + row.floor + "- R: " + row.room + ")<br/> <b>Req_D Id:</b> " + row.requisitionDId;

            },
            "width": "15%"
        },
        //{
        //    title: "Req_D Id",
        //    data: "requisitionDId",
        //    width: "2%"

        //},
        //{
        //    title: "Requisition",
        //    data: "requisition",
        //    width: "2%"

        //},
        {
            title: "Type",
            data: "requisitionType",
            width: "2%"

        },
        
        {
            title: "Department",
            data: "department",
            width: "2%"
        },
        {
            title: "Item_Info",
            "data": "item",
            "render": function (data, type, row, meta) {
                return "<b>Device Id:</b> " + row.deviceId + "<br/> <b>Item Info:</b> " + row.item + " (" + row.model + "-" + row.size + "-" + row.brand + ")";
                /*+ ")<br/>(" + row.category + "-" + row.subcategory + ")"*/

            },
            "width": "20%"
        },
        //{
        //    title: "Device_Id",
        //    data: "deviceId",
        //    width: "2%"
        //},
        {
            title: "Remarks",
            data: "approveRemarks",
            render: function (data, type, row) {
                return '<input class="form-control" id="approvedRemarks" name="Comments" maxlength="350" multiline="true" type="text"  value =' + row.approveRemarks + '>';

            },
            width: "2%"
        },
        {
            title: "Approved",
            data: "requisitionDId",
            render: function (data) {
                return "<button class='btn btn-success js-add' data-device-id=" + data + "> Approved </button>";
            },
            width: "2%"
        },
        {
            title: "Denied",
            data: "requisitionDId",
            render: function (data) {
                return "<button class='btn btn-danger js-denied' data-device-id=" + data + "> Denied </button>";
            },
            width: "2%"
        }

        //{
        //    "data": "requisitionDId",
        //    "render": function (data) {
        //        return `
        //                    <div class="text-center">
        //                        <a href="/Admin/CoursePolicyProcedure/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    
        //                            <i class="bi bi-pencil-square"></i>
        //                        </a>
        //                        <a onclick=Delete("../RequisitionDetailsMultiple/DeniedRequisitionDetails/${data}") class="btn btn-danger text-white" style="cursor:pointer">
        //                            Denied
        //                        </a>
        //                    </div>
        //                   `;
        //    }, "width": "3%"
        //}
        //{
        //    title: "Request",
        //    data: "alumniID",
        //    render: function (data) {
        //        return "<button class='btn btn-success js-save' data-device-id=" + data.code + "> Save</button>";
        //    }
        //}
    ],
    rowsGroup: [0, 0]

});



$("#requisitionItemProcessingList tbody").on("click", ".js-add", function () {
    var _this = this;
    var button = $(this);
    var data = table.row(button.parents('tr')).data();

    var approvedRemarksData = $(this).parents('tr').first().find('input').val();

    var url = "../requisitionDetailsMultiple/approvedRequisitionDetails?requisitionDetailId=" + data.requisitionDId + "&approvedRemarks=" + approvedRemarksData;


    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.status) {
                toastr.success('Successfully Approved Requisition');
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

$("#requisitionItemProcessingList tbody").on("click", ".js-denied", function () {
    var _this = this;
    var button = $(this);
    var data = table.row(button.parents('tr')).data();

    var deniedRemarksData = $(this).parents('tr').first().find('input').val();

    var url = "../requisitionDetailsMultiple/deniedRequisitionDetails?requisitionDetailId=" + data.requisitionDId + "&deniedRemarksData=" + deniedRemarksData;


    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.status) {
                toastr.warning('Denied Requisition');
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




















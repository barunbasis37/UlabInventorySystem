$(document).ready(function () {
    var table = $("#issuedItemProcessingList").DataTable({
    ajax: {
        url: "../Api/IssueApproved/GetIssueApprovedItemList",
        type: "GET",
        datatype: "json",
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
            title: "Req_D Id",
            data: "requisitionDId",
            width: "2%"

        },
        //{
        //    title: "Requisition",
        //    data: "requisition",
        //    width: "2%"

        //},
        {
            title: "Type",
            data: "issueTypeName",
            width: "2%"

        },
        
        {
            title: "Department",
            data: "empDepartment",
            width: "2%"
        },
        {
            title: "Device_Id",
            data: "deviceId",
            width: "2%"
        },
        {
            title: "Item_Info",
            "data": "itemName",
            "render": function (data, type, row, meta) {
                return row.itemName + "<br/> (" + row.itemModel + ") <br/> (" + row.itemSize + "-" + row.itemBrand + ")<br/>(" + row.itemCategory + "-" + row.itemSubcategory + ")";

            },
            "width": "20%"
        },
        {
            title: "Remarks",
            data: "returnRemarks",
            render: function (data, type, row) {
                return '<input class="form-control" id="approvedRemarks" name="Comments" maxlength="350" multiline="true" type="text"  value =' + row.returnRemarks + '>';

            },
            width: "2%"
        },
        {
            title: "Return",
            data: "issueApprovedId",
            render: function (data) {
                return "<button class='btn btn-success js-add' data-device-id=" + data + "> Return </button>";
            },
            width: "2%"
        },
        {
            title: "Disposal",
            data: "issueApprovedId",
            render: function (data) {
                return "<button class='btn btn-danger js-disposal' data-device-id=" + data + "> Disposal </button>";
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



    $("#issuedItemProcessingList tbody").on("click", ".js-add", function () {
    var _this = this;
    var button = $(this);
    var data = table.row(button.parents('tr')).data();

        var returnRemarkData = $(this).parents('tr').first().find('input').val();
        //var currentStatus = "Damage";
        var url = "../issueApproval/returnIssueItemUpdate?issueAppId=" + data.issueApprovedId + "&returnRemarks=" + returnRemarkData;


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

    $("#issuedItemProcessingList tbody").on("click", ".js-disposal", function () {
    var _this = this;
    var button = $(this);
    var data = table.row(button.parents('tr')).data();

        var disposalRemarkData = $(this).parents('tr').first().find('input').val();

        var url = "../issueApproval/damageIssueItemUpdate?issueAppId=" + data.issueApprovedId + "&disposalRemarks=" + disposalRemarkData;


    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.status) {
                toastr.warning('Disposal Occured');
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




















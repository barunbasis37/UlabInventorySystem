
var table = $("#issueItemProcessingList").DataTable({
    ajax: {
        url: "../api/issue/getIssueItemList",
        type: "GET",
        datatype: "json",
        dataSrc: ""
    },
    columns: [
        {
            title: "Issue Detail Id",
            data: "issueDetailId"
            
        },
        {
            title: "Device Info",
            "data": "deviceId",
            "render": function (data, type, row, meta) {
                return row.deviceId + "<br/> (" + row.cpuId + ")";
            },
            "width": "15%"
            
        },
        {
            title: "User Info",
            "data": "employeeId",
            "render": function (data, type, row, meta) {
                return row.employeeId + "<br/> (" + row.employeeName + ")<br/>" + row.empDepartment;
            },
            "width": "15%"
        },
        {
            title: "Item",
            "data": "itemModel",
            "render": function (data, type, row, meta) {
                return row.itemModel + "<br/> (" + row.itemBrand + ") <br/>" + row.itemSize;
            },
            "width": "15%"
        },
        {
            title: "Is Approved",
            data: "isApproved"
        },
        {
            title: "Issue Type",
            data: "issueTypeName"
        },
        //{
        //    title: "Device Return Remarks",
        //    data: "deviceReturnRemarks",
        //    render: function (data, type, row) {
        //        return '<input class="form-control" id="deviceReturnRemarks" name="Comments" maxlength="350" multiline="true" type="text"  value =' + row.deviceReturnRemarks + '>';

        //    }
        //},
        {
            title: "Issue Date",
            data: "issueDate"
        },

        //{
        //    title: "Return",
        //    data: "issueDetailId",
        //    render: function (data) {
        //        return "<button class='btn btn-success js-add' data-device-id=" + data + "> Return </button>";
        //    }
        //},
        
        //{
        //    title: "Edit",
        //    data: "issueDetailId",
        //    render: function (data) {
        //        return "<button class='btn btn-success js-save' data-device-id=" + data.code + "> Modify</button>";
        //    }
        //}
    ]

});



$("#issueItemProcessingList tbody").on("click", ".js-save", function () {
    var _this = this;
    var button = $(this);
    //var name = $('td', this).eq(1).text();
    var data = table.row(button.parents('tr')).data();
    var radioButtons = document.getElementsByName("printCheckType");
    var statusSelectedValue = 0;
    for (var x = 0; x < radioButtons.length; x++) {
        if (radioButtons[x].checked) {
            statusSelectedValue = radioButtons[x].value;
        }
    }

    
    var deviceReturnRemarksData = $(this).parents('tr').first().find('input').val();

    var currentStatus = "Return";

    var url = "../issueDetailsMultiple/ModifiedIssueDetails?issueDetailId=" + data.issueDetailId + "&deviceReturnRemarks=" + deviceReturnRemarksData + "&currentStatus=" + currentStatus;


    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.status) {
                toastr.success('Successfully Update Visitor Status');
            } else {
                toastr.warning('Data Not updated. Contact Administrator');
            }
        },
        error: function () {
            toastr.error('System Error.Contact Administrator ');
        }
    });
});


















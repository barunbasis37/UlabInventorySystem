$(document).ready(function () {
    var table = $("#requisitionItemStatusList").DataTable({
    ajax: {
            url: "../Api/Requisition/GetRequisitionItemStatus",
        type: "GET",
        datatype: "json",
        dataSrc: ""
    },
        columns: [
            {
                title: 'id',
                data: null,
                render: (data, type, row, meta) => meta.row + 1,
                width: "1%"
            },
        {
            title: "Emp_Info",
            data: "employeeId",
            render: function (data, type, row, meta) {
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
        {
            title: "Is_Approved",
            data: "isApproved",
            render: function (data, type, row) {
                return `<span>${row.isApproved == 1 ? '<b class="text-success">Approved</b>' : '<b class="text-danger">Not Approved</b>'}<span>`;
            },
            width: "2%"
            },
        {
            title: "Is_Issued",
            data: "isIssued",
            render: function (data, type, row) {
                return `<span>${row.isIssued == 1 ? '<b class="text-success">Issued</b>' : '<b class="text-danger">Pending</b>'}<span>`;
            },
            width: "2%"
            },
        //{
        //    title: "Is_Denied",
        //    data: "isDenied",
        //    render: function (data, type, row) {
        //        return `<span>${row.isDenied == 1 ? '<b class="text-danger">Denied</b>' : ' '}<span>`;
        //    },
        //    width: "2%"
        //},
        {
            title: "Remarks",
            data: "approveRemarks",
            width: "2%"
        },
        
    ],
        rowsGroup: [0, 0],


});



});




















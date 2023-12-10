$(document).ready(function () {
    
    var radioButtons = document.getElementsByName("statusType");
    var statusSelectedValue="Device";
    for (var x = 0; x < radioButtons.length; x++) {
        if (radioButtons[x].checked) {
            statusSelectedValue = radioButtons[x].value;
        }
    }

    var table = $("#checkinDetails").DataTable({
        ajax: {
            url: "../api/CheckInDetails/GetDeviceDetails?statusSelectedValue=" + statusSelectedValue,
            dataSrc: ""

        },
        columns: [
            {
                title:"CPU Code",
                data: "cpuCode",
                visible: false
            },
            {
                title: "Device Code",
                data: "deviceCode"
            },
            {
                title: "Item Name",
                data: "itemCName"
            },
            {
                title: "Item Details",
                data: "itemDetailsId"
            },
            {
                title: "Item Brand",
                data: "itemBrand"
            },
            {
                title: "Item Size",
                data: "itemSize"
            },
            {
                title: "Audit Code",
                data: "auditCode"
            },
            {
                title: "Invoice No",
                data: "invoiceNo"
            },
            //{
            //    data: "unitprice"
            //},
            {
                title: "Warranty Expire Date",
                data: "warrantyExpireDate"
            },
            {
                title: "Product Serial No",
                data: "productSerialNo"
            },
            //{
            //    data: "itemStatus"
            //},
            {
                title: "Current Status",
                data: "currentStatus"
            },
            //{
            //    data: "remarks"
            //},
            //{
            //    title: "Device Add",
            //    data: "deviceCode",
            //    render: function (data) {
            //        return "<button class='btn btn-success js-add' data-device-id=" + data + "> Device Add</button>";
            //    }
            //},
            //{
            //    title: "CPU Add",
            //    data: "cpuCode",
            //    render: function (data) {
            //        return "<button class='btn btn-success js-add' data-device-id=" + data + "> CPU Add</button>";
            //    },
            //    visible: false
            //}

        ],
        rowsGroup: [0, 12]

    });

    $('input:radio').click(function () {
        var radioButtons = document.getElementsByName("statusType");
        //var statusSelectedValue = "CPU";
        for (var x = 0; x < radioButtons.length; x++) {
            if (radioButtons[x].checked) {
                var statusSelectedValue = radioButtons[x].value;
                table.ajax.url("../api/CheckInDetails/GetDeviceDetails?statusSelectedValue=" + statusSelectedValue).load();
                if (statusSelectedValue === "CPU") {
                    table.columns(0).visible(true);
                    table.columns(11).visible(false);
                    table.columns(12).visible(true);
                } else {
                    table.columns(0).visible(false);
                    table.columns(11).visible(true);
                    table.columns(12).visible(false);
                }

            }
        }



    });

});


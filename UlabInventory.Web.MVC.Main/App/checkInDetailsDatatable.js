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
                title: "CheckIn Detail",
                data: "checkInDetailId"
            },
            {
                title: "Item Name",
                data: "itemCName"
            },
            //{
            //    title: "Item Model",
            //    "data": "itemModel",
            //    "render": function (data, type, row, meta) {
            //        return row.itemModel + "<br/> (" + row.itemBrand + ") <br/>" + row.itemSize;
            //    },
            //    "width": "1%"
            //},
            {
                title: "Item Model",
                data: "itemModel"
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
            {
                title: "Device Add",
                data: "deviceCode",
                render: function (data) {
                    return "<button class='btn btn-success js-add' data-device-id=" + data + "> Device Add</button>";
                }
            },
            {
                title: "CPU Add",
                data: "cpuCode",
                render: function (data) {
                    return "<button class='btn btn-success js-add' data-device-id=" + data + "> CPU Add</button>";
                },
                visible: false
            }

        ],
        rowsGroup: [0, 13]

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
                    table.columns(12).visible(false);
                    table.columns(13).visible(true);
                } else {
                    table.columns(0).visible(false);
                    table.columns(12).visible(true);
                    table.columns(13).visible(false);
                }

            }
        }


        //var selectRadioValue = "Device";
        //if ($(this).attr('id') === "cpuId") {
        //    selectRadioValue = "Device";
        //    table.ajax.url("/api/CheckInDetails/GetDeviceDetails?statusSelectedValue=" + selectRadioValue).load();
        //} else {
        //    selectRadioValue = "CPU";
        //    table.ajax.url("/api/CheckInDetails/GetDeviceDetails?statusSelectedValue=" + selectRadioValue).load();
        //}

    });

    $("#checkinDetails tbody").on("click", ".js-add", function () {
        var button = $(this);
        var data = table.row(button.parents('tr')).data();
        //alert( data[0] +"'s salary is: "+ data[ 5 ] );
        //var cells = [];
        //var rows = $("#checkinDetails").dataTable().fnGetNodes();
        //for (var i = 0; i < rows.length; i++) {
        //    // Get HTML of 3rd column (for example)
        //    cells.push($(rows[i]).find("td:eq(2)").html());
        //}
        //console.log(cells);
        //var radioButtons = document.getElementsByName("statusType");
        //var statusSelectedValue = "CPU";
        for (var x = 0; x < radioButtons.length; x++) {
            if (radioButtons[x].checked) {
                var statusSelectedValue = radioButtons[x].value;
                
                if (statusSelectedValue === "CPU") {
                    bootbox.confirm("Are you sure you want to Add ,<br /><b>CPU Code: " + data.cpuCode + "</b><br /><b>Check-In Detail Id: " + data.checkInDetailId + "</b><br /> in the Issue Details list?", function (result) {

                        if (result) {
                            //$(this).toggleClass('row_selected');
                            //$("#checkinDetails tr").children("td").first().css({ "background-color": "#C94BCB" });
                            //table.row(button.parents('tr')).style.backgroundColor = '#000000';
                            var data1 = table.rows().data();
                            data1.each(function (value, index) {
                                if (value.cpuCode===data.cpuCode) {
                                    document.getElementById("cpuCode").value = value.cpuCode;
                                    document.getElementById("deviceCode").value = value.deviceCode;
                                    document.getElementById("checkInDetailId").value = value.checkInDetailId;
                                    document.getElementById("itemName").value = value.itemCName;
                                    document.getElementById("itemModel").value = value.itemModel;
                                    document.getElementById("itemBrand").value = value.itemBrand;
                                    document.getElementById("itemSize").value = value.itemSize;
                                    table.row(button.parents('tr')).remove().draw(false);
                                    var $newRow = $('#mainIssueDetailsrow').clone().removeAttr('id');
                                    $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
                                    $('#cpuCode,#deviceCode,#checkInDetailId,#itemName,#itemModel,#itemBrand,#itemSize,#add', $newRow).removeClass('hidden').addClass('show');
                                    $('#cpuCode,#deviceCode,#checkInDetailId,#itemName,#itemModel,#itemBrand,#itemSize,#add', $newRow).removeAttr('id');
                                    $('#requisitiondetailsStore').append($newRow);
                                    $('#cpuCode,#deviceCode,#checkInDetailId,#itemName,#itemModel,#itemBrand,#itemSize').val('');
                                }
                                
                                
                            });

                        }
                    });
                } else {
                    bootbox.confirm("Are you sure you want to Add , <table class='table table-responsive table-bordered'><tr><td>Check-In Detail Id:</td><td>" + data.checkInDetailId + "</td></tr><tr><td>CPU Code:</td><td>" + data.cpuCode + "</td></tr><tr><td>Device Code:</td><td>" + data.deviceCode + "</td></tr><tr><td>Item Name:</td><td>" + data.itemCName + "</td></tr><tr><td>Item Model:</td><td>" + data.itemModel + "</td></tr><tr><td>Item Brand:</td><td>" + data.itemBrand + "</td></tr><tr><td>Item Size:</td><td>" + data.itemSize + "</td></tr></table> in the Issue Details list?", function (result) {

                        if (result) {
                            
                            document.getElementById("cpuCode").value = data.cpuCode;
                            document.getElementById("deviceCode").value = data.deviceCode;
                            document.getElementById("checkInDetailId").value = data.checkInDetailId;
                            document.getElementById("itemName").value = data.itemCName;
                            document.getElementById("itemModel").value = data.itemModel;
                            document.getElementById("itemBrand").value = data.itemBrand;
                            document.getElementById("itemSize").value = data.itemSize;
                            table.row(button.parents('tr')).remove().draw(false);
                            var $newRow = $('#mainIssueDetailsrow').clone().removeAttr('id');
                            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
                            $('#cpuCode,#deviceCode,#checkInDetailId,#itemName,#itemModel,#itemBrand,#itemSize,#add', $newRow).removeClass('hidden').addClass('show');
                            $('#cpuCode,#deviceCode,#checkInDetailId,#itemName,#itemModel,#itemBrand,#itemSize,#add', $newRow).removeAttr('id');
                            $('#requisitiondetailsStore').append($newRow);
                            $('#cpuCode,#deviceCode,#checkInDetailId,#itemName,#itemModel,#itemBrand,#itemSize').val('');
                        }
                    });
                }

            }
        }



       
           

        

    });

    $('#issuedetailsStore').on('click', '.remove', function () {
        $(this).parents('tr').remove();
        //$('#checkinDetails').DataTable().row({ selected: true }).node().attr('deviceCode');;
    });





});


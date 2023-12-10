//$(document).ready(function () {
//    $("#issueId").click(function () {
//        $(".replaceDeviceCode").anable();
//        $(".replaceDevCode").hide();
//        $(".returnRemarks").hide();
//        $(".rtnRemark").hide();
//    });
//    $("#replaceId").click(function () {
//        $(".replaceDeviceCode").show();
//        $(".replaceDevCode").show();
//        $(".returnRemarks").hide();
//        $(".rtnRemark").hide();
//    });
//    $("#returnId").click(function () {
//        $(".replaceDeviceCode").hide();
//        $(".replaceDevCode").hide();
//        $(".returnRemarks").show();
//        $(".rtnRemark").show();
//    });
//});


$(document).ready(function () {
    var selectType = "Issued";
    var replacedDevCode = "N/A";
    var returnComment = "N/A";
    $('input:radio').click(function () {
        $("#replaceDeviceCode").prop("disabled", true);
        $("#returnRemarks").prop("disabled", true);

        if ($(this).hasClass('replaceId')) {
            $("#replaceDeviceCode").prop("disabled", false);
            selectType = "Replaced";
            replacedDevCode = $(".replaceDeviceCode", this).val();

        }

        if ($(this).attr('id') === 'returnId') {
            $("#returnRemarks").prop("disabled", false);
            selectType = "Returned";
            returnComment = $(".returnRemarks", this).val();
        }
    });


    //Item Details Add button click event
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;


        if ($('#cpuCode').val() == "0") {
            isAllValid = false;
            $('#cpuCode').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#cpuCode').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#deviceCode').val() == "0") {
            isAllValid = false;
            $('#deviceCode').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#deviceCode').siblings('span.error').css('visibility', 'hidden');
        }

        if (selectType == "replaceId") {
            if (!($('#replaceDeviceCode').val().trim() != '')) {
                isAllValid = false;
                $('#replaceDeviceCode').siblings('span.error').css('visibility', 'visible');
            } else {
                $('#replaceDeviceCode').siblings('span.error').css('visibility', 'hidden');
            }
        }

        if (isAllValid) {
            var $newRow = $('#mainIssueDetailsrow').clone().removeAttr('id');
            $('.cpuCode', $newRow).val($('#cpuCode').val());
            $('.deviceCode', $newRow).val($('#deviceCode').val());

            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            //$('#productCategory,#model,#size,#brand,#price,#details,#add', $newRow).removeAttr('id');
            //$('#auditCode,#deviceCode,#warrantExpiredDate,#productSerialNo,#itemCName,#itemModel,#itemSize,#itemBrand,#unitPrice,#itemStatus,#remarks,#add', $newRow).removeAttr('id');
            $('#cpuCode,#deviceCode,#replaceDeviceCode,#returnRemarks,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#issuedetailsStore').append($newRow);

            //clear select data
            $('#cpuCode,#deviceCode').val('0');
            //$('#auditCode,#deviceCode,#warrantExpiredDate,#productSerialNo,#unitPrice,#remarks').val('');
            $('#replaceDeviceCode,#returnRemarks').val('');
            $('#issueError').empty();
        }

    });

    //remove button click event
    $('#issuedetailsStore').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        var isAllValid = true;
        //validate order items
        $('#issueError').text('');
        var issueDetailslist = [];
        var errorItemCount = 0;
        //var countCheckDetailsId = 1;



        $('#issuedetailsStore tbody tr').each(function (index, ele) {
            if ($('select.cpuCode', this).val() === "0" || $('select.deviceCode', this).val() === "0") {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var checkinDetailsItem = {
                    Code: "1",
                    Id: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                        return v.toString(16);
                    }),
                    IssueId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                        return v.toString(16);
                    }),
                    CurrentStatus: selectType,
                    DeviceReturnRemarks: "N/A",
                    CpuId: $('select.cpuCode', this).val(),
                    DeviceId: $('select.deviceCode', this).val(),
                    AgainstDeviceCode: replacedDevCode,
                    ReturnComment: returnComment,
                    IssueDate: new Date(),
                    ReturnDate: new Date(),
                    PostedBy: "P",
                    PostedIp: "1",
                    PostedDate: new Date(),
                    UpdatedBy: "U",
                    UpdatedIp: "1",
                    UpdatedDate: new Date()

                }
                issueDetailslist.push(checkinDetailsItem);
            }
        });

        if (errorItemCount > 0) {
            $('#issueError').text(errorItemCount + " invalid entry in Issue list.");
            isAllValid = false;
        }

        if (issueDetailslist.length === 0) {
            $('#issueError').text('At least 1 Issue required.');
            isAllValid = false;
        }

        if ($('#employeeId').val() === "0") {
            $('#employeeId').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#employeeId').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#departmentId').val() === "0") {
            isAllValid = false;
            $('#departmentId').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#departmentId').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#campusID').val() === "0") {
            isAllValid = false;
            $('#campusID').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#campusID').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#floorId').val().trim() === '') {
            $('#floorId').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#floorId').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#roomNo').val().trim() === '') {
            $('#roomNo').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#roomNo').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#statusRemark').val().trim() === '') {
            $('#statusRemark').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#statusRemark').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
                Code: '2',
                Id: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                    return v.toString(16);
                }),
                EmployeeId: document.getElementById("employeeId").value,
                DepartmentId: document.getElementById("departmentId").value,
                CampusId: document.getElementById("campusID").value,
                Floor: $('#floorId').val().trim(),
                Room: $('#roomNo').val().trim(),
                IssueRemark: $('#statusRemark').val().trim(),
                ReturnRemark: $('#statusRemark').val().trim(),
                ApprovedId: "N/A",
                ApprovedDateTime: new Date(),
                ApprovedIp: "N/A",
                IsApproved: 0,

                PostedBy: "P",
                PostedIp: "1",
                PostedDate: new Date(),
                UpdatedBy: "U",
                UpdatedIp: "2",
                UpdatedDate: new Date(),
                IssueDetails: issueDetailslist
            }

            $(this).val('Save.');

            $.ajax({
                type: 'POST',
                url: '/issueDetailsMultiple/saveIssueDetails',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        toastr.success('Successfully saved Item');
                        //$(this).val('Save Item');
                        //here we will clear the form
                        issueDetailslist = [];
                        $('#floorId,#roomNo,#statusRemark,#replaceDeviceCode,#returnRemarks').val('');
                        $('#employeeId,#departmentId,#campusID,#cpuCode,#deviceCode').val('0');
                        $('#issuedetailsStore').empty();

                    }
                    else {
                        toastr.error('Something unexpected happened');
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }

    });

});
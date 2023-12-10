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

//function SearchDeviceCode(itemName, itemBrand, itemModel, itemSize) {
//    var url = "/IssueDetailsMultiple/GetDeviceIdByParm?ItemName=" + itemName + "&ItemBrand=" + itemBrand + "&ItemModel=" + itemModel + "&ItemSize=" + itemSize;
//    $("#ModalTitle").html("Search Device Code");
//    $("#MyModal").modal();
//    $.ajax({
//        type: "GET",
//        url: url,
//        success: function (data) {
//            var obj = JSON.parse(data);
//            $("#StuId").val(obj.StudentId);
//            $("#StuName").val(obj.StudentName);
//            $("#Email").val(obj.Email);
            
//        }
//    });
//}

$(document).ready(function () {
    
    var selectType = "deviceId";
    

    $('input:radio').click(function () {
        $("#cpuCode").prop("disabled", true);
        
        if ($(this).hasClass('cpuId')) {
            selectType = "cpuId";
            $("#cpuCode").prop("disabled", false);
            cpuCode = $('select.cpuCode', this).val();
            $("#itemCName").prop("disabled", true);
            $("#itemBrand").prop("disabled", true);
            $("#itemModel").prop("disabled", true);
            $("#itemSize").prop("disabled", true);
        }

        if ($(this).attr('id') === 'deviceId') {
            selectType = "deviceId";
            $("#cpuCode").prop("disabled", true);
            $("#itemCName").prop("disabled", false);
            $("#itemBrand").prop("disabled", false);
            $("#itemModel").prop("disabled", false);
            $("#itemSize").prop("disabled", false);
            

            itemName = $('select.itemCName', this).val();
            itemBrand = $('select.itemBrand', this).val();
            itemModel = $('select.itemModel', this).val();
            itemSize = $('select.itemSize', this).val();
        }
    });
    
    //remove button click event
    

    $('#submit').click(function () {
        var isAllValid = true;
        //validate order items
        $('#issueError').text('');
        var issueDetailslist = [];
        var errorItemCount = 0;
        //var countCheckDetailsId = 1;
        var countIssueDetailsId = 1;

        $('#issuedetailsStore tbody tr').each(function (index, ele) {
            var issueDetailsItem = {
                IssueDetailId: countIssueDetailsId++,
                QueryId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                    return v.toString(16);
                }),
                IssueId: "IS-000000001",
                //CpuId: $(".cpuCode", this).val(),
                //DeviceId: $(".deviceCode", this).val(), 
                CheckInDetailId: $(".checkInDetailId", this).val(), 
                AgainstDeviceCode: "N/A",
                CurrentStatus: "Issued",
                DeviceReturnRemarks: "N/A",
                IssueDate: new Date(),
                ReturnDate: "01/01/1900",
                ReturnComment: "N/A",
                PostedBy: "P",
                PostedIp: "1",
                PostedDate: new Date(),
                UpdatedBy: "U",
                UpdatedIp: "1",
                UpdatedDate: new Date()

            }
            issueDetailslist.push(issueDetailsItem);
        });

        if (errorItemCount > 0) {
            $('#issueError').text(errorItemCount + " invalid entry in Issue list.");
            isAllValid = false;
        }

        if ($('#issueTypeId').val() === "0") {
            isAllValid = false;
            $('#issueTypeId').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#issueTypeId').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#departmentId').val() === "0") {
            isAllValid = false;
            $('#departmentId').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#departmentId').siblings('span.error').css('visibility', 'hidden');
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
                IssueId: "IS-000000001",
                QueryId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                    return v.toString(16);
                }),
                IssueTypeId: document.getElementById("issueTypeId").value,
                DepartmentId: document.getElementById("departmentId").value,
                EmployeeId: document.getElementById("employeeIdDept").value,
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
                url: '../issueDetailsMultiple/saveIssueDetails',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        toastr.success('Successfully saved Item');
                        //$(this).val('Save Item');
                        //here we will clear the form
                        issueDetailslist = [];
                        $('#floorId,#roomNo,#statusRemark,#replaceDeviceCode,#returnRemarks').val('');
                        $('#issueTypeId,#employeeId,#departmentId,#campusID,#cpuCode,#deviceCode').val('0');
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
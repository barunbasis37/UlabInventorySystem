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
        $('#requisitionError').text('');
        var requisitionDetailslist = [];
        var errorItemCount = 0;
        //var countCheckDetailsId = 1;
        var countRequisitionDetailsId = 1;

        $('#requisitiondetailsStore tbody tr').each(function (index, ele) {
            var requisitionDetailsItem = {
                RequisitionDetailId: countRequisitionDetailsId++,
                QueryId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g,
                    function(c) {
                        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                        return v.toString(16);
                    }),
                RequisitionId: "RQD-000000001",
                ApprovedBy: "N/A",
                ApprovedDateTime: "01/01/1900",
                ApprovedIP: "0.0.0.0",
                IssuedBy: "N/A",
                IssuedDateTime: "01/01/1900",
                IssuedIP: "0.0.0.0",
                CheckInDetailIdCode: $(".checkInDetailId", this).val(),
                IsApproved:false,
                IsIssued:false,
                ApproveRemarks: "N/A",
                RequestRemarks: "N/A",
                IsDenied: false,
                DeniedBy: "N/A",
                DeniedDateTime: "01/01/1900",
                DeniedIP: "0.0.0.0",
                PostedBy: "P",
                PostedIp: "1",
                PostedDate: new Date(),
                UpdatedBy: "U",
                UpdatedIp: "1",
                UpdatedDate: new Date()

            }
            requisitionDetailslist.push(requisitionDetailsItem);
        });

        if (errorItemCount > 0) {
            $('#requisitionError').text(errorItemCount + " invalid entry in Requisition list.");
            isAllValid = false;
        }

        if ($('#requisitionTypeId').val() === "0") {
            isAllValid = false;
            $('#requisitionTypeId').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#requisitionTypeId').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#departmentId').val() === "0") {
            isAllValid = false;
            $('#departmentId').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#departmentId').siblings('span.error').css('visibility', 'hidden');
        }

        if (requisitionDetailslist.length === 0) {
            $('#requisitionError').text('At least 1 Requisition required.');
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
                RequisitionId: "RQ-000000001",
                QueryId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                    return v.toString(16);
                }),
                IssueTypeId: document.getElementById("issueTypeId").value,
                EmployeeId: document.getElementById("employeeIdDept").value,
                CampusId: document.getElementById("campusID").value,
                FloorNo: $('#floorId').val().trim(),
                RoomNo: $('#roomNo').val().trim(),
                Remark: $('#statusRemark').val().trim(),
                PostedBy: "P",
                PostedIp: "1",
                PostedDate: new Date(),
                UpdatedBy: "U",
                UpdatedIp: "2",
                UpdatedDate: new Date(),
                RequisitionDetails: requisitionDetailslist
            }

            $(this).val('Saving...');

            $.ajax({
                type: 'POST',
                url: '../RequisitionDetailsMultiple/SaveRequisitionDetails',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        toastr.success('Successfully saved Requistion');
                        //$(this).val('Save Item');
                        //here we will clear the form
                        requisitionDetailslist = [];
                        $('#floorId,#roomNo,#statusRemark,#replaceDeviceCode,#returnRemarks').val('');
                        $('#requisitionTypeId,#employeeId,#departmentId,#campusID,#cpuCode,#deviceCode').val('0');
                        $('#requisitiondetailsStore').empty();

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
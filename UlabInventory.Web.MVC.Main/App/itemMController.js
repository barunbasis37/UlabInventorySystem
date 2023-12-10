$(document).ready(function () {

    //Item Details Add button click event
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;
        //if ($('#productCategory').val() == "0") {
        //    isAllValid = false;
        //    $('#productCategory').siblings('span.error').css('visibility', 'visible');
        //} else {
        //    $('#productCategory').siblings('span.error').css('visibility', 'hidden');
        //}

        if (!($('#model').val().trim() != '')) {
            isAllValid = false;
            $('#model').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#model').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#size').val().trim() != '')) {
            isAllValid = false;
            $('#size').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#size').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#brand').val().trim() != '')) {
            isAllValid = false;
            $('#brand').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#brand').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#price').val().trim() != '' && (parseFloat($('#price').val()) || 0))) {
            isAllValid = false;
            $('#price').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#price').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#details').val().trim() != '')) {
            isAllValid = false;
            $('#details').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#details').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            //$('.pc', $newRow).val($('#productCategory').val());

            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            //$('#productCategory,#model,#size,#brand,#price,#details,#add', $newRow).removeAttr('id');
            $('#model,#size,#brand,#price,#details,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            //$('#productCategor').val('0');
            $('#model,#size,#brand,#price,#details').val('');
            $('#orderItemError').empty();
        }

    });

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        var isAllValid = true;

        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;

        var countItmDetailId = 1;

        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if (
                //$('select.pc', this).val() == "0" ||
                ($('.model', this).val()) == '' ||
                ($('.size', this).val()) == '' ||
                ($('.brand', this).val()) == '' ||
                (parseFloat($('.price', this).val()) || 0) == 0 ||
                ($('.details', this).val()) == ''
            ) {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var orderItem = {
                    ItemDetailId: countItmDetailId++,
                    QueryId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                        return v.toString(16);
                    }),
                    ItemId: "ITM00001",
                    Model: $(".model", this).val(),
                    Size: $(".size", this).val(),
                    Brand: $(".brand", this).val(),
                    Price: parseFloat($(".price", this).val()),
                    Details: $(".details", this).val(),
                    PostedBy: "P",
                    PostedIp: "1",
                    PostedDate: new Date(),
                    UpdatedBy: "U",
                    UpdatedIp: "1",
                    UpdatedDate: new Date()

                }
                list.push(orderItem);
            }
        });

        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        if ($('#itemSubCategory').val() == "0") {
            isAllValid = false;
            $('#itemSubCategory').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#itemSubCategory').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#itemNameID').val() == "0") {
            isAllValid = false;
            $('#itemNameID').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#itemNameID').siblings('span.error').css('visibility', 'hidden');
        }


        //if (!($('#priority').val().trim() != '' && (parseInt($('#priority').val()) || 0))) {
        //    isAllValid = false;
        //    $('#priority').siblings('span.error').css('visibility', 'visible');
        //} else {
        //    $('#priority').siblings('span.error').css('visibility', 'hidden');
        //}


        if (isAllValid) {
            var data = {
                Name: "Name",
                CategoryId:'CAT-01',
                SubCategoryId: document.getElementById("itemSubCategory").value,
                ItemId: document.getElementById("itemNameID").value,
                Priority: "1",
                Description: "Sample",
                QueryId: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                    return v.toString(16);
                }),
                PostedBy: "P",
                PostedIp: "1",
                PostedDate: new Date(),
                UpdatedBy: "U",
                UpdatedIp: "2",
                UpdatedDate: new Date(),
                ItemDetail: list
            }

            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '../itemDetailsMultiple/saveMItem',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        toastr.success('Successfully saved Item');
                        //$(this).val('Save Item');
                        //here we will clear the form
                        list = [];
                        $('#priority,#description').val('');
                        $('#itemNameID,#itemSubCategory').val('0');
                        $('#orderdetailsItems').empty();

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
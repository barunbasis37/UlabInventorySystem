var Categories = [];
//start fetch categories from database
function LoadCategory(element) {
    if (Categories.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../itemDetailsMultiple/getItemCategories',
            success: function (data) {
                Categories = data;
                //render category
                renderCategory(element);
            }
        });
    }
    else {
        //render category to the element
        renderCategory(element);
    }
}

function renderCategory(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Category'));
    $.each(Categories, function (i, val) {
        $ele.append($('<option/>').val(val.CategoryId).text(val.Name));
    });
}
//end fetch categories from database

//start fetch sub-categories from database
function LoadSubCategory(categoryDD) {
    $.ajax({
        type: "GET",
        url: '../itemDetailsMultiple/getItemSubCategories',
        data: { 'categoryID': $(categoryDD).val() },
        success: function (data) {
            //render subcategory to appropriate dropdown
            renderSubCategory($(categoryDD).parents('.cat-container').find('select.itemSC'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

function renderSubCategory(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Sub Category'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.SubCategoryId).text(val.Name));
    });
}
//end fetch sub-categories from database


//start fetch Item from database
var Items = [];
function LoadItem(element) {
    if (Items.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../items/getItem',
            success: function (data) {
                Items = data;
                renderItem(element);
            }
        });
    }
    else {
        //render category to the element
        renderItem(element);
    }
}

function renderItem(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Item'));
    $.each(Items, function (i, val) {
        $ele.append($('<option/>').val(val.ItemId).text(val.Name));
    });
}
//end fetch item from database

//start fetch item-model from database
function LoadItemModel(itemDD) {
    $.ajax({
        type: "GET",
        url: '../items/getItemModel',
        data: { 'itemID': $(itemDD).val() },
        success: function (data) {
            renderItemModel($(itemDD).parents('.cat-container').find('select.itemModel'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

function renderItemModel(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Model'));
    $.each(data, function (i, val) {
        //$ele.append($('<option/>').val(val.Model).text(val.Model));
        $ele.append($('<option/>').val(val.ItemDetailId).text(val.Model + "("+ val.Size + "-" + val.Brand + ")"));
    });
}
//end fetch item-model from database

//start fetch item-size from database
function LoadItemSize(itemDD) {
    $.ajax({
        type: "GET",
        url: '../items/getItemSize',
        data: { 'itemID': $(itemDD).val() },
        success: function (data) {
            renderItemSize($(itemDD).parents('.cat-container').find('select.itemSize'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

function renderItemSize(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Size'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.Size).text(val.Size));
    });
}
//end fetch item-size from database

//start fetch item-brand from database
function LoadItemBrand(itemDD) {
    $.ajax({
        type: "GET",
        url: '../items/getItemBrand',
        data: { 'itemID': $(itemDD).val() },
        success: function (data) {
            renderItemBrand($(itemDD).parents('.cat-container').find('select.itemBrand'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

function renderItemBrand(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Brand'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.Brand).text(val.Brand));
    });
}
//end fetch item-size from database


//start fetch supplier from database
function LoadSupplier(categorySup) {
    $.ajax({
        type: "GET",
        url: '../checkInDetailsMultiple/getSupplier',
        data: { 'categoryID': $(categorySup).val() },
        success: function (data) {
            renderSupplier($(categorySup).parents('.cat-container').find('select.itemSup'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

function renderSupplier(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Supplier'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.SupplierId).text(val.Name));
    });
}
//end fetch supplier from database

//start fetch CPU from database
var CPUs = [];
function LoadCPU(element) {
    if (CPUs.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../checkInDetailsMultiple/getCpu',
            success: function (data) {
                CPUs = data;
                renderCPU(element);
            }
        });
    }
    else {
        //render category to the element
        renderCPU(element);
    }
}

function renderCPU(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select CPU'));
    $.each(CPUs, function (i, val) {
        $ele.append($('<option/>').val(val.CpuId).text(val.CpuId));
    });
}

//end fetch CPU from database

//start fetch device from database
function LoadDeviceCode(cpuDev) {
    $.ajax({
        type: "Get",
        url: '../checkInDetailsMultiple/getDevice',
        data: { 'cpuId': $(cpuDev).val() },
        success: function (data) {
            renderDevice($(cpuDev).parents('.cat-container').find('select.deviceCode'), data);
        },
        error: function (error) {
            console.log(error);
        }

    });
}
function renderDevice(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<Option/>').val('0').text('Select Device'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.DeviceId).text(val.DeviceId));
    });

}

//end fetch device from database


//start fetch Employee from database
var Employee = [];
function LoadEmployee(element) {
    if (Employee.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../employees/getEmployee',
            success: function (data) {
                Employee = data;
                renderEmployee(element);
            }
        });
    }
    else {
        //render category to the element
        renderEmployee(element);
    }
}

function renderEmployee(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Employee Id'));
    $.each(Employee, function (i, val) {
        $ele.append($('<option/>').val(val.EmployeeId).text(val.EmployeeId));
    });
}

//end fetch Employee from database





var Departments = [];
//start fetch categories from database
function LoadDepartment(element) {
    if (Departments.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../departments/getDepartment',
            success: function (data) {
                Departments = data;
                //render category
                renderDepartment(element);
            }
        });
    }
    else {
        //render category to the element
        renderDepartment(element);
    }
}

function renderDepartment(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Department'));
    $.each(Departments, function (i, val) {
        $ele.append($('<option/>').val(val.DepartmentId).text(val.Name));
    });
}
//end fetch department from database

//start fetch Employee from database
var EmployeeDept = [];
function LoadEmpByDept(departmentDD) {
    $.ajax({
        type: "GET",
        url: '../employees/getEmployeeByDept',
        data: { 'departmentId': $(departmentDD).val() },
        success: function (data) {
            //render subcategory to appropriate dropdown
            renderEmployeeByDept($(departmentDD).parents('.cat-container').find('select.employeeIdDept'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function renderEmployeeByDept(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Employee'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.EmployeeId).text(val.Name + ' ('+val.EmployeeId + ' - ' +val.Designation  +')'));
    });
}

//end fetch Employee from database





var Campuses = [];
//start fetch campus from database
function LoadCampus(element) {
    if (Campuses.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../campus/getCampus',
            success: function (data) {
                Campuses = data;
                //render category
                renderCampus(element);
            }
        });
    }
    else {
        //render category to the element
        renderCampus(element);
    }
}

function renderCampus(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Campus'));
    $.each(Campuses, function (i, val) {
        $ele.append($('<option/>').val(val.CampusId).text(val.Name));
    });
}
//end fetch campus from database



var SubCategoriesList = [];
//start fetch sub-categories from database
function LoadSubCategoryItem(element) {
    if (SubCategoriesList.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../itemDetailsMultiple/getSubCategories',
            success: function (data) {
                SubCategoriesList = data;
                //render category
                renderSubCategoryList(element);
            }
        });
    }
    else {
        //render category to the element
        renderSubCategoryList(element);
    }
}

function renderSubCategoryList(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Sub-Category'));
    $.each(SubCategoriesList, function (i, val) {
        $ele.append($('<option/>').val(val.SubCategoryId).text(val.Name));
    });
}
//start fetch Item from database
function LoadItemBySubCat(subcategoryDD) {
    $.ajax({
        type: "GET",
        url: '../itemDetailsMultiple/getItem',
        data: { 'subcategoryId': $(subcategoryDD).val() },
        success: function (data) {
            //render subcategory to appropriate dropdown
            renderItemList($(subcategoryDD).parents('.cat-container').find('select.itemName'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

function renderItemList(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Item'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.ItemId).text(val.Name));
    });
}
//end fetch Item from database

//start fetch Employee from database
var IssueType = [];
function LoadIssueType(element) {
    if (IssueType.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '../issueTypes/GetIssueType',
            success: function (data) {
                IssueType = data;
                renderIssueType(element);
            }
        });
    }
    else {
        //render category to the element
        renderIssueType(element);
    }
}

function renderIssueType(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Type'));
    $.each(IssueType, function (i, val) {
        $ele.append($('<option/>').val(val.IssueTypeID).text(val.Name));
    });
}

//end fetch Employee from database



//end fetch categories from database
LoadSubCategoryItem($('#itemSubCategory'));
LoadEmployee($("#employeeId"));
LoadCategory($('#itemCategory'));
LoadItem($('#itemCName'));
LoadCPU($('#cpuCode'));
LoadDepartment($('#departmentId'));
LoadCampus($('#campusID'));
LoadIssueType($('#issueTypeId'));
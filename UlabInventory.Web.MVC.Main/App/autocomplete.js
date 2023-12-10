$(document).ready(function() {
    //Start Auto complete with Typeahead
    var vm = {
    
    };

    var itemNames = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '../api/item?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#itemName').typeahead({
        minLength: 1,
        highlight: true
    }, {
        name: 'itemNames',
        display: 'name',
        source: itemNames
    }).on("typeahead:select", function(e, item) {
        vm.itemId = item.id;
    });
    //End Auto complete with Typeahead


    ////Start Audit Auto complete with Typeahead
    //var auditvm = {
    
    //};

    //var auditCodes = new Bloodhound({
    //    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
    //    queryTokenizer: Bloodhound.tokenizers.whitespace,
    //    remote: {
    //        url: '/api/checkInDetails?query=%QUERY',
    //        wildcard: '%QUERY'
    //    }
    //});

    //$('#auditCode').typeahead({
    //    minLength: 1,
    //    highlight: true
    //}, {
    //    name: 'auditCodes',
    //    display: 'auditCode',
    //    source: auditCodes
    //}).on("typeahead:select", function(e, auditCode) {
    //    auditvm.AuditCode = auditCode.AuditCode;
    //});
    ////End Audit Auto complete with Typeahead

});



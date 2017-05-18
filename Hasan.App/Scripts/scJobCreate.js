$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#CustomerName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#CustomerName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetCustomerName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { CPhone: item.CPhone, CMobile: item.CMobile, CEmail: item.CEmail, RepresentedBy: item.RepresentedBy, Title: item.Title, ContactCell: item.ContactCell, ContactEmail: item.ContactEmail, label: item.label, value: item.value, CustomeAddress: item.CustomeAddress };
                    }))
                }
            })
        },
        search: function () {
            // custom minLength
            var term = extractLast(this.value);
            if (term.length < 1) {
                return false;
            }
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            var terms = split(this.value);
            // remove the current input
            terms.pop();
            // add the selected item
            terms.push(ui.item.label);
            $("#CustomerKey").val(ui.item.value);
            $("#CustomerName").val(ui.item.CustomerName);
            $("#CustomeAddress").val(ui.item.CustomeAddress);
            $("#CPhone").val(ui.item.CPhone);
            $("#CEmail").val(ui.item.CEmail);
            $("#RepresentedBy").val(ui.item.RepresentedBy);
            $("#Title").val(ui.item.Title);


         
            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});

$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#LocationContactName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#LocationContactName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetLocationContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, LocationKey: $("#LocationKey").val() },
                // data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { LocationContactAddress: item.LocationContactAddress, LocationContactZipCode: item.LocationContactZipCode, LocationContactCityName: item.LocationContactCityName, LocationContactStateName: item.LocationContactStateName, label: item.label, value: item.value };
                    }))
                }
            })
        },
        search: function () {
            // custom minLength
            var term = extractLast(this.value);
            if (term.length < 1) {
                return false;
            }
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            var terms = split(this.value);
            // remove the current input
            terms.pop();
            // add the selected item
            terms.push(ui.item.label);
            $("#LocationContactKey").val(ui.item.value);
            $("#LocationContactAddress").val(ui.item.LocationContactAddress);
            $("#LocationContactZipCode").val(ui.item.LocationContactZipCode);
            $("#LocationContactCityName").val(ui.item.LocationContactCityName);
            $("#LocationContactStateName").val(ui.item.LocationContactStateName);



            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});




//$(function () {
//    $("#CustomerKey").change(function () {
//        var url = '@Url.Content("~/")' + "DropdownUtility/LocationDropdown";
//        var ddlsource = "#CustomerKey";
//        var ddltarget = "#LocationKey";
//        $.getJSON(url, { Sel_StateName: $(ddlsource).val() }, function (data) {
//            $(ddltarget).empty();
//            $.each(data, function (index, optionData) {
//                $(ddltarget).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
//            });

//        });
//    });
//});
//$(function () {
//    $("#LocationKey").change(function () {
//        var url = '@Url.Content("~/")' + "DropdownUtility/GetJobnameByLocation";
//        var ddlsource = "#LocationKey";
//        var ddltarget = "#JobName";
//        $.getJSON(url, { Sel_StateName: $(ddlsource).val() }, function (data) {
//            $(ddltarget).val(data);
//        });
//    });
//});

//$(function () {
//    $("#CustomerKey").change(function () {
//        var url = '@Url.Content("~/")' + "DropdownUtility/CustomerContactDropdown";
//        var ddlsource = "#CustomerKey";
//        var ddltarget = "#CContactKey";
//        $.getJSON(url, { Sel_StateName: $(ddlsource).val() }, function (data) {
//            $(ddltarget).empty();
//            $.each(data, function (index, optionData) {
//                $(ddltarget).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
//            });

//        });
//    });
//});

//$(function () {
//    $("#CustomerKey").change(function () {
//        var url = '@Url.Content("~/")' + "DropdownUtility/GetTradeBycustomer";
//        var ddlsource = "#CustomerKey";
//        var ddltarget = "#TradeKey";
//        $.getJSON(url, { Sel_StateName: $(ddlsource).val() }, function (data) {
//            $(ddltarget).empty();
//            $.each(data, function (index, optionData) {
//                $(ddltarget).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
//            });

//        });
//    });
//});
//$(function () {
//    $("#TradeKey").change(function () {
//        $("#TradeName").val($("#TradeKey").Text());
//    });
//});

///////////////////////////////////////////////

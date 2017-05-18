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
                        return { IVRPin: item.IVRPin, IVRTrackingNo: item.IVRTrackingNo, CPhone: item.CPhone, CMobile: item.CMobile, CEmail: item.CEmail, RepresentedBy: item.RepresentedBy, Title: item.Title, ContactCell: item.ContactCell, ContactEmail: item.ContactEmail, label: item.label, value: item.value, CustomeAddress: item.CustomeAddress };
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
            $("#IVRTrackingNo").val(ui.item.IVRTrackingNo);
            $("#IVRPin").val(ui.item.IVRPin);
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

    $("#CustomerContactName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#CustomerContactName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetCustomerContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, CustomerKey: $("#CustomerKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { CContactKey: item.CContactKey, CustomerContactName: item.CustomerContactName, label: item.label, value: item.value };
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
            //$("#CContactKey").val(ui.item.value);
            $("#CContactKey").val(ui.item.CContactKey);
            $("#CustomerContactName").val(ui.item.CustomerContactName);


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

    $("#TradeName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#TradeName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetTradeName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, CustomerKey: $("#CustomerKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.label, value: item.value };
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
            $("#TradeKey").val(ui.item.value);


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
        



            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});
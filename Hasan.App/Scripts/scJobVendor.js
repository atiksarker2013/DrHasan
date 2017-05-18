// Job Create vendor

$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#JobVendorName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#JobVendorName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetJobVendorName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, JobKey: $("#JobKey").val(), TradeKey: $("#TradeKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { LaborKey: item.LaborKey, ServiceCharge: item.ServiceCharge, JobVendorName: item.JobVendorName, RadiusInMiles: item.RadiusInMiles, label: item.label, value: item.value };
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

            $("#VendorKey").val(ui.item.value);
            $("#JobVendorName").val(ui.item.JobVendorName);
            $("#Distance").val(ui.item.RadiusInMiles);
            $("#ServiceCharge").val(ui.item.ServiceCharge);
            $("#LaborKey").val(ui.item.LaborKey);

            var rad = "#VendorKey";

            var urlJob = "/MgtJobVendor/GetContactByVendor/";
            $.ajax({
                url: urlJob,
                data: { VendorKey: $("#VendorKey").val() },
                cache: false,
                type: "POST",
                success: function (data) {
                    var markup = "<option value='0'>Select Contact</option>";
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                    }
                    $("#ddlcity").html(markup).show();
                },
                error: function (reponse) {
                    alert("error : " + reponse);
                }
            });

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

    $("#JobVendorContactName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#JobVendorContactName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetJobVendorContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, VendorKey: $("#VendorKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { JobVendorContactName: item.JobVendorContactName, label: item.label, value: item.value };
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

            $("#ContactKey").val(ui.item.value);
            $("#JobVendorContactName").val(ui.item.JobVendorContactName);

            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});
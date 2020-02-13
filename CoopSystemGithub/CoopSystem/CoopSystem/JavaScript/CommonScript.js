
//CoopSystem
function onClick_CreateMember(e) {
    e.preventDefault();
    var window = $("#window_MemberCreate").data("kendoWindow");
    window.center().refresh().open();
}

//End CoopSystem

function onClick_CancelOptions(e) {
    e.preventDefault();
    var window = $("#window_OptionsCreate").data("kendoWindow");
    window.close();
}

function onClick_SaveOptions(e) {
    e.preventDefault();
    var window = $("#window_OptionsCreate").data("kendoWindow");
    var url = $("#OptionsCreateForm").attr("action");
    var dataItems = $("#OptionsCreateForm").serialize();
    var grid = $("#GridOptionsMf").data("kendoGrid");

    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg_options").html(result.message);
            $("#er_notify_options").removeClass("hidden");

            if (result.result == "success") {
                window.close();
                grid.dataSource.read();
                grid.refresh();
            }
        },
        error: function (result) {

            $("#er_notifyMsg_options").html(result.message);
            $("#er_notify_options").removeClass("hidden");

            grid.dataSource.read();
            grid.refresh();
        }
    });

}

function onClick_UpdateOptions(e) {
    e.preventDefault();
    var url = "@Url.Action("UpdateOptions", "Options")";
    var dataItems = $("#OptionsCreateForm").serialize();
    var window = $("#window_OptionsCreate").data("kendoWindow");
    var grid = $("#GridOptionsMf").data("kendoGrid");

    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg_options").html(result.message);
            $("#er_notify_options").removeClass("hidden");

            if (result.result == "success") {
                window.close();
                grid.dataSource.read();
                grid.refresh();

            }


        },

        error: function (result) {

            $("#er_notifyMsg_options").html(result.message);
            $("#er_notify_options").removeClass("hidden");

            grid.dataSource.read();
            grid.refresh();
        }

    });
}

function onClick_DeleteOptions(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#window_Record").data("kendoWindow");
    var grid = $("#GridOptionsMf").data("kendoGrid");
    $("#window_Record h4").html("Are you sure you want to delete this record?");
    wnd.center().open();
    var description = dataItem.Options_Description_Mf + " " + dataItem.Options_Option_Description_Mf;
    var values = {
        Id: dataItem.Options_Id_Mf
    };

    $("#window_Record > div > div > #Yes").click(function () {
        wnd.close();
        $.ajax({
            dataType: "JSON",
            type: "POST",
            url: "@(Url.Action("RemoveOptions", "Options"))",
            data: values,
            success: function (data) {
                $("#er_notifyMsg_options_delete").html("Record " + description + " currently in used.");
                $("#er_notify_options_delete").removeClass("hidden");
                //alert(data.result);
                if (data.result == "success") {
                    $("#er_notify_options_delete").addClass("hidden");
                    window.close();
                    grid.dataSource.read();
                    grid.refresh();

                }


            },

            error: function (data) {

                $("#er_notifyMsg_options_delete").html(data.message);
                $("#er_notifyMsg_options_delete").removeClass("hidden");

                grid.dataSource.read();
                grid.refresh();
            }
            //success: function (result) {
            //    var grid = $("#GridOptionsMf").data("kendoGrid");
            //    grid.dataSource.read();
            //}
        });

    });

    $("#window_Record > div > div > #No").click(function () {
        wnd.close();
    });
};




function onClick_EditOptions(e) {
    e.preventDefault();
    var window = $("#window_OptionsCreate").data("kendoWindow")
    window.center().open();
    var dataItem = $("#GridOptionsMf").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    var id = dataItem.Options_Id_Mf;
    $.ajax({
        url: '@Url.Action("GetOptionsDetail", "Options")',
        data: { Id: id },
        dataType: "html",
        success: function (data) {
            $("#window_OptionsCreate").html(data);
        }
    });
}

function onClick_CreateOptions(e) {
    e.preventDefault();
    var window = $("#window_OptionsCreate").data("kendoWindow");
    window.center().refresh().open();
}



function onChange_Date(e) {
    var dt = e.sender;
    var value = dt.value();

    if (value === null) {
        value = kendo.parseDate(dt.element.val(), dt.options.parseFormats);
    }

    if (value < dt.min()) {
        dt.value(dt.min());
    } else if (value > dt.max()) {
        dt.value(dt.max());
    }
}

var GlobalGroupId = 0;
function filterByGroupId() {
    return {
        Group_Id: GlobalGroupId
    };
}

function onClick_CancelTransaction(e) {
    var window = $("#window_TransactionCreate").data("kendoWindow");
    window.close();
}

function onClick_SaveTransaction(e) {
    e.preventDefault();
    var window = $("#window_TransactionCreate").data("kendoWindow");
    var window_processing = $("#window_processing").data("kendoWindow");
    var url = $("#TransactionPaymentForm").attr("action");
    var dataItems = $("#TransactionPaymentForm").serialize();
    //var grid = $("#GridGroup").data("kendoGrid");
    window_processing.center().open();
    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg_transaction").html(result.message);
            $("#er_notify_transaction").removeClass("hidden");

            if (result.result == "success") {
                RefreshGridTransactionPayment();
                window_processing.close();
                window.close();
            }
            else {
                window_processing.close();
            }
        },
        error: function (result) {

            $("#er_notifyMsg_transaction").html(result.result, result.message);
            $("#er_notify_transaction").removeClass("hidden");
            window_processing.close();

        }
    });

}

function onClick_CreateTransaction(e) {

    e.preventDefault();
    var window = $("#window_TransactionCreate").data("kendoWindow")
    window.center().open();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var Group_Id = dataItem.Group_Id;

    GlobalGroupId = Group_Id;

    $.ajax({
        url: '@Url.Action("Create", "Transaction")',
        data: { Group_Id: Group_Id },
        dataType: "html",
        success: function (data) {
            $("#window_TransactionCreate").html(data);
        }
    });

    //e.preventDefault();
    //var window = $("#window_TransactionCreate").data("kendoWindow");
    //window.center().refresh().open();
}

function onRowBound_GridPanel_GridGroup() {
    $(".k-grid-SalesByUser").find("span").addClass("fa fa-credit-card");
    $(".k-grid-Sales").find("span").addClass("fa fa-credit-card-alt");
    $(".k-grid-Cancel").find("span").addClass("fa fa-times");
    $(".k-grid-Delete").find("span").addClass("fa fa-trash-o fa-fw");
    $(".k-grid-Edit").find("span").addClass("fa fa-pencil");
    $(".k-grid-ViewMember").find("span").addClass("fa fa-eye");
    $(".k-grid-DetailInvoice").find("span").addClass("fa fa-list-ol");
    $(".k-grid-AddMember").find("span").addClass("fa fa-plus");
    $(".k-grid-Transaction").find("span").addClass("fa fa-money");

}



$("#GroupListMenu").click(function (e) {
    e.preventDefault();
    var window = $("#window_GroupList").data("kendoWindow");
    window.refresh().center().open();
});

//delete
//function onClick_DeleteGroup(e) {
//    //Initialized
//};
function onClick_DeleteGroup(e) {
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#window_Record").data("kendoWindow");
    //var window_processing = $("#window_processing").data("kendoWindow");
    $("#window_Record h4").html("Are you sure you want to delete this record?");
    wnd.center().open();
    e.preventDefault();
    var values = {
        Id: dataItem.Group_Id
    };

    $("#window_Record > div > div > #Yes").click(function () {
        wnd.close();
        $.ajax({
            dataType: "html",
            type: "POST",
            url: "@(Url.Action("RemoveGroup", "Group"))",
            data: values,
            success: function (result) {
                var grid = $("#GridGroup").data("kendoGrid");
                grid.dataSource.read();
            }
        });

    });

    $("#window_Record > div > div > #No").click(function () {
        wnd.close();
    });
};


function onClick_DeleteMember(e) {
    var dataItem = $("#GridGroupOptions").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#window_Record").data("kendoWindow");
    //var window_processing = $("#window_processing").data("kendoWindow");
    $("#window_Record h4").html("Are you sure you want to delete this record?");
    wnd.center().open();
    e.preventDefault();
    var values = {
        Member_Id: dataItem.Group_Option_Member_Id
    };

    $("#window_Record > div > div > #Yes").click(function () {
        wnd.close();
        $.ajax({
            dataType: "html",
            type: "POST",
            url: "@(Url.Action("RemoveMember", "Group"))",
            data: values,
            success: function (result) {
                RefreshGridGroupOptions();
                GetTotal();
            }
        });

    });

    $("#window_Record > div > div > #No").click(function () {
        wnd.close();
    });
};


function onClick_EditGroup(e) {
    e.preventDefault();
    var window = $("#window_GroupCreate").data("kendoWindow")
    window.center().open();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var id = dataItem.Group_Id;
    $.ajax({
        url: '@Url.Action("GetGroupDetail", "Group")',
        data: { Id: id },
        dataType: "html",
        success: function (data) {
            $("#window_GroupCreate").html(data);
        }
    });
}

function onClick_AddMemberGroup(e) {
    e.preventDefault();
    var window = $("#window_MemberCreate").data("kendoWindow")
    window.center().open();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var Group_Id = dataItem.Group_Id;

    GlobalGroupId = Group_Id;

    $.ajax({
        url: '@Url.Action("AddMember", "Group")',
        data: { Group_Id: Group_Id },
        dataType: "html",
        success: function (data) {
            $("#window_MemberCreate").html(data);
        }
    });
}

function onClick_SaveMember(e) {
    e.preventDefault();
    var window = $("#window_MemberCreate").data("kendoWindow");
    var url = $("#newMemberCreateForm").attr("action");
    var dataItems = $("#newMemberCreateForm").serialize();
    //var grid = $("#GridGroup").data("kendoGrid");

    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg_member").html(result.message);
            $("#er_notify_member").removeClass("hidden");

            if (result.result == "success") {
                RefreshGridGroupOptions();
                GetTotal();
                window.close();
            }
        },
        error: function (result) {

            $("#er_notifyMsg_member").html(result.result, result.message);
            $("#er_notify_member").removeClass("hidden");

            //grid.dataSource.read();
            //grid.refresh();
        }
    });

}

function onClick_UpdateMember(e) {
    e.preventDefault();
}

function onClick_EditMember(e) {

    e.preventDefault();
    var window = $("#window_MemberEdit").data("kendoWindow")
    window.center().open();
    var dataItem = $("#GridGroupOptions").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    var id = dataItem.Group_Option_Member_Id;
    $.ajax({
        url: '@Url.Action("GetMemberDetail", "Group")',
        data: { Member_Id: id },
        dataType: "html",
        success: function (data) {
            $("#window_MemberEdit").html(data);

        }
    });
}




function onClick_CancelMember(e) {
    var window = $("#window_MemberCreate").data("kendoWindow");
    window.close();
}

function RefreshGridGroupOptions() {

    var grid = $("#GridGroupOptions").data("kendoGrid");
    grid.dataSource.read();
    grid.refresh();


}

function RefreshGridTransactionPayment() {

    var grid = $("#GridPaymentTransaction").data("kendoGrid");
    grid.dataSource.read();
    grid.refresh();


}
function onClick_ViewMemberGroup(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var id = dataItem.Group_Id;
    GlobalGroupId = id;
    $(".group_attribute").removeClass("hidden");

    RefreshGridGroupOptions();
    RefreshGridTransactionPayment();
    GetTotal();
}


function GetTotal() {
    $.get('@Url.Action("GrandTotalPerGroup", "Group")', { Group_Id: GlobalGroupId }, function (data) {
        $("#GrandTotalPerGroup").html("Total Payable: " + data.amount);
    });
}


function onClick_CreateGroup(e) {
    e.preventDefault();
    var window = $("#window_GroupCreate").data("kendoWindow");
    window.center().refresh().open();
}



function onClick_SaveGroup(e) {
    e.preventDefault();
    var window = $("#window_GroupCreate").data("kendoWindow");
    var url = $("#newGroupCreateForm").attr("action");
    var dataItems = $("#newGroupCreateForm").serialize();
    var grid = $("#GridGroup").data("kendoGrid");

    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg").html(result.message);
            $("#er_notify").removeClass("hidden");

            if (result.result == "success") {
                window.close();
                grid.dataSource.read();
                grid.refresh();
            }
        },
        error: function (result) {

            $("#er_notifyMsg").html(result.result, result.message);
            $("#er_notify").removeClass("hidden");

            grid.dataSource.read();
            grid.refresh();
        }
    });

}


function onClick_UpdateMember(e) {
    e.preventDefault();
    var url = "@Url.Action("UpdateMember", "Group")";
    var dataItems = $("#newMemberUpdateForm").serialize();
    var window = $("#window_MemberEdit").data("kendoWindow");
    //var grid = $("#GridGroupOptions").data("kendoGrid");

    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg_member_update").html(result.message);
            $("#er_notify_member_update").removeClass("hidden");

            if (result.result == "success") {
                window.close();
                //grid.dataSource.read();
                //grid.refresh();

                RefreshGridGroupOptions();
                RefreshGridTransactionPayment();
                GetTotal();
            }


        },

        error: function (result) {

            $("#er_notifyMsg_member_update").html(result.message);
            $("#er_notify_member_update").removeClass("hidden");

            RefreshGridGroupOptions();
            RefreshGridTransactionPayment();
            GetTotal();
            //grid.dataSource.read();
            //grid.refresh();
        }

    });
}

function onClick_UpdateGroup(e) {
    e.preventDefault();
    var url = "@Url.Action("UpdateGroup", "Group")";
    var dataItems = $("#newGroupCreateForm").serialize();
    var window = $("#window_GroupCreate").data("kendoWindow");
    var grid = $("#GridGroup").data("kendoGrid");

    $.ajax({
        url: url,
        type: 'POST',
        data: dataItems,
        dataType: 'json',
        success: function (result) {
            $("#er_notifyMsg").html(result.message);
            $("#er_notify").removeClass("hidden");

            if (result.result == "success") {
                window.close();
                grid.dataSource.read();
                grid.refresh();

                RefreshGridGroupOptions();
                RefreshGridTransactionPayment();
            }


        },

        error: function (result) {

            $("#er_notifyMsg").html(result.message);
            $("#er_notify").removeClass("hidden");

            grid.dataSource.read();
            grid.refresh();
        }

    });
}

function onClick_CancelGroup(e) {
    e.preventDefault();
    var window = $("#window_GroupCreate").data("kendoWindow");
    window.close();
}

function onClick_CancelMemberEdit(e) {
    e.preventDefault();
    var window = $("#window_MemberEdit").data("kendoWindow");
    window.close();
}
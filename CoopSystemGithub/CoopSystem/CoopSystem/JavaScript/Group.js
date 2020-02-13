function onClick_DeleteGroup(e) {
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#window_Record").data("kendoWindow");
    var window_processing = $("#window_processing").data("kendoWindow");
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
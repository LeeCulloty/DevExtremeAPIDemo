/// <reference path="../typings/devextreme/devextreme.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
$(function () {
    var myUrl = 'http://localhost:2045/api/product';
    $.getJSON(myUrl, function (data) {
        $("#gridContainer2").dxDataGrid({
            dataSource: data,
            columns: ["Id", "ProductDesc", "RRP", "Cost", "Inactive"],
            height: 600,
            filterRow: { visible: true },
        });
    });
});
//# sourceMappingURL=Products.js.map
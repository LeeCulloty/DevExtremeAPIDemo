/// <reference path="../typings/devextreme/devextreme.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />

$(function () {
    var products;
    var headerOptions: DevExpress.ui.dxBoxOptions;
    headerOptions = {
        height: 75,
        width: "100%",
        direction: "row"
    };

    $("#header").dxBox(headerOptions);

    var footerOptions: DevExpress.ui.dxBoxOptions;
    footerOptions = {
        height: 50,
        width: "100%",
        direction: "row"
    }
    $("#footer").dxBox(footerOptions);

    var myUrl = 'http://localhost:2045/api/productgroup';
    var tCount = 0;

    var storeOptions: DevExpress.data.CustomStoreOptions;
    var loadOptions: DevExpress.data.LoadOptions;
    loadOptions = {
        requireTotalCount: false,
    };

    storeOptions = {
        key: "Id",
        load: function (loadOptions) {
            var d = $.Deferred();
            $.getJSON(myUrl, function (data) { d.resolve(data, { totalCount: data.length }); });
            return d.promise();
        },
        byKey: function (key) {
            return $.getJSON(myUrl + "/" + encodeURIComponent(key));
        },

        insert: function (values) {
            return $.post(myUrl, values);
        },

        update: function (key, values) {
            $.extend(values, { Id: key });
            var uOptions: JQueryAjaxSettings;
            uOptions = {
                url: myUrl + "/" + encodeURIComponent(key),
                type: "PUT",
                data: values
            };
            return $.ajax(uOptions);
        },

        remove: function (key) {
            var dOptions: JQueryAjaxSettings;
            dOptions = {
                url: myUrl + "/" + encodeURIComponent(key),
                type: "DELETE",
                data: {Id: key}
            };

            return $.ajax(dOptions);
        }
    };

    var thisDS = new DevExpress.data.CustomStore(storeOptions);

    var dgOptions: DevExpress.ui.dxDataGridOptions;
    dgOptions = {
        dataSource: thisDS,
        height: 500,
        columns: ["Id", "ProductGroup"],
        editing: {
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true
        },
        filterRow: { visible: true }
    }

    $("#gridContainer2").dxDataGrid(dgOptions);

});


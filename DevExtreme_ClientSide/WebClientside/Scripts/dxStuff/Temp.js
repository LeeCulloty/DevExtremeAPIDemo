$(function () {
    //var products;
    //var myUrl = 'http://localhost:2045/api/productgroup';
    //var tCount = 0;
    //var thisDS = new DevExpress.data.CustomStore({
    //    key: ["Id"],
    //    load: function (loadOptions) {
    //        return $.getJSON(myUrl);
    //    },

    //    byKey: function (key) {
    //        return $.getJSON(myUrl + "/" + encodeURIComponent(key));
    //    },

    //    insert: function (values) {
    //        return $.post(myUrl, values);
    //    },

    //    update: function (key, values) {
    //        values.Id = key.Id;
    //        return $.ajax({
    //            url: myUrl + "/" + encodeURIComponent(key),
    //            method: "PUT",
    //            data: values
    //        });
    //    },

    //    remove: function (key) {
    //        return $.ajax({
    //            url: myUrl + "/" + encodeURIComponent(key),
    //            method: "DELETE",
    //            data:key
    //        });
    //    },
    //    totalCount: function () {
    //        return tCount;
    //    }

    //});


    //$("#gridContainer2").dxDataGrid({
    //    dataSource: thisDS,
    //    columns: ["Id", "ProductGroup"],
    //    height: 450,
    //    editing: {
    //        allowAdding: true,
    //        allowUpdating: true,
    //        allowDeleting: true,
    //        mode: "row"
    //    }
   
    //});


    //Works as quick reader
    //$.getJSON('http://localhost:2045/api/productgroup', function (j) {
    //    products = j;
    //    $("#gridContainer2").dxDataGrid({
    //        dataSource: products,
    //        columns: ["Id", "ProductGroup"],
    //        height: 300,
    //    });

    //});

    //Error thrown re totalcount
    //$("#gridContainer2").dxDataGrid({
    //    dataSource: 'http://localhost:2045/api/productgroup?callback?',
    //    columns: ["Id", "ProductGroup"]
    //});


});


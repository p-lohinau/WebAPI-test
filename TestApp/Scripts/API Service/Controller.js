app.controller('APIController', function ($scope, APIService) {

    function GetData(url, successFunction) {
        var servCall = APIService.commonAjaxRequest(url);
        servCall.then(function (result) {
            successFunction(result.data);
        }, function (error) {
            switch (error.status) {
                case 404: {
                    $('#modal-window').modal('show');
                    const strResult = "<p>There is no data</p>";
                    $("#modal-table").html(strResult);
                    break;
                }
                default: {
                    const strResult = "<p>There is some error</p>";
                    $("#modal-table").html(strResult);
                }
            }
        });
    }

    GetData("api/Shops", ShowShopsList);

    $scope.getProducts = function (shopId) {
        const route = `api/Products/${shopId}`;
        GetData(route, ShowProductsList);
    };

    function ShowShopsList(shops) {
        $scope.shops = shops;
    }

    function ShowProductsList(products) {
        $('#modal-window').modal('show');
        var strResult = "<table class='table'> <thead class='thead-dark'> <th>ID</th><th>Product name</th><th>Product description</th> </thead>";
        $.each(products, function (index, product) {
            strResult += `<tbody> <tr><td>${product.Id}</td><td>${product.ProductName}</td><td>${product.ProductDescription}</td></tr> </tbody>`;
        });
        strResult += "</table>";
        $("#modal-table").html(strResult);
    }
});
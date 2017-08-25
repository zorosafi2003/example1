angular.module('myapp').controller('addProduct', ['$scope', '$http', 'ApiUrl', '$location', 'productService', function ($scope, $http, ApiUrl, $location, productService ) {
 
   
    $scope.Obj = [];
    $scope.ObjSubAccounts = [];


    productService.get('Product?guid=&IsNew=true',null,
        function (response) {
            $scope.Obj = response.Data;
        },
        function (error) {
        });

    $scope.save = function () {
        productService.add("Product", $scope.Obj,
            function (response) {
                $location.path('/product');
            },
            function (error) {
            });
    };

  

}]);
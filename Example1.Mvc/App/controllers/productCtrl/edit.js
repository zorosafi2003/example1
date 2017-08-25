angular.module('myapp').controller('editProduct', function (productService ,$scope, $http, ApiUrl, $log, $stateParams, $location, $rootScope , $timeout) {


    $scope.Obj = [];
    $scope.ObjSubAccounts = [];


    productService.get('Product?guid=' + $stateParams.Guid + '&IsNew=false', null,
        function (response) {
            $scope.Obj = response.Data;
        },
        function (error) {
        });

    $scope.save = function () {
        productService.edit("Product", $scope.Obj,
            function (response) {
                $location.path('/product');
            },
            function (error) {
            });
    };

});
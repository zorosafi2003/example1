angular.module('myapp').controller('viewProduct', function (productService , $scope, $http, ApiUrl, $log, $rootScope) {


    ///pagination
    $scope.maxSize = 5;
    $scope.bigCurrentPage = 1;
    $scope.bigTotalItems = 10;
    $scope.search = '';

    $scope.Details = [];


    productService.search('product?skip=0&take=10&text=' + $scope.search, null,
        function (response) {
            $scope.Details = response.Data;
            $scope.bigTotalItems = response.Count;
        },
        function (error) {
        });

    $scope.SearchChange = function () {

        var skip = ($scope.bigCurrentPage - 1) * 10;
        productService.search('product?skip=' + skip + '&take=10&text=' + $scope.search, null,
            function (response) {
                $scope.Details = response.Data;
                $scope.bigTotalItems = response.Count;
            },
            function (error) {
            });
    };

    $scope.Headers = ['Id', 'Name ', 'Price', 'Edit', 'Delete'];

    $scope.Remove = function (id) {
        var conf = confirm("Are you sure you want to delete ?");

        if (conf == true) {


            productService.delete('product/?id=' + id, null,
                function (response) {
                    $scope.SearchChange();
                },
                function (error) {
                });

        }


    };

});
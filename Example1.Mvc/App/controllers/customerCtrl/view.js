angular.module('myapp').controller('viewCustomer', function ($scope, $http, customerService, $log, $rootScope) {


 
    ///pagination
    $scope.maxSize = 5;
    $scope.bigCurrentPage = 1;
    $scope.bigTotalItems = 10;
    $scope.search = '';

    $scope.Details = [];

    customerService.search('customer?skip=0&take=10&text=' + $scope.search, null,
        function (response) {
            $scope.Details = response.Data;
            $scope.bigTotalItems = response.Count;
        },
        function (error) {
        });

    $scope.SearchChange = function () {

        var skip = ($scope.bigCurrentPage - 1) * 10;
        customerService.search('customer?skip=' + skip + '&take=10&text=' + $scope.search, null,
            function (response) {
                $scope.Details = response.Data;
                $scope.bigTotalItems = response.Count;
            },
            function (error) {
            });
    };


    $scope.Headers = ['Id', 'Name ', 'Address', 'Phone', 'Edit', 'Delete'];

    $scope.Remove = function (id) {
        var conf = confirm("Are you sure you want to delete ?");

        if (conf == true) {

            customerService.delete('customer/?id=' + id, null,
                function (response) {
                    $scope.SearchChange();
                },
                function (error) {
                });

        }


    };




});
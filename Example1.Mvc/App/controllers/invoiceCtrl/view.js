angular.module('myapp').controller('viewInvoice', function ($scope, $http, invoiceService, $log, $rootScope) {


    // verified array 
    $scope.alerts = [];

    ///pagination
    $scope.maxSize = 5;
    $scope.bigCurrentPage = 1;
    $scope.bigTotalItems = 10;
    $scope.search = '';

    $scope.Details = [];


    invoiceService.search('invoice?skip=0&take=10&text=' + $scope.search, null,
        function (response) {
            $scope.Details = response.Data;
            $scope.bigTotalItems = response.Count;
        },
        function (error) {
        });

    $scope.SearchChange = function () {

        var skip = ($scope.bigCurrentPage - 1) * 10;
        invoiceService.search('invoice?skip=' + skip + '&take=10&text=' + $scope.search, null,
            function (response) {
                $scope.Details = response.Data;
                $scope.bigTotalItems = response.Count;
            },
            function (error) {
            });
    };

    $scope.Headers = ['Id', 'Customer ', 'Discount', 'Total', 'Date','Edit', 'Delete'];

    $scope.Remove = function (id) {
        var conf = confirm("Are you sure you want to delete ?");

        if (conf == true) {

            invoiceService.delete('invoice/?id=' + id, null,
                function (response) {
                    $scope.SearchChange();
                },
                function (error) {
                });

        }


    };

  

});
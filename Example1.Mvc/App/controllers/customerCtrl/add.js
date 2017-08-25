angular.module('myapp').controller('addCustomer', function ($scope, $http, customerService, $log, $location, $rootScope) {


    $scope.Obj = [];
    $scope.ObjSubAccounts = [];
   


    customerService.get('Customer?guid=&IsNew=true', null,
        function (response) {
            $scope.Obj = response.Data;
        },
        function (error) {
        });

    $scope.save = function () {
        customerService.add("Customer", $scope.Obj,
            function (response) {
                $location.path('/customer');
            },
            function (error) {
            });
    };

 


});
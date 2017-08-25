angular.module('myapp').controller('editCustomer', function ($scope, $http, customerService, $log, $stateParams, $location, $rootScope, $timeout) {


    $scope.Obj = [];
    $scope.ObjSubAccounts = [];

    customerService.get('Customer?guid=' + $stateParams.Guid + '&IsNew=false', null,
        function (response) {
            $scope.Obj = response.Data;
        },
        function (error) {
        });

    $scope.save = function () {
        customerService.edit("Customer", $scope.Obj,
            function (response) {
                $location.path('/customer');
            },
            function (error) {
            });
    };


});
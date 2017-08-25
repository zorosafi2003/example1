angular.module('myapp').controller('editInvoice', function ($scope, $http, invoiceService, $log, $location, $rootScope, $stateParams, $timeout) {


    $scope.Obj = [];
    $scope.ObjSubAccounts = [];
    invoiceService.get('Invoice?guid=' + $stateParams.Guid + '&IsNew=false', null,
        function (response) {
            $scope.Obj = response.Data;
            $scope.Obj.Date = moment(new Date($scope.Obj.Date)).format('YYYY-MM-DD');
            $("#Date").datepicker();
            $("#Date").change(function () {
                $("#Date").datepicker("option", "dateFormat", "yy-mm-dd");
            });
            $scope.ObjCustomers = response.Customers;
            $scope.ObjProducts = response.Products;


            $timeout(function () {
                $('#DDCustomer').select2();
                $('#DDProduct').select2();
                $scope.TotalPrice();
            });


        },
        function (error) {
        });


 
    $scope.save = function () {

        invoiceService.edit("Invoice", $scope.Obj,
            function (response) {
                $location.path('/invoice');
            },
            function (error) {
            });

      
    };

    $scope.AddTabel = function () {
        $scope.Obj.tblInvoiceDetails.push({
            'Guid': guid(), 'TblProductGuid': $scope.Product.Guid, 'TblProductName': $scope.Product.Name,
            'TblProductPrice': $scope.Product.Price, 'Count': $scope.Count, 'TblInvoiceMasterGuid': $scope.Obj.Guid,
        });
        $scope.Product = null;
        $scope.Count = 0;
        $scope.TotalPrice();

    };

    $scope.ChangeCount = function (index, count) {
        $scope.Obj.tblInvoiceDetails[index].Count = count;
        $scope.TotalPrice();
    };



    $scope.RemoveRow = function (RIndex) {
        $scope.Obj.tblInvoiceDetails.splice(RIndex, 1);
        $scope.TotalPrice();
    };

    $scope.TotalPrice = function () {
        $scope.Total = 0;
        for (var i = 0; i < $scope.Obj.tblInvoiceDetails.length; i++) {
            $scope.Total += $scope.Obj.tblInvoiceDetails[i].TblProductPrice * $scope.Obj.tblInvoiceDetails[i].Count;
        }
        $scope.Total = $scope.Total * ((100 - $scope.Obj.Discount) / 100);
    };

});
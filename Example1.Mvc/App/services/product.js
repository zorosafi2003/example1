angular.module('myapp').service('productService', ['$http', 'ApiUrl' , function ($http, ApiUrl) {

    this.add = function (url, data, onsuccess, onerror) {
        $(".overlay").show();
                $http({
                    method: 'POST',
                    url: ApiUrl + url ,
                    data: data ,
                    headers: { 'Content-Type': 'application/json' }
                }).then(function successCallback(response) {
                    $(".overlay").hide();
                    $.toast({
                        heading: 'Success',
                        showHideTransition: 'slide',
                        icon: 'success'
                    })
                    onsuccess(response);
                    }, function errorCallback(response) {
                        $(".overlay").hide();
                        $.toast({
                            heading: 'Error',
                            showHideTransition: 'fade',
                            icon: 'error'
                        })
                    onerror(response);
                });
    };

    this.edit = function (url, data, onsuccess, onerror) {
        $(".overlay").show();
                $http({
                    method: 'PUT',
                    url: ApiUrl + url,
                    data: data,
                    headers: { 'Content-Type': 'application/json' }
                }).then(function successCallback(response) {
                    $(".overlay").hide();
                    $.toast({
                        heading: 'Success',
                        showHideTransition: 'slide',
                        icon: 'success'
                    })
                    onsuccess(response);
                    }, function errorCallback(response) {
                        $(".overlay").hide();
                    $.toast({
                        heading: 'Error',
                        showHideTransition: 'fade',
                        icon: 'error'
                    })
                    onerror(response);
                });
            };

    this.get = function (url, data, onsuccess, onerror) {
        $(".overlay").show();
                $http({
                    method: 'GET',
                    url: ApiUrl + url,
                    data: data,
                    headers: { 'Content-Type': 'application/json' }
                }).then(function successCallback(response) {
                    $(".overlay").hide();
                    onsuccess(response.data);
                    }, function errorCallback(response) {
                        $(".overlay").hide();
                    $.toast({
                        heading: 'Error',
                        showHideTransition: 'fade',
                        icon: 'error'
                    })
                    onerror(response);
                });
            };

            this.search = function (url, data, onsuccess, onerror) {
                $(".overlay").show();
                $http({
                    method: 'GET',
                    url: ApiUrl + url,
                    data: data,
                    headers: { 'Content-Type': 'application/json' }
                }).then(function successCallback(response) {
                    $(".overlay").hide();
                    onsuccess(response.data);
                }, function errorCallback(response) {
                    $.toast({
                        heading: 'Error',
                        showHideTransition: 'fade',
                        icon: 'error'
                    })
                    $(".overlay").hide();
                    onerror(response);
                });
            };

            this.delete = function (url, data, onsuccess, onerror) {
                $(".overlay").show();
                $http({
                    method: 'DELETE',
                    url: ApiUrl + url,
                    data: data,
                    headers: { 'Content-Type': 'application/json' }
                }).then(function successCallback(response) {
                    $(".overlay").hide();
                    onsuccess(response.data);
                    }, function errorCallback(response) {
                        $(".overlay").hide();
                    $.toast({
                        heading: 'Error',
                        showHideTransition: 'fade',
                        icon: 'error'
                    })
                    onerror(response);
                });
            };

        }]);

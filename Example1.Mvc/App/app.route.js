myapp.config([
    '$stateProvider',
    '$urlRouterProvider', '$ocLazyLoadProvider',
    function ($stateProvider, $urlRouterProvider ,$ocLazyLoadProvider) {

      
        $ocLazyLoadProvider.config({
            debug: false,
            events: false,
            modules: [{ // Set modules initially
            }

            ]
        });

        $stateProvider
           
            .state("ngApp", {
                url: "",
                abstract:true,
                templateUrl: 'app/shared/body.html',
               
            }).state("ngApp.viewInvoice", {
                name: 'invoice',
                url: '/invoice',
                templateUrl: 'app/views/invoice/view.html',
                controller: 'viewInvoice',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/invoice.js',
                            '/app/controllers/invoiceCtrl/view.js']);
                    }],
                },
                data: {
                    pageTitle: 'View Invoice'
                }

            }).state("ngApp.editInvoice", {
                name: 'editInvoice',
                url: '/invoice/edit/:Guid',
                templateUrl: 'app/views/invoice/edit.html',
                controller: 'editInvoice',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/invoice.js',
                            '/app/controllers/invoiceCtrl/edit.js']);
                    }],
                },
                data: {
                    pageTitle: 'Edit Invoice'
                }

            }).state("ngApp.addInvoice", {
                name: 'addInvoice',
                url: '/invoice/add',
                templateUrl: 'app/views/invoice/add.html',
                controller: 'addInvoice',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/invoice.js',
                            '/app/controllers/invoiceCtrl/add.js']);
                    }],
                },
                data: {
                    pageTitle: 'Add Invoice'
                }

            })
            //Customer Route
            .state("ngApp.viewCustomer", {
                name: 'customer',
                url: '/customer',
                templateUrl: 'app/views/customer/view.html',
                controller: 'viewCustomer',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/customer.js',
                            '/app/controllers/customerCtrl/view.js']);
                    }],
                },
                data: {
                    pageTitle: 'View Customer'
                }

            }).state("ngApp.editCustomer", {
                name: 'editCustomer',
                url: '/customer/edit/:Guid',
                templateUrl: 'app/views/customer/edit.html',
                controller: 'editCustomer',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/customer.js',
                            '/app/controllers/customerCtrl/edit.js']);
                    }],
                },
                data: {
                    pageTitle: 'Edit Customer'
                }

            }).state("ngApp.addCustomer", {
                name: 'addCustomer',
                url: '/customer/add',
                templateUrl: 'app/views/customer/add.html',
                controller: 'addCustomer',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/customer.js',
                            '/app/controllers/customerCtrl/add.js']);
                    }],
                },
                data: {
                    pageTitle: 'Add Customer'
                }

            })
            //Product Route
            .state("ngApp.viewProduct", {
                name: 'product',
                url: '/product',
                templateUrl: 'app/views/product/view.html',
                controller: 'viewProduct',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/product.js',
                            '/app/controllers/productCtrl/view.js']);
                    }],
                },
                data: {
                    pageTitle: 'View Product'
                }

            }).state("ngApp.editProduct", {
                name: 'editProduct',
                url: '/product/edit/:Guid',
                templateUrl: 'app/views/product/edit.html',
                controller: 'editProduct',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/product.js',
                            '/app/controllers/productCtrl/edit.js']);
                    }],
                },
                data: {
                    pageTitle: 'Edit Product'
                }

            }).state("ngApp.addProduct", {
                name: 'addProduct',
                url: '/product/add',
                templateUrl: 'app/views/product/add.html',
                controller: 'addProduct',
                resolve: {
                    deps: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load(['/app/services/product.js',
                            '/app/controllers/productCtrl/add.js']);
                    }],
                },
                data: {
                    pageTitle: 'Add Product'
                }

            });

        $urlRouterProvider
            .otherwise('/invoice');


       
    }]);
var myapp = angular.module('myapp', ['ui.router', 'oc.lazyLoad', 'ui.router.state.events', 'ngAnimate', 'ui.bootstrap']);

var URL = "http://" + $(location).attr('host') + "/" ;
myapp.value('ApiUrl', URL + 'api/');
myapp.run(['$state', '$rootScope', function ($state, $rootScope) {
  
    $rootScope.$on('$stateChangeStart',
        function (event, toState, toParams, fromState, fromParams) {
            $rootScope.urlTitle = toState.url.split('/')[1];
        }
    );

    $.toast({
        heading: 'Technology using in this project :',
        text: ` Front End : Angularjs ,Jquery , Bootstrap , SPA , Lazy loading , Html5 <br><br>
                Back End : ASP.NET Api , ASP.NET MVC , Entity Framwork Code First , Dependency Injection Ninject ,N-tier Architecture `,
        hideAfter: false,
        bgColor: '#6acceb'
    })
}]);


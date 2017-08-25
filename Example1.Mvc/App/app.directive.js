myapp.directive('pageTitle', [
    '$rootScope',
    '$timeout',
    function ($rootScope, $timeout) {
        return {
            restrict: 'A',
            link: function () {
                var listener = function (event, toState) {
                    var default_title = 'Example 1';
                    $timeout(function () {
                        $rootScope.page_title = (toState.data && toState.data.pageTitle)
                            ? default_title + ' - ' + toState.data.pageTitle : default_title;
                    });
                };
                $rootScope.$on('$stateChangeSuccess', listener);
            }
        }
    }
]);
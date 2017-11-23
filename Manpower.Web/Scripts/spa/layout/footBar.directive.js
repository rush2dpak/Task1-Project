(function (app) {
    'use strict';

    app.directive('footBar', footBar);

    function footBar() {
        return {
            //restrict: 'E',
            //replace: true,
            templateUrl: '/scripts/spa/layout/footBar.html'
        }
    }

})(angular.module('common.ui'));
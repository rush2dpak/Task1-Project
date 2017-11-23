(function (app) {
    'use strict';

    app.controller('aboutCtrl', aboutCtrl);

    aboutCtrl.$inject = ['$scope', 'membershipService', 'apiService', '$routeParams', '$filter', 'notificationService'];

    function aboutCtrl($scope, membershipService, apiService, $routeParams, $filter, notificationService) {
        $scope.pageClass = 'page-about';
       

    }

})(angular.module('Manpower'));

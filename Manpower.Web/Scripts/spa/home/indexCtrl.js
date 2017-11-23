(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'membershipService', 'apiService', '$routeParams', 'notificationService'];

    function indexCtrl($scope, membershipService, apiService, $routeParams, notificationService) {
        $scope.pageClass = 'page-index';
      
    }

})(angular.module('Manpower'));

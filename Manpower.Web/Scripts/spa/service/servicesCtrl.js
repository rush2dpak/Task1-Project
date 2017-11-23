(function (app) {
    'use strict';

    app.controller('servicesCtrl', servicesCtrl);

    servicesCtrl.$inject = ['$scope', 'membershipService', 'apiService', '$routeParams', '$filter', 'notificationService'];

    function servicesCtrl($scope, membershipService, apiService, $routeParams, $filter, notificationService) {
        $scope.pageClass = 'page-services';


    }

})(angular.module('Manpower'));

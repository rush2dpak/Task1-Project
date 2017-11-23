(function (app) {
    'use strict';

    app.controller('contactCtrl', contactCtrl);

    contactCtrl.$inject = ['$scope', 'membershipService', 'apiService', '$routeParams', '$filter', 'notificationService'];

    function contactCtrl($scope, membershipService, apiService, $routeParams, $filter, notificationService) {
        $scope.pageClass = 'page-contacts';


    }

})(angular.module('Manpower'));

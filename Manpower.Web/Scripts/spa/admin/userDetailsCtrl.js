
(function (app) {
    'use strict';

    app.controller('userDetailsCtrl', userDetailsCtrl);

    userDetailsCtrl.$inject = ['$scope', '$location', '$routeParams', '$modal', 'apiService', 'notificationService'];

    function userDetailsCtrl($scope, $location, $routeParams, $modal, apiService, notificationService) {
        $scope.pageClass = 'page-users';
        $scope.user = [];
        $scope.loadingUser = true;
        
        $scope.isReadOnly = true;



        function loadUser() {

            $scope.loadingUser = true;

            apiService.get('/api/users/details/' + $routeParams.id, null,
            userLoadCompleted,
            userLoadFailed);
        }



        function loadUserDetails() {
            loadUser();

        }

        function userLoadCompleted(result) {
            $scope.user = result.data;
            $scope.loadingUser = false;
        }

        function userLoadFailed(response) {
            notificationService.displayError(response.data);
        }


        
        loadUserDetails();

       
    }

})(angular.module('Manpower'));

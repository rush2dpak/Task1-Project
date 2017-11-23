(function (app) {
    'use strict';

    app.controller('userEditCtrl', userEditCtrl);

    userEditCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'membershipService', 'notificationService'];

    function userEditCtrl($scope, $location, $routeParams, apiService, membershipService, notificationService) {
        $scope.pageClass = 'page-users';

        $scope.user = [];

        $scope.loadingUser = true;
        $scope.isReadOnly = false;
        $scope.UpdateUser = UpdateUser;
        $scope.openDatePicker = openDatePicker;

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.datepicker = {};

        $scope.Roles = [];
        $scope.loadRoles = loadRoles;


        function loadRoles() {
            membershipService.loadRoles(loadRolesCompleted)
        }

        function loadRolesCompleted(result) {
            $scope.Roles = result.data;

        }



        function loadUser() {

            $scope.loadUser = true;

            apiService.get('/api/users/details/' + $routeParams.id, null,
            userLoadCompleted,
            userLoadFailed);
        }

        function userLoadCompleted(result) {
            $scope.user = result.data;
            $scope.loadingUser = false;


        }

        function userLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function UpdateUser() {

            UpdateUserModel();
        }

        function UpdateUserModel() {
            apiService.post('/api/users/update', $scope.user,
            updateUserSucceded,
            updateUserFailed);
        }


        function updateUserSucceded(response) {
            console.log(response);
            notificationService.displaySuccess($scope.user.Name + ' has been updated');
            $scope.user = response.data;

        }

        function updateUserFailed(response) {
            notificationService.displayError(response);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        loadUser();
        loadRoles();

    }

})(angular.module('Manpower'));

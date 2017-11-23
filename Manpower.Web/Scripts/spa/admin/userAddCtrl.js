(function (app) {
    'use strict';

    app.controller('userAddCtrl', userAddCtrl);

    userAddCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService'];

    function userAddCtrl($scope, $location, $routeParams, apiService, notificationService) {

        $scope.pageClass = 'page-users';
        $scope.user = {};
        
        $scope.isReadOnly = false;
        $scope.AddUser = AddUser;
        $scope.openDatePicker = openDatePicker;
       
        $scope.resetForm = resetForm;

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.datepicker = {};

       
        function AddUser() {
            AddUserModel();
        }

        function AddUserModel() {
            $scope.user.Cancel = "false";
            apiService.post('/api/users/add', $scope.user,
            addUserSucceded,
            addUserFailed);
        }

        function addUserSucceded(response) {
            notificationService.displaySuccess($scope.user.Name + ' has been submitted to Manpower');
            $scope.user = response.data;
            $scope.resetForm();
        }

        function addUserFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        $scope.today = function () {
            $scope.date = new Date();
        }
        $scope.today();

        

        //to reset or clear textboxes
        function resetForm() {
            $scope.user = {};
            $scope.addUserForm.$setPristine();
        }
    }

})(angular.module('Manpower'));

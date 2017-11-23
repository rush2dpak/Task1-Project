(function (app) {
    'use strict';

    app.controller('dataAddCtrl', dataAddCtrl);

    dataAddCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', '$filter', '$window'];

    function dataAddCtrl($scope, $location, $routeParams, apiService, notificationService, $filter, $window) {

        $scope.pageClass = 'page-dataAdd';
        $scope.data = {};

        $scope.isReadOnly = false;
        $scope.AddTrainee = AddTrainee;
        $scope.resetForm = resetForm;
        function resetForm() {
            $scope.data = {};

        }

        function AddTrainee() {
            AddTraineeModel();
        }

        function AddTraineeModel() {
        
            apiService.post('/api/dataRecord/add', $scope.data,
                addDataSucceded,
                addDataFailed);
        }

        function addDataSucceded(response) {
            notificationService.displaySuccess($scope.data.Name + ' has been submitted ');
            $scope.data = response.data;
            //resetForm();
            $window.location.href = "#/dataAdd/";

          
        }

        function addDataFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

       
        $scope.today = function () {
            $scope.date = new Date();
        }
        $scope.today();
        $scope.data.DateJoined = $filter('date')(new Date(), 'MM/dd/yyyy');

       
       
    }

})(angular.module('Manpower'));

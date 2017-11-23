(function (app) {
    'use strict';

    app.directive('dataDetails', dataDetails);


    dataDetails.$inject = ['apiService', '$routeParams', 'notificationService', 'mySharedService', '$filter'];


    function dataDetails(apiService, $routeParams, notificationService, sharedService, $filter) {
        return {
            restrict: 'E',
            replace: false,
            templateUrl: '/scripts/spa/layout/dataDetails.html',
            controller: function ($scope) {
                $scope.pageClass = 'page-details';
                                     
                $scope.RemoveData = RemoveData;
                $scope.loadingData = true;
                //$scope.isReadOnly = false;
                $scope.Record = [];
                //$scope.record = [];
                $scope.loadData = loadData;
                function loadData() {

                    $scope.loadingData = true;

                    apiService.get('api/dataRecord/details/' + $routeParams.id, null,
                        dataLoadCompleted,
                        dataLoadFailed);
                }

                function loadDataDetails() {
                    loadData();

                }

                function dataLoadCompleted(result) {
                    $scope.Record = result.data;
                    $scope.loadingData = false;
                }

                function dataLoadFailed(response) {
                    notificationService.displayError(response.data);
                }

                $scope.updateEditRecord = updateEditRecord;
                $scope.editRecord = function (item) {
                    item.editing = true;
                }

                $scope.cancelEditing = function (item) {
                    item.editing = false;
                };


                function updateEditRecord(item) {
                    $scope.Record = item;

                    apiService.post('/api/dataRecord/update', $scope.Record,
                        updateEditDataSucceded,
                        updateEditDataFailed);
                }


                function updateEditDataSucceded(response) {
                    console.log(response);
                    notificationService.displaySuccess($scope.Record.Name + ' has been updated');
                    $scope.Record = response.data;
       
                }

                function updateEditDataFailed(response) {
                    notificationService.displayError(response);
                }
                $scope.edit = function (value) {
                    $scope.editTarget = { Id: value, Target: "Edit" }
                    sharedService.prepForBroadcast($scope.editTarget);
                };
                loadDataDetails();

            }
        }
    }

})(angular.module('common.ui'));
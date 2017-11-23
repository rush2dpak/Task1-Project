(function (app) {
    'use strict';

    app.controller('dataCtrl', dataCtrl);


    dataCtrl.$inject = ['$scope', 'apiService', '$routeParams', '$filter', 'notificationService', 'mySharedService', '$window'];

    function dataCtrl($scope, apiService, $routeParams, $filter, notificationService, sharedService, $window) {
        $scope.pageClass = 'page-data';
        $scope.isReadOnly = true;
        $scope.RemoveData = RemoveData;
        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.data = {
            items: []
        };
        $scope.Record = [];
        $scope.datarecord = {};
        $scope.getRecord = getRecord;
        $scope.loadingRecord = true;
      
        $scope.page = 0;
        $scope.pagesCount = 0;
      
        $scope.loadingData = true;

        function search(page) {
            page = page || 0;

            $scope.loadingData = true;


            var config = {
                params: {
                    id: $scope.compid,
                    userrole: 1,
                    page: page,
                    pageSize: 10,
                    filter: $scope.filterData

                }
            };

            apiService.get('/api/dataRecord/', config,
                dataLoadCompleted,
                dataLoadFailed);
        }

        function dataLoadCompleted(result) {

            $scope.data.items = result.data.Items;

            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingData = false;
           
            if ($scope.filterData && $scope.filterData.length) {
                notificationService.displayInfo(result.data.Items.length + ' data found');
            }

        }

        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }
        
   
        $scope.showMydirc = false;
        $scope.clickMe = function (ai) {
            var dataId = ai.ID;         
            getRecord(dataId);
            $scope.showMydirc = true;
        }

        function getRecord(id) {
            apiService.get('/api/dataRecord/details/' + id, null,
                getRecordSucceded,
                getRecordFailed);
        }
        function getRecordSucceded(response) {
            $scope.Record = response.data;
            $scope.loadingRecord = false;

        }

        function getRecordFailed(response) {
            //console.log(response);
            //notificationService.displayError(response.data);
        }

        function RemoveData(id) {
         
            var index = -1;
            if (id > 0) {
                for (var i = 0; i < $scope.data.items.length; i++) {
                    if ($scope.data.items[i].ID == id) {
                        $scope.data.items.splice(i, 1);
                        break;
                    }
                }

                apiService.get('/api/dataRecord/remove/' + id, null,
                    removeDataSucceded,
                    removeDataFailed);

            }
            else {

                $scope.data.items.splice(index, 1);
            }

        }

        function removeDataSucceded(response) {
            $window.location.href = "#/data/";
            notificationService.displaySuccess($scope.Record.Name + ' has been deleted');
           
           
        }

        function removeDataFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }


        $scope.updateEditRecord = updateEditRecord;
        $scope.editRecord = function (item) {
            item.editing = true;
        }

        $scope.cancelEditing = function (item) {
            item.editing = false;
        };


        function updateEditRecord(item) {
            $scope.datarecord = item;

            apiService.post('/api/dataRecord/update', $scope.datarecord,
                updateEditRecordSucceded,
                updateEditRecordFailed);
        }


        function updateEditRecordSucceded(response) {
            $scope.datarecord = response.data;
            console.log(response);
            notificationService.displaySuccess($scope.datarecord.Name + ' has been updated');
            search();
            //loadClient();
        }

        function updateEditRecordFailed(response) {
            notificationService.displayError(response);
        }
        $scope.edit = function (value) {
            $scope.editTarget = { Id: value, Target: "Edit" }
            sharedService.prepForBroadcast($scope.editTarget);
        };


        function clearSearch() {
            $scope.filterData = '';
            search();
        }
      

        search();
       
        getRecord();
    }
})(angular.module('Manpower'));

(function (app) {
    'use strict';

    app.controller('userCtrl', userCtrl);

    userCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$filter'];

    function userCtrl($scope, apiService, notificationService, $filter) {
        $scope.pageClass = 'page-users';
        $scope.loadingUsers = true;
        $scope.isReadOnly = true;
        $scope.page = 0;
        $scope.pagesCount = 0;

        $scope.Users = [];

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        function search(page) {
            page = page || 0;

            $scope.loadingUsers = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 20,
                    filter: $scope.filterUsers
                }
            };

            apiService.get('/api/users/', config,
            usersLoadCompleted,
            usersLoadFailed);
        }

        function usersLoadCompleted(result) {
            $scope.Users = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;

            for (var i = 0; i < $scope.Users.length; i++) {
                $scope.date = $scope.Users[i].DateCreated;
                $scope.Users[i].DateCreated = $filter('date')($scope.date, 'MMMM d, y ');
            }

            $scope.loadingUsers = false;

            if ($scope.filterUsers && $scope.filterUsers.length) {
                notificationService.displayInfo(result.data.Items.length + ' users found');
            }

        }

        function usersLoadFailed(response) {
            notificationService.displayError(response.data);
        }


        $scope.remove = function (stf) {
            stf.Cancel = true;

            apiService.post('/api/users/update', stf,
            delusersCompleted, delusersFailed);

            function delusersCompleted(response) {
                console.log(response);
                notificationService.displaySuccess($scope.Users.Name + ' has been Deactivated');

                $scope.search();
            }
            function delusersFailed(response) {
                notificationService.displayError(response);
            }


        };

        function clearSearch() {
            $scope.filterUsers = '';
            search();
        }
        $scope.search();
    }

})(angular.module('Manpower'));

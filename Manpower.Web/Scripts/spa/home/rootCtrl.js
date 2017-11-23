(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$location', 'membershipService', '$rootScope', 'mySharedService'];
    function rootCtrl($scope, $location, membershipService, $rootScope, sharedService) {

        $scope.userData = {};

        $scope.userData.displayUserInfo = displayUserInfo;
        $scope.logout = logout;
        $scope.clearShareService = clearShareService;


        function displayUserInfo() {
            $scope.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

            if ($scope.userData.isUserLoggedIn) {
                $scope.username = $rootScope.repository.loggedUser.username;
                $scope.userrole = $rootScope.repository.loggedUser.userrole;
                $scope.compid = $rootScope.repository.loggedUser.compid;
                $scope.compname = $rootScope.repository.loggedUser.compname;
            }
        }

        function logout() {
            membershipService.removeCredentials();
            $location.path('#/');
            $scope.userData.displayUserInfo();
        }

        function clearShareService()
        {
            var status = "";
            sharedService.prepForBroadcastDashboard(status);
        }

        $scope.userData.displayUserInfo();
    }

})(angular.module('Manpower'));

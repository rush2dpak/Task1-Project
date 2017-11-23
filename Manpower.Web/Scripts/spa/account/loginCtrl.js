(function (app) {
    'use strict';

    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'mySharedService'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location, sharedService) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};
        $scope.getuserRole = getuserRole;
        $scope.getCompany = getCompany;

        function login() {
            //notificationService.displaySuccess('Username OK.')
            var status = "";
            sharedService.prepForBroadcastDashboard(status);
            getuserRole($scope.user.username);  
            membershipService.login($scope.user, loginCompleted);
            
        }


        function loginCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
                notificationService.displaySuccess('Welcome ' + $scope.user.username);
                $scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else
                    $location.path('/index');
            }
            else {
                notificationService.displayError('Wrong Password. Try again.');
            }
        }

        function getuserRole(username) {
            membershipService.getuserRole(username, getRoleCompleted);
        }

        function getRoleCompleted(result) {
            var getroles = result.data;
            if (getroles == null) {
                notificationService.displayError('Username doesnot Exist. Try another name.');
            }

            if (getroles.CompanyInfoId != 0) {
                getCompany(getroles.CompanyInfoId);
                $scope.user.compid = getroles.CompanyInfoId;
                //notificationService.displaySuccess('Username OK.')
            }
            else {
                $scope.user.userrole = getroles.RoleId;
                // notificationService.displaySuccess('Username OK.')
            }
        }

        function getCompany(id) {
            membershipService.getCompany(id, getCompanyCompleted);
        }

        function getCompanyCompleted(result) {
            var getcomp = result.data;
            if (getcomp != null) {
                $scope.user.compname = getcomp.FullName;
            }
            else {
                $scope.user.compname = '';
            }
        }

    }

})(angular.module('common.core'));
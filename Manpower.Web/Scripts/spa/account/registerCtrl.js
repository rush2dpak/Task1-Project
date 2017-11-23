(function (app) {
    'use strict';

    app.controller('registerCtrl', registerCtrl);

    registerCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', '$filter'];

    function registerCtrl($scope, membershipService, notificationService, $rootScope, $location, $filter) {
        $scope.pageClass = 'page-login';
        $scope.register = register;
        $scope.user = {};

        $scope.Roles = [];
        $scope.loadRoles = loadRoles;
        $scope.reset = reset;

        //$scope.CompanyList = [];
        //$scope.loadCompany = loadCompany;

        //$scope.LaborNo = [];
        //$scope.getLaborNo = getLaborNo;


        function loadRoles() {
            membershipService.loadRoles(loadRolesCompleted)
        }

        function loadRolesCompleted(result) {
            $scope.Roles = result.data;

        }

        //function loadCompany() {
        //    membershipService.loadCompanies(loadCompaniesCompleted);
        //}

        //function loadCompaniesCompleted(response) {
        //    $scope.CompanyList = response.data;
        //}

        //function getLaborNo() {
        //    membershipService.loadLaborNo(loadLaborNoCompleted);
        //}

        //function loadLaborNoCompleted(response) {
        //    $scope.LaborNo = response.data;
        //}


        //for checkbox
        //$scope.hide = function (val) {
        //    if ($scope.users && val == 'YES') {
        //        $scope.users = val;
        //        //$scope.company = false;
        //        reset();
        //        //$scope.user.CompanyInfoID = 0;
        //    }
        //    //else if ($scope.company && val == 'YES') {
        //    //    $scope.company = val;
        //    //    $scope.users = false;
        //    //    reset();
        //    //    //$scope.user.RoleId = 0;
        //    //}
        //    else {
        //        //$scope.company = false;
        //        $scope.users = false
        //        reset();
        //    }



        //}

        function register() {
            //if ($scope.user.CompanyInfoID == null)
            //    $scope.user.CompanyInfoID = 0;
            //if ($scope.user.RoleId == undefined)
            //    $scope.user.RoleId = 0;
            if (!$scope.user.RoleId) {
                notificationService.displayError('Check STAFF or ADMIN checkbox to create user.');
            }
            else {
                membershipService.register($scope.user, registerCompleted);
            }

        }

        function registerCompleted(result) {
            if (result.data.success) {
                notificationService.displaySuccess($scope.user.UserName + ' has been added to Users List.');
                reset();

            }
            else {
                notificationService.displayError('Registration failed. Try again.');
            }
        }

        //reset the values
        function reset() {
            $scope.user = {};
            $scope.date = new Date();
            $scope.user.DateCreated = $filter('date')(new Date(), 'MM/dd/yyyy');
        }


        loadRoles();
        //loadCompany();
    }

})(angular.module('common.core'));
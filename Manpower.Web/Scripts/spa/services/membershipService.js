(function (app) {
    'use strict';

    app.factory('membershipService', membershipService);

    membershipService.$inject = ['apiService', 'notificationService', '$http', '$base64', '$cookieStore', '$rootScope'];

    function membershipService(apiService, notificationService, $http, $base64, $cookieStore, $rootScope) {

        var service = {
            loadRoles: loadRoles,
            loadCompanies: loadCompanies,
            loadLaborNo: loadLaborNo,
            getuserRole: getuserRole,
            getCompany: getCompany,
            login: login,
            register: register,
            saveCredentials: saveCredentials,
            removeCredentials: removeCredentials,
            isUserLoggedIn: isUserLoggedIn
        }

        function loadRoles(completed) {
            apiService.get('/api/account/role', null,
            completed,
            loadRolesFailed);
        }

        function loadCompanies(completed) {
            apiService.get('/api/company/latest', null,
            completed,
            loadCompaniesFailed);
        }

        function getCompany(id, completed) {
            apiService.get('/api/account/getCompany/' + id, null,
            completed,
            getCompanyFailed);
        }

        function loadLaborNo(completed) {
            apiService.get('/api/account/getLaborNo', null,
            completed,
            loadLaborNoFailed);
        }

        function getuserRole(username, completed) {
            apiService.get('/api/account/getRole/' + username, null,
            completed,
            getuserRolesFailed);
        }

        function login(user, completed) {
            apiService.post('/api/account/authenticate', user,
            completed,
            loginFailed);
        }

        function register(user, completed) {
            apiService.post('/api/account/register', user,
            completed,
            registrationFailed);
        }

        function saveCredentials(user) {
            var membershipData = $base64.encode(user.username + ':' + user.password + ':' + user.userrole + ':' + user.compid + ':' + user.compname);

            $rootScope.repository = {
                loggedUser: {
                    username: user.username,
                    userrole: user.userrole,
                    compid: user.compid,
                    compname: user.compname,
                    authdata: membershipData
                }
            };

            $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
            $cookieStore.put('repository', $rootScope.repository);
        }

        function removeCredentials() {
            $rootScope.repository = {};
            $cookieStore.remove('repository');
            $http.defaults.headers.common.Authorization = '';
        };

        function loadRolesFailed(response) {
            notificationService.displayError('Failed to load Roles.');
        }

        function loadCompaniesFailed(response) {
            notificationService.displayError('Failed to load Companies.');
        }

        function loadLaborNoFailed(response) {
            notificationService.displayError('Failed to load Labor Approval No.');
        }

        function getuserRolesFailed(response) {
            notificationService.displayError('Username doesnot Exist. Try another name.');
        }

        function getCompanyFailed(response) {
            notificationService.displayError('Failed to get Company.');
        }

        function loginFailed(response) {
            notificationService.displayError(response.data);
        }

        function registrationFailed(response) {

            notificationService.displayError('Registration failed. Try again.');
        }

        function isUserLoggedIn() {
            return $rootScope.repository.loggedUser != null;
        }

        return service;
    }



})(angular.module('common.core'));
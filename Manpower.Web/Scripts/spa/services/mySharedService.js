(function (app) {
    'use strict';

    app.factory('mySharedService', mySharedService);
    mySharedService.$inject = ['$rootScope'];

    function mySharedService($rootScope) {

        var sharedService = {};

        sharedService.message = '';
        sharedService.dashboard = '';

        sharedService.prepForBroadcast = function (msg) {
            this.message = msg;
            this.broadcastItem();
        };

        sharedService.broadcastItem = function () {
            $rootScope.$broadcast('handleBroadcast');
        };

        sharedService.prepForBroadcastDashboard = function (msg) {
            this.dashboard = msg;
            this.broadcastItem();
        };

        return sharedService;

    }

})(angular.module('common.core'));
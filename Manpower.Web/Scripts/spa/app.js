﻿(function () {
    'use strict';

    angular.module('Manpower', ['common.core', 'common.ui'])
        .config(config)
        .run(run);


    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })

            .when("/index", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"

            })
             .when("/login", {
                 templateUrl: "scripts/spa/account/login.html",
                 controller: "loginCtrl"
                
             })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
                //resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/users", {
                templateUrl: "scripts/spa/admin/user.html",
                controller: "userCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            }) 
             .when("/data", {
                 templateUrl: "scripts/spa/data/data.html",
                 controller: "dataCtrl",
                 resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/dataAdd", {
                templateUrl: "scripts/spa/data/dataAdd.html",
                controller: "dataAddCtrl"
               
            })
              
           
            .otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();
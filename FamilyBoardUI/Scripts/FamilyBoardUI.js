var FamilyBoardUI = angular.module('FamilyBoardUI', ['ngRoute']);

FamilyBoardUI.controller('LandingPageController', LandingPageController);
FamilyBoardUI.controller('LoginController', LoginController);
FamilyBoardUI.controller('RegisterController', RegisterController);
FamilyBoardUI.factory('LoginFactory', LoginFactory);
FamilyBoardUI.factory('RegistrationFactory', RegistrationFactory);

FamilyBoardUI.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/users', {
            templateUrl: 'users/index'
        })
        
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) { return '/home/two?donuts=' + params.donuts; }
        })
        .when('/routeThree', {
            templateUrl: 'home/three'
        })
        .when('/photos', {
            templateUrl: '/photos/index',
            
        })
        .when('/videos', {
            templateUrl: '/videos/index',

        })
        .when('/login', {
            templateUrl: '/Account/Login',
            controller: LoginController
        })

        .when('/register', {
            templateUrl: '/Account/Register',
            controller: RegisterController
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

FamilyBoardUI.config(configFunction);
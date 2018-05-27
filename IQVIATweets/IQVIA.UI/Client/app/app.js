'use strict';

var app = angular.module('iqviaApp', [
    'ui.router',
    'ui.bootstrap'
]);
/**
* App Config
*/
function Config($stateProvider, $urlRouterProvider, $locationProvider, ViewPath, NavigatePath, AppConstants) {

    $urlRouterProvider.otherwise(NavigatePath.HOME);
    $stateProvider.state('home', {
        url: NavigatePath.HOME,
        templateUrl: ViewPath.HOME
    });
};

var ConfigRequires = [
    '$stateProvider',
    '$urlRouterProvider',
    '$locationProvider',
    'ViewPath',
    'NavigatePath',
    'AppConstants',
    Config
];
app.config(ConfigRequires);


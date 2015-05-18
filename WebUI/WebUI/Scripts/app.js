var TodoApp = angular.module("TodoApp", ["ngRoute"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: ListCtrl, template: '<h2>{{test}}</h2>' }).
            otherwise({ redirectTo: '/' });
    });

var ListCtrl = function ($scope, $location) {
    $scope.test = "Hello1";
};



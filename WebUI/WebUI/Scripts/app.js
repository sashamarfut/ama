var videoApp = angular.module('videoApp', []);


videoApp.controller('VideoListCtrl', function ($scope, $http) {

    $http.get('api/Video').success(function (data) {
        $scope.videos = data;
    });

});





//var VideoApp = angular.module("VideoApp", ["ngRoute"]).
//    config(function ($routeProvider) {
//        $routeProvider.
//            when('/', { controller: VideoList, template: '<h2>{{test}}</h2>' }).
//            otherwise({ redirectTo: '/' });
//    });


//var VideoList = function ($scope, $location, $http) {
    
   
//};



var videoApp = angular.module('videoApp', ["ngRoute"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: VideoListCtrl, templateUrl: 'Templates/videoList.html' }).
            otherwise({ redirectTo: '/' });
});


var VideoListCtrl = function ($scope, $http) {
    $http.get('api/Video').success(function (data) {
         $scope.videos = data;
    });
};



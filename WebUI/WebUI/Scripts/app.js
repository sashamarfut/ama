angular.module('videoApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/',
            {
                controller: 'VideoListCtrl',
                templateUrl: 'Templates/videoList.html'
            })
            .otherwise({ redirectTo: '/' });
        //$locationProvider.html5mode(true);
    });



//controllers
angular.module('videoApp')
    .controller('VideoListCtrl', function ($scope, $http, Video) {

        $scope.loadVideos = function () {
            Video.query({
                limit: $scope.limit,
                offset: $scope.offset
            },
            function (data) {
                $scope.videos = $scope.videos.concat(data);
            });
        }

        $scope.show_more = function () {
            $scope.offset += $scope.limit;
            $scope.loadVideos();
        }

        $scope.limit = 1;
        $scope.offset = 0;
        $scope.videos = [];

        $scope.loadVideos();
    });


//factories
angular.module('videoApp')
    .factory('Video', function ($resource) {
        return $resource('api/Video', { query: { method: 'GET' } });
    });


//app.controller("PostController", ["$scope", function ($scope) {
//    $scope.posts = [
//      { "title": "asdf", "description": "describe" },
//      { "title": "second one", "description": "second describe" },
//    ];
//}]);

//var videoServices = angular.module('videoApp', ['ngResource']);

//videoServices.factory('Video', ['$resource',
//  function ($resource) {
//      return $resource('api/Video', {}, {
//          query: { method: 'GET' }
//      });
//  }]);



//var VideoListCtrl = function ($scope, $http) {

//    $http.get('api/Video?limit=0&offset=0').success(function (data) {
//        $scope.videos = data;
//    });


//    $scope.show_more = function () {
//        $scope.offset += $scope.limit;
//    }


//};


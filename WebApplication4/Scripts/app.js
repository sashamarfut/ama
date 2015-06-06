
var app = angular.module('videoApp', ['ngRoute', 'ngResource', 'LocalStorageModule'])
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

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);



//controllers
app.controller('VideoListCtrl', function ($scope, $http, Video, EditLike, authService) {
 
    $scope.loadVideos = function () {
        Video.query({
            limit: $scope.limit,
            offset: $scope.offset
        },
        function (data) {
            $scope.videos = $scope.videos.concat(data);
        });
    }

    $scope.editLike = function () {
        
        if (!authService.authentication.isAuth) {
            alert('Выполните регистрацию или вход');
        }
        else {
          var id = this.video.VideoId;
          var rowScope = this;

          EditLike.get({
              videoId: id,
              userId: authService.authentication.userName
          },
          function (data) {
              rowScope.video.Likes = 1000; //data 
          });
        }
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

app.controller('signupController', function ($scope, $location, $timeout, authService) {
   
    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.signUp = function () {

        var data = {
            userName: $scope.formInfo.UserName,
            email: $scope.formInfo.Email,
            password: $scope.formInfo.Password,
            confirmPassword: $scope.formInfo.ConfirmPassword
        };

        authService.saveRegistration(data).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Вы зарегистрированы!";
            //startTimer();
         },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    };

    //var startTimer = function () {
    //    var timer = $timeout(function () {
    //        $timeout.cancel(timer);
    //        $location.path('/login');
    //    }, 2000);
    //}
});

app.controller('loginController', function ($scope, $location, authService, $window) {
   
    $scope.message = "";

    $scope.login = function () {

        var data = {
            userName: $scope.formInfo._UserName,
            password: $scope.formInfo._Password
        };

        authService.login(data).then(function (response) {                      
            $("#register").modal('hide');
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
});

app.controller('indexController', function ($scope, $location, $window, authService) {

    $scope.logOut = function () {
        authService.logOut();
    }
  
    $scope.authentication = authService.authentication;
});




//factories
app.factory('Video', function ($resource) {
    return $resource('api/Video', { query: { method: 'GET' } });
});

app.factory('EditLike', function ($resource) {
    return $resource('api/Video/EditLike', { query: { method: 'GET' } });
});





app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var serviceBase = 'http://localhost:51919/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {
        _logOut();

        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });
    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
        
            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);

app.factory('authInterceptorService', ['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            alert('Вы не авторизированы выполнить это действие');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);





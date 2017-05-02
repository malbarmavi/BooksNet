!function () {
    'use strict';

    function init() {
        $('select').chosen({ width: '100%', disable_search_threshold: 10, no_results_text: "...." });
        $('.chosen-books').click(function () {
            $("select").trigger("chosen:updated");
        });
    }

    var app = angular.module('booksNet', ['ngRoute'])
        .config(function ($routeProvider, $locationProvider) {
            $routeProvider.when('/Home', { templateUrl: '/Home/Main', controller: 'index' });
            $routeProvider.when('/Books', { templateUrl: '/Home/Books', controller: 'books' });
            $routeProvider.when('/Books/Details/:bookId', { templateUrl: '/Home/bookDetails', controller: 'bookDetails' });
            $routeProvider.when('/Contact', { templateUrl: '/Home/Contact', controller: 'contact' });
            $routeProvider.when('/About', { templateUrl: '/Home/About', controller: 'about' });
            $routeProvider.otherwise({ redirectTo: '/Home' });
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
        })
        .filter('maxLength', function () {
        return function (s) {
            if (s) {
                return s.length > 20 ? s.slice(0, 17) + '...' : s;
            } else {
                return s;
            }
        }
    });

    app.controller('main', ['$scope', function ($scope) {
        $scope.title = "BooksNet - Home";
        $scope.backgroundSize = false;
        $scope.books = false;

    }]);

    app.controller('index', ['$scope', '$http', function ($scope, $http) {
        $scope.$parent.title = "BooksNet - Home";
        $scope.$parent.backgroundSize = false;
        $scope.$parent.books = false;
    }]);

    app.controller('latesUpload', ['$scope', '$http', function ($scope, $http) {
        $scope.latesUploadBooks = [];
        $http({ method: 'GET', url: '/Api/LatestUpload' }).then(
            function (responde) {
                $scope.latesUploadBooks = responde.data;
            }, function () {
                console.log(responde); console.log('error');
            });
    }]);

    app.controller('topViews', ['$scope', '$http', function ($scope, $http) {
        $scope.topViews = [];
        $http({ method: 'GET', url: '/Api/TopViews' }).then(function (responde) {
            $scope.topViews = responde.data;
        }, function () {
            console.log(responde); console.log('error');
        });
    }]);


    app.controller('books', ['$scope', '$http', function ($scope, $http) {
        $scope.$parent.title = "BooksNet - Books";
        $scope.$parent.backgroundSize = true;
        $scope.$parent.books = true;
        init();
        $scope.booksResult = [];
   
        $http({ method: 'GET', url: '/Api/BooksSearch' }).then(
            function (responde) {
                $scope.booksResult = responde.data;
            }, function () {
                console.log(responde); console.log('error');
            });

       var getSearchData = function (scope) {
            return {
                title: scope.bookTitle,
                age: scope.age,
                category: scope.category,
                categories: scope.categoryList,
                publisher: scope.publisher,
                authors: scope.authorList,
                print: scope.print,
                printDate: scope.printDate
            }
        }

        $scope.search = function () {
            $http({ method: 'GET', url: '/Api/BooksSearch', params: getSearchData($scope) }).then(
                function (responde) {
                    $scope.booksResult = responde.data;
                }, function (responde) {
                    console.log(responde); console.log('error');
                });
        }
    }]);

    app.controller('bookDetails', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        $scope.$parent.title = "BooksNet - Books";
        $scope.$parent.backgroundSize = true;
        $scope.$parent.books = true;

        $http({ method: 'GET', url: '/Api/Books/' + $routeParams.bookId }).then(
            function (responde) {
                $scope.book = responde.data;
            }, function () {
                console.log(responde); console.log('error');
            });

        $scope.updateDownloads = function () {
            $scope.book.Downloads += 1;
            $http({ method: 'PUT', url: '/Api/Books/' + $routeParams.bookId }).then(
                function (responde) {
                        
                }, function () {
                    console.log(responde); console.log('error');
                });
        }
    }]);


    app.controller('about', ['$scope', '$http', function ($scope, $http) {
        $scope.$parent.title = "BooksNet - About";
        $scope.$parent.backgroundSize = true;
        $scope.$parent.books = false;
    }]);

    app.controller('contact', ['$scope', '$http', function ($scope, $http) {
        $scope.$parent.title = "BooksNet - Contact";
        $scope.$parent.backgroundSize = true;
        $scope.$parent.books = false;
    }]);
}();
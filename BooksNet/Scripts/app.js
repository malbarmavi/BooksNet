function init() {
    $('select').chosen({ width: '100%', disable_search_threshold: 10, no_results_text: "...." });
    $('.chosen-container').click(function () {
        $("select").trigger("chosen:updated");
    });
}

var app = angular.module('booksNet', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Home', { templateUrl: '/Home/Main', controller: 'index' });
        $routeProvider.when('/Books', { templateUrl: '/Home/Books', controller: 'books' });
        $routeProvider.when('/Contact', { templateUrl: '/Home/Contact', controller: 'contact' });
        $routeProvider.when('/About', { templateUrl: '/Home/About', controller: 'about' });
        $routeProvider.otherwise({ redirectTo: '/Home' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

app.filter('maxLength', function () {
    return function (s) {
        return s.length > 20 ? s.slice(0, 17) + '...' : s;
    }
});

app.controller('about', ['$scope', '$http', function ($scope, $http) {


}]);

app.controller('contact', ['$scope', '$http', function ($scope, $http) {


}]);
app.controller('index', ['$scope', '$http', function ($scope, $http) {


}]);
app.controller('books', ['$scope', '$http', function ($scope, $http) {
    $scope.booksResult = [];
    init();
    $http({ method: 'GET', url: '/Api/BooksSearch' }).then(
        function (responde) {
            $scope.booksResult = responde.data;
        }, function () {
            console.log(responde); console.log('error');
        });

    getSearchData = function (scope) {
        return {
            title: scope.title,
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
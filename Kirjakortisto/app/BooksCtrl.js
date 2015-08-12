angular.module("Kirjakortisto.BooksController", [])
    .controller("BooksCtrl", ["$scope", "$http", function ($scope, $http) {
        $http.get("/Books/IndexJSON").success(function (data) {
            $scope.model = data;
            $scope.sortReverse = false;
            $scope.sortName = "";
            $scope.searchFilter = "";

        });
    }]);
angular.module("app", ["Kirjakortisto.BooksController"])
    .filter('convertDate', function () {
        return function (jsonDate) {
            var date = (jsonDate.match(/\(.*\)/, ''));
            var convertedDate = date[0];
            date = eval(convertedDate.replace(/\//g, ''));
            return date;
        };
    })
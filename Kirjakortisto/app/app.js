angular.module("app", ["Kirjakortisto.BooksController"])
    .filter('convertDate', function () {
        return function (jsonDate) {
            var date = (jsonDate.match(/\(.*\)/, ''));
            var convertedDate = date[0];
            date = eval(convertedDate.replace(/\//g, ''));
            return date;
        };
    })
    .filter('highlight', function ($sce) {
        return function (text, phrase) {
            if (phrase) text = text.replace(new RegExp('(' + phrase + ')', 'gi'),
              '[[[$1]]]')
            // TODO sanitize html
            text = text.replace(/\[\[\[/g, '<span class="highlighted">').replace(/\]\]\]/g, '</span>');
            return $sce.trustAsHtml(text)
        }
    })
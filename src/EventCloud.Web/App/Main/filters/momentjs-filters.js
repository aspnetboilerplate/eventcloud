(function () {

    angular.module('app').filter('momentFormat', function () {
        return function (date, formatStr) {
            if (!date) {
                return '-';
            }

            return moment(date).format(formatStr);
        };
    })
    .filter('fromNow', function () {
        return function (date) {
            return moment(date).fromNow();
        };
    });

})();
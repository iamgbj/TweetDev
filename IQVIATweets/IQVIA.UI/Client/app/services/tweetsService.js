'use strict';

function tweetsInformation($q, ApiService) {
    this.getTweetsInformation = function (startDate, endDate) {
        var deferred = $q.defer();

        // on Api error
        function onError(error) {
            deferred.reject(error);
        }

        // on Api Success
        function onSuccess(response) {
            deferred.resolve(response);
        }

        ApiService.getTweetsInformation(startDate, endDate).then(onSuccess, onError);
        return deferred.promise;
    };
}

var tweetsRequires = [
    '$q',
    'ApiService',
    tweetsInformation
];

app.service('tweetsService', tweetsRequires);
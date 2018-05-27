'use strict';

function Api($q, $http, ViewPath) {

    var apiService,
        TweetsInfoApi = ViewPath.SERVICE_URL + 'tweets'

   
    /**
    * Gets the Tweets Information
    * @param   {object} request contains user name and MD5 encrypted password.
    * @returns {object} promise.
    */
    function getTweetsInformation(startDate, endDate) {
        return $http.get(TweetsInfoApi + '?startDate=' + startDate + '&endDate=' + endDate);
    }

    apiService = {
        getTweetsInformation: getTweetsInformation
    }

    return apiService;
}

var ApiRequires = [
    '$q',
    '$http',
    'ViewPath',
    Api
];
app.service('ApiService', ApiRequires);


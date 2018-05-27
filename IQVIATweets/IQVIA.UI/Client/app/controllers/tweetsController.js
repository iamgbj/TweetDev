'use strict';

function tweetsCtrl($log, $rootScope, $scope, ApiService, AppConstants, tweetsService,
    NavigatePath, ViewPath) {

    $scope.tweetsInfo = {
        startDate: null,
        endDate: null
    }
    $scope.showTable = false;

    // Pagination Properties
    $scope.options = [10, 20, 30, 40, 50, 100];

    $scope.viewby = $scope.options[5];
   
    $scope.currentPage = 1;
    $scope.itemsPerPage = $scope.viewby;
    $scope.maxSize = 5; //Number of pager buttons to show

    /**
    * Function will make api call to get tweets with specific date
    */
    $scope.getTweetsInfo = function () {
        var startDate = $('#startdate').val();
        var endDate = $('#enddate').val();
        if (startDate == null || startDate == "" || endDate == null || endDate == "") {
            return
        }
        $rootScope.showLoadImage = true;

        tweetsService.getTweetsInformation(startDate, endDate).then(function (response) {
            $scope.showTable = true;
            $scope.tweets = JSON.parse(response.data);
            $scope.totalItems = $scope.tweets.length;
            $rootScope.showLoadImage = false;
        }, function (error) {
            $log.error(error);
            $scope.showTable = false;
            $rootScope.showLoadImage = false;
        });
    }

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        console.log('Page changed to: ' + $scope.currentPage);
    };

    $scope.setItemsPerPage = function (num) {
        $scope.itemsPerPage = num;
        $scope.currentPage = 1; //reset to first page
    }
}

var tweetsInformation = [
   '$log',
   '$rootScope',
   '$scope',
   'ApiService',
   'AppConstants',
   'tweetsService',
   'NavigatePath',
   'ViewPath',
    tweetsCtrl
];

app.controller('tweetsCtrl', tweetsInformation);
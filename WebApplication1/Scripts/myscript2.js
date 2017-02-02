angular.module('MyApp') //extending from previously created angular module MyApp
    //another controller we can add many controllers to angular application
.controller('Part2Controller', function ($scope, PersonInfoService) { //inject ContactService
    $scope.PersonInfo = null;
    PersonInfoService.GetData().then(function (d) {
        $scope.PersonInfo = d.data; // Success
    }, function () {
        alert('Failed'); // Failed
    });
})
.factory('PersonInfoService', function ($http) { // here I have created a factory which is a populer way to create and configure services
    var fac = {};                               //using factory method i am configuring service.
    fac.GetData = function () {
        return $http.get('/Home/GetPersonData');      //gets data from GetData Action in HomeController
    }
    return fac;
});
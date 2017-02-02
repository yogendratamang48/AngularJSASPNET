app.controller("myCntrl", function ($scope, myService) {
    $scope.divEmployee = false;
    GetAllEmployee();
    //To Get All Records 
    function GetAllEmployee() {
        debugger;
        var getData = myService.getEmployees();
        debugger;
        getData.then(function (emp) {
            $scope.employees = emp.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.AddEmployeeDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divEmployee = true;
    }

    function ClearFields() {
        $scope.PersonID = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.Address = "";
        $scope.Email = "";
    }
});
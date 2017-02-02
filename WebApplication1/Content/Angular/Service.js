app.service("myService", function ($http) {

    //get All Eployee
    this.getEmployees = function () {
        debugger;
        return $http.get("Home/GetPersonList");
    };

    // get Employee By Id
    this.getEmployee = function (employeeID) {
        var response = $http({
            method: "post",
            url: "Home/GetPersonByID",
            params: {
                id: JSON.stringify(employeeID)
            }
        });
        return response;
    }

    // Update Employee


    // Add Employee
    this.AddEmp = function (employee) {
        var response = $http({
            method: "post",
            url: "Home/AddEmployee",
            data: JSON.stringify(employee),
            dataType: "json"
        });
        return response;
    }
});

    //Delete Employee
  
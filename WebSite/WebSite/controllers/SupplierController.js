app.controller('SupplierController', ['$scope', '$routeParams', '$location', 'SupplierService', function ($scope, $routeParams, $location, SupplierService) {

    $scope.Suppliers;

    $scope.load = function () {
        SupplierService.getSuppliers()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Suppliers = response.data.Result;
                } else {
                    alert(response.data.Message);
                }
            },
            function (err) {
                alert("Erro");
            });
    };

    $scope.getSupplier = function () {
        if ($routeParams.id != null) {
            SupplierService.getSupplier($routeParams.id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        $scope.name = response.data.Result.Name;
                        $scope.cpfcnpj = response.data.Result.CpfCnpj;
                        $scope.phonenumber = response.data.Result.PhoneNumber;
                        $scope.email = response.data.Result.Email;
                    } else {
                        alert(response.data.Message);
                    }
                },
                function (err) {
                    alert("Erro");
                });
        }
    };

    $scope.insertSupplier = function () {

        var supplier = {
            "Id": null,
            "Name": $scope.name,
            "CpfCnpj": $scope.cpfcnpj,
            "PhoneNumber": $scope.phonenumber,
            "Email": $scope.email
        };

        SupplierService.insertSupplier(supplier)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert(response.data.Message);
                    $scope.go('/supplier/list');
                } else {
                    alert(response.data.Message);
                }
            },
            function (err) {
                alert("Erro");
            });
    };

    $scope.deleteSupplier = function (id) {
        if (confirm("Deseja realmente excluir o fornecedor?")) {
            SupplierService.deleteSupplier(id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        alert("Fornecedor excluído com sucesso.");
                        $scope.load();
                    } else {
                        alert(response.data.Message);
                    }
                },
                function (err) {
                    alert("Erro");
                });
        }
    };

    $scope.edit = function (id) {
        $scope.go('/supplier/edit/' + id);
    };

    $scope.editSupplier = function () {

        var supplier = {
            "Id": $routeParams.id,
            "Name": $scope.name,
            "CpfCnpj": $scope.cpfcnpj,
            "PhoneNumber": $scope.phonenumber,
            "Email": $scope.email
        };

        SupplierService.updateSupplier(supplier)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert("Fornecedor atualizado com sucesso.");
                    $location.path('/supplier/list');
                } else {
                    alert(response.data.Message);
                }
            },
            function (err) {
                alert("Erro");
            });
    };

    $scope.go = function (path) {
        $location.path(path);
    };
}]);
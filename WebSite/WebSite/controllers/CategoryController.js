app.controller('CategoryController', ['$scope', '$routeParams', '$location', 'CategoryService', function ($scope, $routeParams, $location, CategoryService) {

    $scope.Categories;

    $scope.load = function () {
        CategoryService.getCategories()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Categories = response.data.Result;
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.getCategory = function () {
        if ($routeParams.id != null) {
            CategoryService.getCategory($routeParams.id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        $scope.name = response.data.Result.Name;
                        $scope.description = response.data.Result.Description;
                    } else {
                        alert(response.data.Message);
                    }
                },
                    function (err) {
                        alert("Erro");
                    });
        }
    };

    $scope.insertCategory = function () {

        var category = {
            "Id": null,
            "Description": $scope.description,
            "Name": $scope.name
        };

        CategoryService.insertCategory(category)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert(response.data.Message);
                    $scope.go('/category/list');
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.deleteCategory = function (id) {
        if (confirm("Deseja realmente excluir a categoria?")) {
            CategoryService.deleteCategory(id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        alert("Categoria excluída com sucesso.");
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
        $scope.go('/category/edit/' + id);
    };

    $scope.editCategory = function () {
        var category = {
            "Id": $routeParams.id,
            "Description": $scope.description,
            "Name": $scope.name
        };

        CategoryService.updateCategory(category)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert("Categoria atualizada com sucesso.");
                    $location.path('/category/list');
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
app.controller('UserController', ['$scope', '$routeParams', '$location', 'UserService', function ($scope, $routeParams, $location, UserService) {

    $scope.Users;
    $scope.UserData;

    $scope.load = function () {
        UserService.getUsers()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Users = response.data.Result;
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.getName = function () {
        var user = JSON.parse(localStorage.getItem('userData'));
        var name = "";

        if (user != null) {
            name = user.Name;
        }

        return name;
    };

    $scope.getUserProfile = function () {
        var user = JSON.parse(localStorage.getItem('userData'));
        var profile = 0;

        if (user != null) {
            profile = user.UserProfile;
        }

        return profile;
    };

    $scope.getUser = function () {
        if ($routeParams.id != null) {
            UserService.getUserById($routeParams.id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        $scope.name = response.data.Result.Name;
                        $scope.birthdate = response.data.Result.Birthdate;
                        $scope.cpf = response.data.Result.Cpf;
                        $scope.username = response.data.Result.UserName;
                        $scope.userprofile = response.data.Result.UserProfile;
                    } else {
                        alert(response.data.Message);
                    }
                },
                    function (err) {
                        alert("Erro");
                    });
        }
    };

    $scope.submit = function () {
        UserService.getUser($scope.username, $scope.password)
            .then(function (response) {
                if (response.data.IsOk) {
                    localStorage.setItem('userData', JSON.stringify(response.data.Result));
                    $scope.go('/main');
                } else {
                    localStorage.setItem('userData', null);
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.insertUser = function () {

        var user = {
            "Id": null,
            "Name": $scope.name,
            "Birthdate": $scope.birthdate,
            "Cpf": $scope.cpf,
            "UserName": $scope.username,
            "Password": $scope.password,
            "UserProfile": $scope.userprofile,
            "Profile": null
        };

        UserService.insertUser(user)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert(response.data.Message);
                    $scope.go('/user/list');
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.deleteUser = function (id) {
        if (confirm("Deseja realmente excluir o usuário?")) {
            UserService.deleteUser(id)
                .then(function (response) {
                    if (response.data.IsOk) {
                        alert("Usuário excluído com sucesso.");
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
        $scope.go('/user/edit/' + id);
    };

    $scope.editUser = function () {
        var user = {
            "Id": $routeParams.id,
            "Name": $scope.name,
            "Birthdate": $scope.birthdate,
            "Cpf": $scope.cpf,
            "UserName": $scope.username,
            "Password": $scope.password,
            "UserProfile": $scope.userprofile,
            "Profile": null
        };

        UserService.updateUser(user)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert("Usuário atualizado com sucesso.");
                    $location.path('/user/list');
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.logoff = function () {
        if (confirm("Deseja sair do sistema?")) {
            localStorage.removeItem('userData');
            $scope.go('/');
        }
    };

    $scope.go = function (path) {
        $location.path(path);
    };
}]);
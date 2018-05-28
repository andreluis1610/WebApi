app.controller('ConfigurationController', ['$scope', '$routeParams', '$location', 'ConfigurationService', function ($scope, $routeParams, $location, ConfigurationService) {

    $scope.load = function () {
        ConfigurationService.getConfiguration()
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.id = response.data.Result.Id;
                    $scope.timeconfig = response.data.Result.TimeConfig;
                    $scope.value = response.data.Result.Value;
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };

    $scope.editConfiguration = function () {
        var configuration = {
            "Id": $scope.id,
            "TimeConfig": $scope.timeconfig,
            "Value": $scope.value
        };

        ConfigurationService.updateConfiguration(configuration)
            .then(function (response) {
                if (response.data.IsOk) {
                    alert("Configuração atualizada com sucesso.");
                    $location.path('/main');
                } else {
                    alert(response.data.Message);
                }
            },
                function (err) {
                    alert("Erro");
                });
    };
}]);
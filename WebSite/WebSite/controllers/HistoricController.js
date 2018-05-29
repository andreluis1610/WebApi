app.controller('HistoricController', ['$scope', '$window', '$routeParams', '$location', 'HistoricService', function ($scope, $window, $routeParams, $location, HistoricService) {

    $scope.Historic;

    $scope.load = function () {
        HistoricService.getHistoric($routeParams.id)
            .then(function (response) {
                if (response.data.IsOk) {
                    $scope.Historic = response.data.Result;
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

    $scope.back = function () {
        $window.history.back();
    };
}]);
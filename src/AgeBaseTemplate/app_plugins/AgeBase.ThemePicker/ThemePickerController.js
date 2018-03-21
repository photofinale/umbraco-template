angular.module("umbraco").controller("ThemePickerController", function ($scope, $http) {

    $scope.themes = [];

    $http.get("backoffice/ThemePicker/ThemePickerApi/GetThemes").then(function (response) {
        $scope.themes = response.data;
        for (var j = 0; j < $scope.themes.length; j++) {
            if ($scope.model.value.id === $scope.themes[j].id) {
                $scope.themes[j].checked = true;
                break;
            }
        }
    });

});
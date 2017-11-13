
1
2
3
4
5
6
7
8
9
10
11
12
angular.module('app').controller('mainController', function ($scope, notification, toastr) {
    $scope.messages = [];

    $scope.sendMessage = function () {
        var inputval = taskForm.elements.txtTask.value;
        taskForm.elements.txtTask.value = "";
        notification.server.pushNotification(inputval);
        $scope.newMessage = "";
    };

    notification.client.response = function onNewMessage(message) {
        displayMessage(message);
        $scope.$apply();
    };

    function displayMessage(message) {
        toastr.success(message); //To nofiy as fadin and fadout
    }

});
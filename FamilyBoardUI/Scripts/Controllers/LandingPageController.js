//the controller of the app


var LandingPageController = function ($scope) { //pass the $scope object as an argument
    $scope.models = {
        
        title: 'Family Board'
    };
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
LandingPageController.$inject = ['$scope'];
(function () {
    angular.module('app', [])
        .filter('skip', SkipFilter)
        .filter('filterByProperty', FilterByProperty)
        .controller('ShowHideButtonController', ShowHideButtonController)
        .controller('AjaxDataInTableController', AjaxDataInTableController);
}());
var AjaxDataInTableController = (function () {
	var url = 'https://gi-webserver.generali.bg/crmn/api/Office/GetOffices';

	function AjaxDataInTableController($scope, $http) {
		$scope.title = 'Fetching JSON data from a web service and fill the data into a table';
		$scope.offices = [];

		$http.get(url)
			.success(function (response) {
				$scope.offices = response;
			});
	}
	return AjaxDataInTableController;
}());
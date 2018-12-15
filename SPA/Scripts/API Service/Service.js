app.service("APIService", function ($http) {
    this.commonAjaxRequest = function (url) {
        return $http.get(url);
    };
}); 
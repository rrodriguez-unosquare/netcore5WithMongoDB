var LoadingSpinnerService = (function () {

    var $loadingSpinner;

    var show = function () {

        $loadingSpinner.show();
    };

    var hide = function () {
        $loadingSpinner.hide();
    };

    return {
        show: show,
        hide: hide,
        init: function () {

            $loadingSpinner = $("#loading-spinner");
            this.hide();
        }
    };

})();

LoadingSpinnerService.init();
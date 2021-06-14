var BookStoreController = (function (_bookService, _loadingSpinnerService) {

    var $txtSearch, $btnSearch, $bookSearchResult;

    var initHmtlElements = function () {
        $txtSearch = $("#txt-search");
        $btnSearch = $("#button-bookSearch");
        $bookSearchResult = $("#books-result");
    };

    var bindHmtlElements = function () {

        $btnSearch.unbind("click").bind("click", function () {
            searchBooks();
        });
    };

    var searchBooks = function () {
        var dto = new SearchBookDto();
        dto.CriteriaText = $txtSearch.val();
        _loadingSpinnerService.show();
        _bookService.search(dto, function (response) {
            _loadingSpinnerService.hide();
            $bookSearchResult.html(response.html);

        }, function (error) {
            _loadingSpinnerService.hide();
            console.log(error);
        });
    };

    return {
        init: function () {
            initHmtlElements();
            bindHmtlElements();
        }
    };

})(BookService, LoadingSpinnerService);
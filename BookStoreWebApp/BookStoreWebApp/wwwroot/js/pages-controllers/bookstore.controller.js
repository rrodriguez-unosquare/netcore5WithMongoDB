var BookStoreController = (function (_bookService, _loadingSpinnerService) {

    var $txtSearch, $btnSearch, $bookSearchResult, $btnLoadMore;

    var _currentPage = 1;

    var initHmtlElements = function () {
        $txtSearch = $("#txt-search");
        $btnSearch = $("#button-bookSearch");
        $bookSearchResult = $("#books-result");
        $btnLoadMore = $("#btn-loadmore");
    };

    var bindHmtlElements = function () {

        $btnSearch.unbind("click").bind("click", function () {
            _currentPage = 1;
            searchBooks();
        });

        $btnLoadMore.unbind("click").bind("click", function () {
            _currentPage = _currentPage + 1;
            searchBooks();
        });
    };

    var searchBooks = function () {
        var dto = new SearchBookDto();
        dto.CriteriaText = $txtSearch.val();
        dto.PageNumber = _currentPage;

        _loadingSpinnerService.show();
        _bookService.search(dto, function (response) {
            _loadingSpinnerService.hide();
            $bookSearchResult.html(response.html);
            if (response.itemsInPage < dto.PageSize) {
                $btnLoadMore.hide();
            } else {
                $btnLoadMore.show();
            }

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
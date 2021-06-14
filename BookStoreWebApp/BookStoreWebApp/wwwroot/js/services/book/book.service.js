var BookService = (function () {


    var searchBooks = function (dto, successCallBack, errorCallBack) {
        debugger;
        $.ajax({
            url: '/BookStore?handler=SearchBooks',
            type: 'POST',
            dataType: "json",
            headers : {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            data: dto
        })
            .done(function (result) {
                return successCallBack(result);

            }).fail(function (error) {
                return errorCallBack(error);
            })
    
    };

    return {
        search: searchBooks
    };

})();
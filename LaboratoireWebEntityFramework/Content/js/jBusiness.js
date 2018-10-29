$(document).ready(function () {
    $.ajaxSetup({ cache: false });


});

function ListDesCategories() {

    if ($("#indexNews").length === 0) {
        return false;
    }

    var token = $('[name=__RequestVerificationToken]').val();

    $.ajax({
        url: '/News/GetNewsJson',
        type: 'GET',
        data: { "__RequestVerificationToken": token },
        dataType: 'json',
        success: function (data) {

            $('#ProcessedFeed01').empty();
            $('#CopyRightFeed').empty();

            if (data.ResultListNews !== null) {

                var resultFeedHtml = '';

                for (var count = 0; count < data.ResultListNews.length; count++) {

                    resultFeedHtml = resultFeedHtml
                            + '<p>'
                            + '<b>' + data.ResultListNews[count].DtTimezone + ' - ' + data.ResultListNews[count].Title + '</b>'
                            + '</br>'
                            + data.ResultListNews[count].Summary
                            + '</br>'
                            + '<a href="' + data.ResultListNews[count].Link + '" target="_blank" title="' + data.ResultListNews[count].Title + '">' + $('#readMoreNews').val() + '</a>'
                            + '</p>'
                            + '</br>';

                    if (count === 1) {
                        break;
                    }
                }

                $('#ProcessedFeed01').append(resultFeedHtml);
                $('#CopyRightFeed').append(data.ResultListNews[0].CopyRight);
                $("#ProcessedFeed01 img:last-child").remove();

            }
        },

        error: function (erro) {
            try {
                erro = JSON.parse(erro.responseText);
                sweetAlert($('#msgError').val(), erro.Message, 'error');

            }
            catch (err) {
                err = JSON.parse(err);
                sweetAlert($('#msgError').val(), erro.Message, 'error');
            }
        },

        complete: function () {
            //Quelque chose ici, si necessaire !!!
        }
    });
    return false;
}
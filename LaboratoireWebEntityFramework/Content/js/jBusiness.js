$(document).ready(function () {
    $.ajaxSetup({ cache: false });

    //CHARGER TITRE PAR PAGE
    TitrePageWeb();

    ListDesCategories();

    ListeDesCategoriePageProduct();

});

function TitrePageWeb() {

    if ($("#indexHome").length > 0) {
        document.title = 'Home';
    }

    if ($("#indexProduct").length > 0) {
        document.title = 'Product';
    }

    if ($("#indexProductDetail").length > 0) {
        document.title = 'Product Detail';
    }

    if ($("#indexProductCategory").length > 0) {
        document.title = 'Product Category';
    }

}

function ListDesCategories() {

    if ($("#indexHome").length === 0) {
        return false;
    }

    $.ajax({
        url: '/Product/ListeCategorieProduit',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            if (data.dataResult !== null) {
                for (var count = 0; count < 5; count++) {
                    $('#idCategorie' + count).val(data.dataResult[count].Id);
                    $('#nomCategorie' + count).text(data.dataResult[count].NomCaregorie);
                }
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

function ListeDesCategoriePageProduct()
{

    if ($("#indexProduct").length === 0) {
        return false;
    }

    var htmlResultCategories = '';

    $.ajax({
        url: '/Product/ListeCategorieProduit',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            if (data.dataResult !== null) {
                for (var count = 0; count < 5; count++) {
                    $('#idCategorie' + count).val(data.dataResult[count].Id);
                    $('#nomCategorie' + count).text(data.dataResult[count].NomCaregorie);

                    htmlResultCategories += '<li class="p-t-4">' +
                        '<a href="#" class="s-text13 active1">' +
                            data.dataResult[count].NomCaregorie +
                            '</a></li>';
                }

                if (htmlResultCategories !== null) {
                    
                    $('#menuListeCategories').append(htmlResultCategories);
                }
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

function ProductDetail() {

    //if ($("#indexProductDetail").length === 0) {
    //    return false;
    //}

    $.ajax({
        url: '/Product/ProductDetail',
        type: 'GET',
        data: { "idProduct": 1 },
        dataType: 'json',
        success: function (data) {

            console.log(data);
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

function ProductsByCategory() {

    //if ($("#indexProductCategory").length === 0) {
    //    return false;
    //}

    $.ajax({
        url: '/Product/ListeDeProduitsParCategorie',
        type: 'GET',
        data: { "idCategorie": 1 },
        dataType: 'json',
        success: function (data) {

            console.log(data);

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

function ProductsByCategoryAll() {
    $.ajax({
        url: '/Product/ListeDeProduitsParCategorieTous',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            console.log(data);

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
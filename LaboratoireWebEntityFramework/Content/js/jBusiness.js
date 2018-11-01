$(document).ready(function () {
    $.ajaxSetup({ cache: false });

    //PAR CLICK


    //CHARGER TITRE PAR PAGE
    TitrePageWeb();

    //PAGE HOMME
    ListDesCategories();

    //PAGE PRODUCT
    ProductsByCategoryAll();

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

//PAGE HOME
function ListDesCategories() {

    if ($("#indexHome").length === 0) {
        return false;
    }

    $.removeCookie("CategorieIdTemporaire");

    $.ajax({
        url: '/Product/ListeCategorieProduit',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            if (data.dataResult !== null) {
                for (var count = 0; count < 5; count++) {
                    $("#linkCategorie" + count).attr("href", "javascript:EnregistrerLoptiondeCagegorie(" + data.dataResult[count].Id + ")");
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

function EnregistrerLoptiondeCagegorie(idCategorieTemp) {
    $.cookie("CategorieIdTemporaire", idCategorieTemp);
    window.location.href = "/Product";
}

//PAGE PRODUCT
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

                htmlResultCategories += '<li class="p-t-4">' +
                    '<a href="javascript:ProductsByCategory(0);" class="s-text13 active1">' +
                        $('#texteCategoriesTous').val() +
                        '</a></li>';

                for (var count = 0; count < 5; count++) {
                    $('#idCategorie' + count).val(data.dataResult[count].Id);
                    $('#nomCategorie' + count).text(data.dataResult[count].NomCaregorie);

                    htmlResultCategories += '<li class="p-t-4">' +
                        '<a href="javascript:ProductsByCategory('+ data.dataResult[count].Id + ')" class="s-text13 active1">' +
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

function ProductDetail(idProduct) {

    $.ajax({
        url: '/Product/ProductDetail',
        type: 'GET',
        data: { "idProduct": idProduct },
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

function ProductsByCategory(idCategorie) {

    if ($("#indexProduct").length === 0) {
        return false;
    }

    if (idCategorie === 0) {
        ProductsByCategoryAll();
        return false;
    }


    var htmlResultAllProducts = '';

    $.ajax({
        url: '/Product/ListeDeProduitsParCategorie',
        type: 'GET',
        data: { "idCategorie": idCategorie },
        dataType: 'json',
        success: function (data) {

            if (data.dataResult !== null) {

                $("#listeDesProduits").empty();

                for (var count = 0; count < data.dataResult.length; count++) {                    
                    htmlResultAllProducts += '<div class="col-sm-12 col-md-6 col-lg-4 p-b-50">'
                        + '<div class="block2">'
                        + '    <div class="block2-img wrap-pic-w of-hidden pos-relative block2-labelnew">'
                        + '        <img src="/Content/images/' + (data.dataResult[count].Sku === null ? 'pas_dImage' : data.dataResult[count].Sku) + '.jpg" alt="IMG-PRODUCT">'
                        + '        <div class="block2-overlay trans-0-4">'
                        + '           <a href="#" class="block2-btn-addwishlist hov-pointer trans-0-4">'
                        + '                <i class="icon-wishlist icon_heart_alt" aria-hidden="true"></i>'
                        + '                <i class="icon-wishlist icon_heart dis-none" aria-hidden="true"></i>'
                        + '            </a>'
                        + '            <div class="block2-btn-addcart w-size1 trans-0-4">'
                        + '               <button class="flex-c-m size1 bg4 bo-rad-23 hov1 s-text1 trans-0-4">'
                        + '                 ' + $('#texteButtonChariot').val()
                        + '                </button>'
                        + '            </div>'
                        + '        </div>'
                        + '    </div>'
                        + '    <div class="block2-txt p-t-20">'
                        + '        <a href="product-detail.html" class="block2-name dis-block s-text3 p-b-5">'
                        + '            ' + data.dataResult[count].NomProduit
                        + '        </a>'
                        + '       <span class="block2-price m-text6 p-r-5">'
                        + '           $' + data.dataResult[count].Valeur
                        + '        </span>'
                        + '    </div>'
                        + ' </div>'
                        + '</div>'
                }

                $('#listeDesProduits').append(htmlResultAllProducts);

            } else {
                $('#listeDesProduits').append(htmlResultAllProducts);
            }
        },

        error: function (erro) {
            try {
                erro = JSON.parse(erro.responseText);
                sweetAlert($('#msgError').val(), erro.Message, 'error');

            }
            catch (erro) {
                erro = JSON.parse(erro);
                sweetAlert($('#msgError').val(), erro.Message, 'error');
            }
        },

        complete: function () {
            //Quelque chose ici, si necessaire !!!
            $.removeCookie("CategorieIdTemporaire");
        }
    });
    return false;
}

function ProductsByCategoryAll() {

    if ($("#indexProduct").length === 0) {
        return false;
    }

    if ($.cookie('CategorieIdTemporaire') !== null || $.cookie('CategorieIdTemporaire') !== 'undefined' || $.cookie('CategorieIdTemporaire') !== '' || $.cookie('CategorieIdTemporaire') !== 0) {
        if (!isNaN($.cookie('CategorieIdTemporaire'))) {
            ProductsByCategory($.cookie('CategorieIdTemporaire'));
            return;
        } else {
            $.removeCookie("CategorieIdTemporaire");
        }
    }



    var htmlResultAllProducts = '';

    $.ajax({
        url: '/Product/ListeDeProduitsParCategorieTous',
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            $("#listeDesProduits").empty();

            if (data.dataResult !== null) {
                for (var count = 0; count < data.dataResult.length; count++) {                    
                    htmlResultAllProducts += '<div class="col-sm-12 col-md-6 col-lg-4 p-b-50">'
                        + '<div class="block2">'
                        + '    <div class="block2-img wrap-pic-w of-hidden pos-relative block2-labelnew">'
                        + '        <img src="/Content/images/' + (data.dataResult[count].Sku === null ? 'pas_dImage' : data.dataResult[count].Sku) + '.jpg" alt="IMG-PRODUCT">'
                        + '        <div class="block2-overlay trans-0-4">'
                        + '           <a href="#" class="block2-btn-addwishlist hov-pointer trans-0-4">'
                        + '                <i class="icon-wishlist icon_heart_alt" aria-hidden="true"></i>'
                        + '                <i class="icon-wishlist icon_heart dis-none" aria-hidden="true"></i>'
                        + '            </a>'
                        + '            <div class="block2-btn-addcart w-size1 trans-0-4">'
                        + '               <button class="flex-c-m size1 bg4 bo-rad-23 hov1 s-text1 trans-0-4">'
                        + '                 ' + $('#texteButtonChariot').val()
                        + '                </button>'
                        + '            </div>'
                        + '        </div>'
                        + '    </div>'
                        + '    <div class="block2-txt p-t-20">'
                        + '        <a href="product-detail.html" class="block2-name dis-block s-text3 p-b-5">'
                        + '            ' + data.dataResult[count].NomProduit
                        + '        </a>'
                        + '       <span class="block2-price m-text6 p-r-5">'
                        + '           $' + data.dataResult[count].Valeur
                        + '        </span>'
                        + '    </div>'
                        + ' </div>'
                        + '</div>'
                }

                $('#listeDesProduits').append(htmlResultAllProducts);

            } else {
                $('#listeDesProduits').append(htmlResultAllProducts);
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
            $.removeCookie("CategorieIdTemporaire");
        }
    });
    return false;
}


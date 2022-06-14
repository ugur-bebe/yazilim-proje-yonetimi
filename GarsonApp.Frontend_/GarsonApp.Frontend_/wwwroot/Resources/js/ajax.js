function isNumeric(value) {
    return /^-?\d+$/.test(value);
}


$(".btn-add-class").on('click', function () {
   
    var q = parseInt($('select[id=product_count_' + $(this).attr("v") + '] option').filter(':selected').val().toString());
    var q2 = parseInt($('#owner').val());
    var q3 = parseInt($(this).attr("v").toString());
    var v = $(this).attr("v");

    if (isNumeric(q) && isNumeric(q2) && isNumeric(q3)) {

        $.ajax({
            url: "http://localhost:5000/Basket/InsertToBasket",
            data: JSON.stringify
                ({
                    id: 0,
                    ownerId: q2,
                    productId: q3,
                    piece: q
                }),
            contentType: "application/json; charset=utf-8",
            type: "post",
            cache: false,
            success: function (data, textStatus, xhr) {
                statusCode = xhr.status;

                if (statusCode == 201) {
                    alert("Başaralı");
                }
                else if (statusCode == 204) {
                    alert(user_name + " Kullıcı Adı Daha Önceden Alınmış!");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                
            }
        });
    }
});


$(".remove-basket-item").on('click', function () {


    var itemId = parseInt($(this).attr("v").toString());

    if (isNumeric(itemId)) {

        $.ajax({
            url: "http://localhost:5000/Basket/DeleteBasketItem?itemId=" + itemId,
            contentType: "application/json; charset=utf-8",
            type: "get",
            cache: false,
            success: function (data, textStatus, xhr) {
                statusCode = xhr.status;

                if (statusCode == 200) {
                    alert("Silme Başarılı");
                    $("#tr_" + itemId).remove();
                }
                else if (statusCode == 204) {
                    alert(user_name + " Kullıcı Adı Daha Önceden Alınmış!");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    }
});

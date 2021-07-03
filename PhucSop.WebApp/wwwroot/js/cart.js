var CartController = function () {
    this.initialize = function () {
        loadData();
        RegisterEvent();
    }

    function RegisterEvent() {
        $('body').on('click', '.btn_plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            UpdateCart(id, quantity);
        });

        $('body').on('click', '.btn_minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;
            UpdateCart(id, quantity);
        });

        $('body').on('click', '.btn_remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            UpdateCart(id, 0);
        });
    }

    function UpdateCart(id, quantity) {
        const culture = $('#hiddenCulture').val();
        $.ajax({
            type: "POST",
            url: '/' + culture + '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
        });
    }
}

function loadData() {
    const culture = $('#hiddenCulture').val();
    $.ajax({
        type: "GET",
        url: '/' + culture + '/Cart/GetListItems',
        success: function (res) {
            if (res.length == 0) {
                $('#tbl_cart').hide();
            }
            var html = '';
            var total = 0;

            $.each(res, function (i, item) {
                var amount = item.price * item.quantity;
                html += "<tr>"
                    + "<td> <img width=\"60\" src=\"" + item.image + "\" alt=\"\" /></td>"
                    + "<td>" + item.description + "</td>"
                    + "<td><div class=\"input - append\"><input class=\"span1\" style=\"max-width: 34px\" placeholder=\"1\" id=\"txt_quantity_" + item.productId + "\" value=\"" + item.quantity + "\" size=\"16\" type=\"text\">"
                    + "<button class=\"btn btn_minus\" data-id=\"" + item.productId + "\" type =\"button\"> <i class=\"icon-minus\"></i></button>"
                    + "<button class=\"btn btn_plus\" data-id=\"" + item.productId + "\" type =\"button\"><i class=\"icon-plus\"></i></button>"
                    + "<button class=\"btn btn-danger btn_remove\" data-id=\"" + item.productId + "\" type=\"button\"><i class=\"icon-remove icon-white\"></i></button>"
                    + "</div>"
                    + "</td>"

                    + "<td>" + numberWithCommas(item.price) + "</td>"
                    + "<td>" + numberWithCommas(amount) + "</td>"
                    + "</tr>";
                total += amount;
            });
            $('#cart_body').html(html);
            $('#lbl_number_of_items').text(res.length);
            $('#lbl_total').text(total);
        },
    });
}
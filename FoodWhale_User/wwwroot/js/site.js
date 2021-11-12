function setQuantity(upordown, id) {
    var x = 1000;
    var totalprice = 0;
    var itemBox = document.getElementsByClassName('item-box');
    var quantity = document.getElementsByClassName('input-num');
    var money = document.getElementsByClassName('flex-item-price');
    var total = document.getElementsByClassName('total');
    var totalbuy = document.getElementsByClassName('seperate-2');
    var price = accounting.unformat(money[id].innerHTML);
        if (quantity[id].value > 1) {
            if (upordown == 'up') {
                ++document.getElementsByClassName('input-num')[id].value;
                price = price * document.getElementsByClassName('input-num')[id].value * x;
                total[id].innerHTML = accounting.formatMoney(price, "₫");
                var newQty = document.getElementsByClassName('input-num')[id].value;
                UpdateCart(newQty);
            }
            else if (upordown == 'down') {
                --document.getElementsByClassName('input-num')[id].value;
                price = price * document.getElementsByClassName('input-num')[id].value * x;
                total[id].innerHTML = accounting.formatMoney(price, "₫");
                var newQty = document.getElementsByClassName('input-num')[id].value;
                UpdateCart(newQty);
            }
        }
        else if (quantity[id].value == 1) {
            if (upordown == 'up') {
                ++document.getElementsByClassName('input-num')[id].value;
                price = price * document.getElementsByClassName('input-num')[id].value * x;
                total[id].innerHTML = accounting.formatMoney(price, "₫");
                var newQty = document.getElementsByClassName('input-num')[id].value;
                UpdateCart (newQty);
            }
        }
        else {
            document.getElementById('input-num')[id].value = 1;
            price = price * quantity[id] * x;
            total[id].innerHTML = accounting.formatMoney(price, "₫");
            var newQty = document.getElementsByClassName('input-num')[id].value;
            UpdateCart(newQty);
        }
    for (var i = 0; i < itemBox.length; i++) {
        var price = accounting.unformat(money[i].innerHTML);
        price = price * document.getElementsByClassName('input-num')[i].value * x;
        totalprice = totalprice + price;
        totalbuy[0].innerHTML = accounting.formatMoney(totalprice, "₫");
    }
}

function UpdateCart(newQty) {
    $.ajax({
        url: "/Cart/UpdateQty",
        type: "POST",
        data: { data: newQty },
        success: function () {
            alert("Saved");
        },
        error: function () {
            alert('failed');
            alert(error);
        }
    });
}
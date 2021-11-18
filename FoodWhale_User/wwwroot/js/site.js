function setQuantity(upordown, id, oID, Uid, InId) {
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
                newQty = document.getElementsByClassName('input-num')[id].value;
                UpdateCart(oID, Uid, InId, newQty);
            }
            else if (upordown == 'down') {
                --document.getElementsByClassName('input-num')[id].value;
                price = price * document.getElementsByClassName('input-num')[id].value * x;
                total[id].innerHTML = accounting.formatMoney(price, "₫");
                newQty = document.getElementsByClassName('input-num')[id].value;
                UpdateCart(oID, Uid, InId, newQty);
            }
        }
        else if (quantity[id].value == 1) {
            if (upordown == 'up') {
                ++document.getElementsByClassName('input-num')[id].value;
                price = price * document.getElementsByClassName('input-num')[id].value * x;
                total[id].innerHTML = accounting.formatMoney(price, "₫");
                newQty = document.getElementsByClassName('input-num')[id].value;
                UpdateCart(oID, Uid, InId, newQty);
            }
        }
        else {
            document.getElementById('input-num')[id].value = 1;
            price = price * quantity[id] * x;
            total[id].innerHTML = accounting.formatMoney(price, "₫");
            newQty = document.getElementsByClassName('input-num')[id].value;
            UpdateCart(oID, Uid, InId, newQty);
        }
    for (var i = 0; i < itemBox.length; i++) {
        var price = accounting.unformat(money[i].innerHTML);
        price = price * document.getElementsByClassName('input-num')[i].value * x;
        totalprice = totalprice + price;
        totalbuy[0].innerHTML = accounting.formatMoney(totalprice, "₫");
    }
}

function UpdateCart(oID, Uid, InId, newQty) {
    var update = new Object();
    update.oID = oID;
    update.Uid = Uid;
    update.InId = InId;
    update.newQty = newQty;
    var json = JSON.stringify(update);
    if (update != null) {
        $.ajax({     
            url: "../../Cart/UpdateQty",
            data: json,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {    
                console.log('Success');
            },  
            error: function (msg) {
                console.log(JSON.stringify(msg));
            }
        });
    }

}
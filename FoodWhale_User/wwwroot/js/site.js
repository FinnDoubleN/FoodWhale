// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function setQuantity(upordown) {    
    var x = 1000;
    var quantity = document.getElementsByClassName('input-num');
    var money = document.getElementsByClassName('flex-item-price');
    for (i = 0; i < money.length; i++) {
        var price = accounting.unformat(money);
        if (quantity.value > 1) {
            if (upordown == 'up') {
                ++document.getElementById('quantity').value;
                price = price * document.getElementById('quantity').value * x;
                money = accounting.formatMoney(price, "₫");
                document.getElementById('total').innerText = money;
                document.getElementById('totalprice').innerText = money;
            }
            else if (upordown == 'down') {
                --document.getElementById('quantity').value;
                price = price * document.getElementById('quantity').value * x;
                money = accounting.formatMoney(price, "₫");
                document.getElementById('total').innerText = money;
                document.getElementById('totalprice').innerText = money;
            }
        }
        else if (quantity.value == 1) {
            if (upordown == 'up') {
                ++document.getElementById('quantity').value;
                price = price * document.getElementById('quantity').value * x;
                money = accounting.formatMoney(price, "₫");
                document.getElementById('total').innerText = money;
                document.getElementById('totalprice').innerText = money;
            }
        }
        else {
            document.getElementById('quantity').value = 1;
            price = price * quantity * x;
            money = accounting.formatMoney(price, "₫");
            document.getElementById('total').innerText = money;
            document.getElementById('totalprice').innerText = money;
        }
    }
}
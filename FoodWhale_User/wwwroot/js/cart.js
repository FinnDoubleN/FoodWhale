if (document.readyState == 'loading') {
    document.addEventListener('DOMContentLoaded', ready)
} else {
    ready()
}

function ready() {
    var removeBtn = document.getElementsByClassName('btn-delete')
    for (var i = 0; i < removeBtn.length; i++) {
        var btn = removeBtn[i]
        btn.addEventListener('click', removeItem)
    }
    var quantityInput = document.getElementsByClassName('input')
    for (var i = 0; i < removeBtn.length; i++) {
        var input = quantityInput[i]
        input.addEventListener('change', quantityChanged)
    }
}

function removeItem(event) {
    var btnClicked = event.target
    btnClicked.parentElement.parentElement.parentElement.remove()
    updateTotal()
}

function quantityChanged(event) {
    var input = event.target
    var total = 0
    var cartItem = document.getElementsByClassName('cart-item')[0]
    var cartRows = cartItem.getElementsByClassName('item-box')[0]
    if (isNaN(input.value) || input.value <= 0) {
        input.value = 1
    } else {
        var priceItem = cartRows.getElementsByClassName('flex-item-price')[0]
        var quantityItem = cartRows.getElementsByClassName('input-num')[0]
        var price = parseFloat(priceItem.innerText.replace('₫', ''))
        var quantity = quantityItem.value
        total = total + (price * quantity) * 1000
        document.getElementsByClassName('flex-4')[0].innerHTML = '₫' + total
    }
    updateTotal()
}

function updateTotal() {
    var cartItem = document.getElementsByClassName('cart-item')[0]
    var cartRows = cartItem.getElementsByClassName('item-box')
    var total = 0;
    for (var i = 0; i < cartRows.length; i++) {
        var cartRow = cartRows[i]
        var priceItem = cartRow.getElementsByClassName('flex-item-price')[0]
        var quantityItem = cartRow.getElementsByClassName('input-num')[0]
        var price = parseFloat(priceItem.innerText.replace('₫', ''))
        var quantity = quantityItem.value
        total = total + (price * quantity) * 1000
    }
    document.getElementsByClassName('seperate-2')[0].innerHTML = '₫' + total
}
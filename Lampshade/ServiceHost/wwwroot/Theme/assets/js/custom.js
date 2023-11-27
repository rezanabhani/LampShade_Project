
window.addEventListener('load', function () {
    let preload = document.querySelector('.preload');
    preload.style.display = "none";
});


//let comment = document.getElementById('test');
//let div = document.querySelector('.comment');
//let test = "نظر شما با موفقیت ثبت شد و بعد از تایید کارشناسان در سایت منتشر خواهد شد .";

//div.innerHTML = test;
//div.style.display = "none";

//comment.addEventListener('click', function () {
//    div.style.display = "block";

//});


const cookieName = "cart-items";
let davcounter = 1;

let plus = document.getElementById('plus');
let minus = document.getElementById('minus');
plus.addEventListener('click', function () {
    davcounter += 1;
    document.getElementById('daveValue').innerHTML = davcounter;
})
minus.addEventListener('click', function () {
    davcounter -= 1;
    if (davcounter <= 0) {
        davcounter = 1;
        minus.removeEventListener('click');
    }
    document.getElementById('daveValue').innerHTML = davcounter;

})

function addToCart(id, name, picture, unitPrice, productColor) {
    console.log('addToCart function called');
    debugger;
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = parseInt($("#daveValue").innerHTML = davcounter );
    const currentProduct = products.find(x => x.id === id && x.productColor === productColor);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            picture,
            unitPrice,
            productColor,
            count
        }

        products.push(product);
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();

}


function updateCart() {
    debugger;
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);
    const cartItemsWrapper = $("#cart_items_wrapper");
    cartItemsWrapper.html('');
    products.forEach(x => {
        const product = `<div class="single-cart-item">
                            <a href="javascript:void(0)" class="remove-icon" onclick="removeFromCart('${x.id}')">
                                <i class="ion-android-close"></i>
                            </a>
                            <div class="image">
                                <a href="single-product.html">
                                    <img src="/ProductPictures/${x.picture}"
                                         class="img-fluid" alt="">
                                </a>
                            </div>
                            <div class="content">
                                <p class="product-title">
                                    <a href="single-product.html">محصول: ${x.name}</a>
                                </p>
                                <p class="count">تعداد: ${x.count}</p>
                                <p class="count">قیمت واحد: ${x.unitPrice}</p>
                                <p class="count">رنگ محصول: ${x.productColor}</p>
                            </div>
                        </div>`;

        cartItemsWrapper.append(product);
    });
}


function removeFromCart(id) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    const itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}


function changeCartItemCount(id, totalId, count) {
    function convertToToman(number) {
        let tomanValue = number / 1;

        // Use 'fa-IR' locale for Farsi (Persian)
        let formattedToman = tomanValue.toLocaleString('fa-IR', { style: 'decimal', minimumFractionDigits: 0, maximumFractionDigits: 0 });

        return formattedToman;
    }
    debugger;
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    const productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    const product = products[productIndex];
    const newPrice = product.unitPrice * count;
    let tomanAmount = convertToToman(newPrice);
    $(`#${totalId}`).text(tomanAmount);
    //products[productIndex].totalPrice = newPrice;
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}




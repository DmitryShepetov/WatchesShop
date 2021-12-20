
const header = document.querySelector('.header');
const headerTop = document.querySelector('.h-top');
const headerMiddle = document.querySelector('.h-middle');
const headerBottom = document.querySelector('.h-bottom');
const headerBottomHeight = headerBottom.offsetHeight;
const headerCoords = getCoords(headerBottom).top;

debugger;

document.addEventListener("scroll", () => {
    const scrollYPoint = window.scrollY;

    if (scrollYPoint >= headerCoords) {
        header.classList.add('_fixed');
        if (window.innerWidth >= 992) {
            headerMiddle.style.marginBottom = headerBottomHeight + 'px';
        } else {
            headerTop.style.marginBottom = headerBottomHeight + 'px';
        }
    } else {
        header.classList.remove('_fixed');
        headerMiddle.style.marginBottom = 0;
        headerTop.style.marginBottom = 0;
    }
})


const burgerMenu = document.querySelector('.burger');

if (getComputedStyle(burgerMenu).display != 'none') {
    const burgerIcons = document.querySelectorAll('.burger, .menu__close-icon');
    const burgerList = document.querySelector('.menu__list')
    
    for (let icon of burgerIcons) {
        icon.addEventListener("click", () => {
            burgerList.classList.toggle("_active");
        })
    }
    
    
    if (window.jQuery) {
        $('.menu__sub-list').hide();
    
        $(document).ready(function() {
            $('.menu__mobile-arrow').click(function(e) {
                $(this).toggleClass('_active').next().slideToggle(300);
    
                $(this).prev().toggleClass('_active');
            })
        })
    }
}

const cartCounter = document.querySelector('.cart__counter');

if (cartCounter.textContent != "0") {
    cartCounter.classList.add('_active');
} else {
    cartCounter.classList.remove('_active');
}


function сartCounterPlus() {
    cartCounter.textContent = parseInt(cartCounter.textContent) + 1;

    cartCounter.classList.add('_active');
}

function сartCounterMinus() {
    cartCounter.textContent = parseInt(cartCounter.textContent) - 1;

    if (parseInt(cartCounter.textContent) < 1) {
        cartCounter.classList.remove('_active');

        // window.location.reload();
    } 
}

const itemCounters = document.querySelectorAll('.item__btns');

if (itemCounters.length > 0) {
    for (let counters of itemCounters) {
        counters.addEventListener("click", (e) => {
            if (e.target.classList.contains('js-plus')) {
                let text = e.target.previousElementSibling;
                
                let num = parseInt(text.textContent);

                text.textContent = ++num;
                console.log(text);
            } else if (e.target.classList.contains('js-minus')) {
                let text = e.target.nextElementSibling;

                let num = parseInt(text.textContent);

                
                if (num > 1) {
                    text.textContent = --num;
                } else {
                    window.location.reload();                  
                }
            }

            reloadTotalPrice();
        })
    }
}

function reloadTotalPrice() {
    const totalPrice = document.querySelector('.price--int');

    let totalPriceNum = 0;

    const items = document.querySelectorAll('.item');
    
    for (let item of items) {
        const price = item.querySelector('.item__price--int');
        let priceNum = parseInt(price.textContent);
        
        const count = item.querySelector('.item__counter');
        let countNum = parseInt(count.textContent);
        
        totalPriceNum += (priceNum * countNum);       
    }

    totalPrice.textContent = totalPriceNum;
}


function addToCart(itemId) {
    $.post('/functions/add_to_cart.php', {id: String(itemId)}, function(data){});

    // window.location.reload();
    сartCounterPlus(); 
}

function deleteFromCart(itemId) {
    $.post('/functions/delete_from_cart.php', {id: String(itemId)}, function(data){});

    window.location.reload();
}

function cartPlus(itemId) {
    $.post('/functions/cart_plus.php', {id: String(itemId)}, function(data){});

    // window.location.reload();
    сartCounterPlus();
}

function cartMinus(itemId) {
    $.post('/functions/cart_minus.php', {id: String(itemId)}, function(data){});

    // window.location.reload();
    сartCounterMinus();
}


function getCoords(elem) {
    let box = elem.getBoundingClientRect();

    return {
        top: box.top + pageYOffset,
        left: box.left + pageXOffset
    };
}


$(document).ready(function () {
    $('.main-slider').slick({
        dots: true,
        autoplay: true,
        autoplaySpeed: 5000,
        centerMode: true,
        variableWidth: true,

        responsive: [
            {
                breakpoint: 769,
                settings: {
                    dots: false,
                    autoplay: false,
                    infinite: false,
                }
            },
        ]
    });
    debugger

    $('.catalog-slider__content').slick({
        // centerMode: true,
        slidesToShow: 4,
        slidesToScroll: 4,
        autoplay: true,
        autoplaySpeed: 10000,
        speed: 900,
        // draggable: false,

        responsive: [
            {
                breakpoint: 993,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 2,
                }
            },
            {
                breakpoint: 769,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    autoplay: false,
                }
            },
            {
                breakpoint: 577,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    autoplay: false,
                }
            },
        ]
    });

    $('.product-slider__slider-1').slick({
        arrows: true,
        infinite: false,
        asNavFor: ".product-slider__slider-2",
        draggable: false,
        // rows: 2,
        vertical: true,
        slidesToShow: 4,
        focusOnSelect: true,
        // autoplay: true,
        // autoplaySpeed: 5000,
        // centerMode: true,
        // variableWidth: true,

        // responsive: [
        //     {
        //         breakpoint: 769,
        //         settings: {
        //             dots: false,
        //             autoplay: false,
        //             infinite: false,
        //       }
        //     },
        // ]
    });

    $('.product-slider__slider-2').slick({
        arrows: false,
        infinite: false,
        fade: true,
        asNavFor: ".product-slider__slider-1",
        // autoplay: true,
        // autoplaySpeed: 5000,
        // centerMode: true,
        // variableWidth: true,

        responsive: [
            {
                breakpoint: 993,
                settings: {
                    arrows: true,
                    // centerMode: true,
                }
            },
        ]
    });
})


// Корзина
// --------------------------------------------------------------------

// --------------------------------------------------------------------


if (window.jQuery) {
    $(document).ready(function () {
        $('.filters__spoiler-btn').click(function (e) {
            $(this).toggleClass('_active').next().slideToggle(300);

            $(this).prev().toggleClass('_active');
        })
    })
}


const filtersBtn = document.querySelector('.catalog__filters-btn');

if (filtersBtn) {
    const filters = document.querySelector('.catalog__filters');

    filtersBtn.addEventListener('click', () => {
        filters.classList.toggle('_active');
    })

    const filtersCloseBtn = document.querySelector('.filters__close-icon');

    filtersCloseBtn.addEventListener('click', () => {
        filters.classList.toggle('_active');
    })
}


const filterResetBtn = document.querySelector('.filters__reset-btn');

if (filterResetBtn) {
    const checkboxes = document.querySelectorAll('.checkbox__input');

    filterResetBtn.addEventListener("click", (e) => {
        e.preventDefault();
        for (let checkbox of checkboxes) {
            if (checkbox.checked == true) {
                checkbox.checked = false;
            }
        }
    })
}
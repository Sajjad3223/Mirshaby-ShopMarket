//#region Address
function EditAddress(addressId) {
    $.get("/userpanel/addresses/edit-address/" + addressId, function (result) {
        $('#Modal').modal('show');
        $("#ModalTitle").html("ویرایش آدرس");
        $("#ModalBody").html(result);
    });
}

$(".add-address").click(event => {
    $.get("/userpanel/addresses/add-address",
        function (result) {
            $('#Modal').modal('show');
            $("#ModalTitle").html("افزودن آدرس جدید");
            $("#ModalBody").html(result);
        });
});

function changeActiveAddress(addressId) {
    $.get("/userpanel/addresses/set-active-address/" + addressId, function (result) {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer);
                toast.addEventListener('mouseleave', Swal.resumeTimer);
            }
        });
        Toast.fire({
            icon: 'success',
            title: 'آدرس با موفقیت تغییر کرد!'
        });
    });
}
//#endregion

//#region Cart
function AddToCart(id, count = 1) {
    event.preventDefault();
    $.get("/product/addtocart/" + id + "/" + count).done(result => {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer);
                toast.addEventListener('mouseleave', Swal.resumeTimer);
            }
        });

        Toast.fire({
            icon: 'success',
            title: 'به سبد خریدتان اضافه شد'
        });

        //location.reload();
        $('#cart-preview').replaceWith(result);
        NiceScroll();
    });
}

function DecreaseOrderItem(id) {
    event.preventDefault();
    var $input = $(event.currentTarget).parents('.num-block').find('input.in-num');

    var count = parseFloat($input.val()) - 1;

    count = count < 1 ? 1 : count;

    $.get("/product/decreasecartitem/" + id).done(result => {

        if (count < 2) {
            $(event.currentTarget).addClass('dis');
        } else {
            $(event.currentTarget).removeClass('dis');
        }
        $input.val(count);

        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer);
                toast.addEventListener('mouseleave', Swal.resumeTimer);
            }
        });

        Toast.fire({
            icon: 'success',
            title: 'از کالا مورد نظر یک عدد کم شد.'
        });

        //location.reload();
        $('#cart-preview').replaceWith(result);
        NiceScroll();
    });

    $input.change();
    return false;
}

function RemoveCartItem(id) {
    event.preventDefault();
    Swal.fire({
        text: "از سبد خریدتان حذف شود؟",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/product/removecartitem/" + id).done(result => {
                Swal.fire({
                    title: 'حذف شد!',
                    confirmButtonText: 'باشه',
                    icon: 'success'
                });
                //location.reload();
                $('#cart-preview').replaceWith(result);
                NiceScroll();
            });
        }
    });
}

function IncreaseOrderItem(id) {
    event.preventDefault();
    var $input = $(event.currentTarget).parents('.num-block').find('input.in-num');

    var count = parseFloat($input.val()) + 1;
    
    $.get("/product/increasecartitem/" + id).done(result => {

        $input.val(count);
        if (count > 1) {
            $(event.currentTarget).parents('.num-block').find(('.minus')).removeClass('dis');
        }

        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer);
                toast.addEventListener('mouseleave', Swal.resumeTimer);
            }
        });

        Toast.fire({
            icon: 'success',
            title: 'به کالای مورد نظر یک عدد اضافه شد.'
        });
        //location.reload();
        $('#cart-preview').replaceWith(result);
        NiceScroll();
    });

    $input.change();
    return false;
}

function AddToWishlist(id) {
    event.preventDefault();
    $.get("/product/addtowishlist/" + id).done(response => {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer);
                toast.addEventListener('mouseleave', Swal.resumeTimer);
            }
        });


        Toast.fire({
            icon: 'success',
            title: 'به لیست  پسندده شده ها اضافه شد'
        });

        $('#user-Likes').replaceWith(response);
    })
}
//#endregion

function SendComment(id) {
    event.preventDefault();
    const score = parseInt($('input[type=radio][name=rating]:checked').attr('id'));
    $.get("/Product/AddComment/" + id + "/" + score + "/" + $('#comment').val()).done(function (result) {
        Swal.fire({
            title: 'نظر شما با موفقیت ثبت شد!',
            confirmButtonText: 'باشه',
            icon: 'success'
        });
        console.log(result);
        $('#productComments').replaceWith(result);
    });
};

function RemoveComment(id) {
    event.preventDefault();
    $.get("/Product/RemoveComment/" + id ).done(function (result) {
        Swal.fire({
            title: 'نظر شما با موفقیت حذف شد!',
            confirmButtonText: 'باشه',
            icon: 'success'
        });

        $('#productComments').replaceWith(result);
    });
}


NiceScroll = function () {
    $('.do-nice-scroll').niceScroll({
        railalign: 'left',
    });
}
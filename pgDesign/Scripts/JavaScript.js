
$(".rotate").click(function () {
        $(this).toggleClass("down");
})


// Skickar bild till Modal
$('.getSrc').click(function () {
    var src = $(this).attr('src');
    $('.showPic').attr('src', src);
});

$('.getSrc').click(function () {
    var src = $(this).attr('name');
    $('.modal-title').attr('name', name);
});






       
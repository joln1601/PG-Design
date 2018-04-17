//Script för att skicka rätt bild till modal
function showimg(id, src) {
    var modal = document.getElementById('myModal');

    var img = document.getElementById(id)
    var modalImg = document.getElementById("myImg")
    modalImg.src = src;
}

// Script för att sätta bredden på bilderna på startsidan
var delayInMilliseconds = 250;
setTimeout(function () {
    $(document).ready(function () {
        $("#second_div").css({
            'width': ($("#first_div").width())
        });
        $("#second_div2").css({
            'width': ($("#first_div2").width())
        });
        $("#second_div3").css({
            'width': ($("#first_div3").width())
        });
    });
}, delayInMilliseconds);

//Script För att ändra aktiv nav-bar item
        $(document).ready(function () {
            $('.nav-link li.active').removeClass('active');
        $('a[href="' + location.pathname + '"]').closest('.nav-item').addClass('active');
    });

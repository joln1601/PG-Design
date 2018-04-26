//Script För att ändra aktiv nav-bar item
        $(document).ready(function () {
            $('.nav-link li.active').removeClass('active');
        $('a[href="' + location.pathname + '"]').closest('.nav-item').addClass('active');
});

//Script för hamburgarikonen (Öppna och stänga sidomenyn änr den är i responsivt läge)
        function w3_open() {
            document.getElementById("mySidebar").style.display = "block";
        }
        function w3_close() {
            document.getElementById("mySidebar").style.display = "none";
        }


// SLIDE SPEED
$('.carousel').carousel({
    interval: 10000 // 10s
});

var datetime = setTimeout(showtime, 1000);

// GET TIME CLOCK
function showtime() {
    var tick = $("#clock");
    var clock = new Date();
    var hours = clock.getHours();
    var minutes = clock.getMinutes();
    var seconds = clock.getSeconds();
    var ngay = clock.getDate();
    var thang = clock.getMonth() + 1;
    var nam = clock.getFullYear();
    if (ngay < 10)
        ngay = "0" + ngay;
    if (thang < 10)
        thang = "0" + thang;
    if (hours < 10)
        hours = "0" + hours;
    if (minutes < 10)
        minutes = "0" + minutes;
    if (seconds < 10)
        seconds = "0" + seconds;
    var curTime = "<span class='font-weight-bold'>" + hours + ":" + minutes + ":" + seconds + "</span>, <span>" + ngay + "/" + thang + "/" + nam + "</span>";
    tick.html(curTime);
    setTimeout("showtime()", 1000);
}

// FULLSCREEN
function openFullscreen() {
    var elem = document.documentElement;
    if (elem.requestFullscreen) {
        elem.requestFullscreen();
        $('button').hide();
        $('#clock').attr("onclick", "closeFullscreen()");
    } else if (elem.mozRequestFullScreen) { /* Firefox */
        elem.mozRequestFullScreen();
        $('button').hide();
        $('#clock').attr("onclick", "closeFullscreen()");
    } else if (elem.webkitRequestFullscreen) { /* Chrome, Safari & Opera */
        elem.webkitRequestFullscreen();
        $('button').hide();
        $('#clock').attr("onclick", "closeFullscreen()");
    } else if (elem.msRequestFullscreen) { /* IE/Edge */
        elem.msRequestFullscreen();
        $('button').hide();
        $('#clock').attr("onclick", "closeFullscreen()");
    }
}

// EXIT FULLSCREEN
function closeFullscreen() {
    if (document.exitFullscreen) {
        document.exitFullscreen();
        $('button').show();
        $('#clock').attr("onclick", "openFullscreen()");
    } else if (document.mozCancelFullScreen) {
        document.mozCancelFullScreen();
        $('button').show();
        $('#clock').attr("onclick", "openFullscreen()");
    } else if (document.webkitExitFullscreen) {
        document.webkitExitFullscreen();
        $('button').show();
        $('#clock').attr("onclick", "openFullscreen()");
    } else if (document.msExitFullscreen) {
        document.msExitFullscreen();
        $('button').show();
        $('#clock').attr("onclick", "openFullscreen()");
    }
}


$(window).resize(function () {
    var width = $(window).width();
    //console.log(width);
    var tbody = $("#example1 tbody");
    if (width >= 1620) {
        $('.xd').remove();
        $('.carousel-indicators').css('top', '-45px!important');
    } else if (width < 1620 && width >= 1150) {
        $('.xd').remove();
        //$('<br class="xd" />').insertAfter('ol.carousel-indicators');
    } else if (width < 1150 && width >= 600) {
        $('.xd').remove();
        $('<br class="xd" /><br class="xd" />').insertAfter('ol.carousel-indicators');
    } else if (width < 600 && width >= 380) {
        $('.xd').remove();
        $('<br class="xd" /><br class="xd" /><br class="xd" /><br class="xd" />').insertAfter('ol.carousel-indicators');
        if (tbody.children().length != 0) {
            $('#_footer').removeClass('fixed-bottom');
        }
    } else if (width < 380) {
        $('.xd').remove();
        $('<br class="xd" /><br class="xd" /><br class="xd" /><br class="xd" /><br class="xd" />').insertAfter('ol.carousel-indicators');
        if (tbody.children().length != 0) {
            $('#_footer').removeClass('fixed-bottom');
        }
    }
});
$(document).ready(function () {
    var scrollButton = $("#Scroll-top");
    $(window).scroll(function () {
        if ($(this).scrollTop() >= 1000) {
            scrollButton.show();
        }
        else {
            scrollButton.hide();
        }
    });
    scrollButton.click(function () {
        $("html,body").animate({ scrollTop: 0 }, 600);
    });
});
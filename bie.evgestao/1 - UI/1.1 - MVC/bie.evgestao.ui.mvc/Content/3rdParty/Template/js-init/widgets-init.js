$(function () {
    "use strict";
    $('a[href="#"]').click(function (a) {
        a.preventDefault()
    })
}), $(function () {
    "use strict";
    $(".todo-box li input").on("click", function () {
        $(this).parent().toggleClass("todo-done")
    })
}), $(function () {
    "use strict";
    var a = 0;
    $(".timeline-scroll .tl-row").each(function (b, c) {
        var d = $(c);
        a += d.outerWidth() + parseInt(d.css("margin-left"), 10) + parseInt(d.css("margin-right"), 10)
    }), $(".timeline-horizontal", this).width(a)
}), $(function () {
    "use strict";
    $(".input-switch-alt").simpleCheckbox()
}), $(function () {
    "use strict";
    $(".scrollable-slim").slimScroll({
        color: "#8da0aa",
        size: "10px",
        alwaysVisible: !0
    })
}), $(function () {
    "use strict";
    $(".scrollable-slim-sidebar").slimScroll({
        color: "#8da0aa",
        size: "10px",
        height: "100%",
        alwaysVisible: !0
    })
}), $(function () {
    "use strict";
    $(".scrollable-slim-box").slimScroll({
        color: "#8da0aa",
        size: "6px",
        alwaysVisible: !1
    })
}), $(function () {
    "use strict";
    $(".loading-button").click(function () {
        var a = $(this);
        a.button("loading")
    })
}), $(function () {
    "use strict";
    $(".tooltip-button").tooltip({
        container: "body"
    })
}), $(function () {
    "use strict";
    $(".alert-close-btn").click(function () {
        $(this).parent().addClass("animated fadeOutDown")
    })
}), $(function () {
    "use strict";
    $(".popover-button").popover({
        container: "body",
        html: !0,
        animation: !0,
        content: function () {
            var a = $(this).attr("data-id");
            return $(a).html()
        }
    }).click(function (a) {
        a.preventDefault()
    })
}), $(document).ready(function () {
    $.material.init()
}), $(function () {
    "use strict";
    $(".popover-button-default").popover({
        container: "body",
        html: !0,
        animation: !0
    }).click(function (a) {
        a.preventDefault()
    })
});
var mUIColors = {
    "default": "#3498db",
    gray: "#d6dde2",
    primary: "#00bca4",
    success: "#2ecc71",
    warning: "#e67e22",
    danger: "#e74c3c",
    info: "#3498db"
},
    getUIColor = function (a) {
        return mUIColors[a] ? mUIColors[a] : mUIColors["default"]
    };


//document.getElementById("fullscreen-btn").addEventListener("click", function () {
//    screenfull.enabled && screenfull.request()
//});

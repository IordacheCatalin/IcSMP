"use strict";
(function () {

    $(document).ready(function () {

        $("#searchInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("tr").each(function () {
                var text = $(this).text().toLowerCase();
                if (text.indexOf(value) !== -1) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        });
    });
})();
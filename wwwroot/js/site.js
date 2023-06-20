"use strict";
(function () {
     //Search function

    $(document).ready(function () {

        $("#searchInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $(".table-reverse tr").each(function () {
                var text = $(this).text().toLowerCase();
                if (text.indexOf(value) !== -1) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        });

        $("#reportBtn").click(function () {              
            $("#reportsPartialVeiwContainer").toggleClass("ShowOn");
        })

        //Date and time
        function updateDateTime() {
            var now = new Date();
            var datetimeElement = document.getElementById("datetime");
            datetimeElement.textContent = now.toLocaleString();
        }        
        updateDateTime();
              
        setInterval(updateDateTime, 1000);
    });
})();

    $(document).ready(function () {
        $("#operationAdd").on("click", function () {
            var num1 = $('#number1').val();
            var num2 = $('#number2').val();
            $.ajax({
                url: "/Home/Add",
                type: "GET",
                data: {
                    number1: num1,
                    number2: num2
                }
            })
            .done(function (partialViewResult) {
                $("#computationResults").html(partialViewResult);
            });
        });
    });

$('.rent').click(function () {
    $("#CustomerNameSurname").val("");
    $("#CustomerNoInput").val("");
    var carid = $(this).data('value');

    // AJAX request
    $.ajax({
        async: true,
        url: '/Car/RentalModal',
        type: 'POST',
        dataType: "json",
        data: { 'carid': carid },

        success: function (FormModal) {

            //debugger;
            $(this).closest('form').find("input[type=text],input[type=date] ").val("");
            var carmodel = FormModal.model;
            var carbrand = FormModal.brand;
            var carcolor = FormModal.color;
            var carId = FormModal.id;
            var proyear = FormModal.proYear;
            var geartype = FormModal.gearType;
            var carprice = FormModal.price;
            $("#CarPrice").val(carprice);
            $("#proyear").html(proyear);
            $("#geartype").html(geartype);
            $("#CarId").val(carId);
            $("#brand").html(carbrand);
            $("#model").html(carmodel);
            $("#color").html(carcolor);

            $(".modal").modal("show");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('error');
        }

    });
});


$('.getrental').click(function () {
    // debugger
    var rentalid = $(this).data('value');

    // AJAX request
    $.ajax({
        async: true,
        url: '/Rental/GetRental',
        type: 'POST',
        dataType: "json",
        data: { 'rentalid': rentalid },

        success: function (Result, price) {

            //debugger;
            $(this).closest('form').find("input[type=text],input[type=date] ").val("");
             debugger;
            var Price = Result.price;
            var Id = Result.result.id;
            var custId = Result.result.customerId;
            var carId = Result.result.carId;
            var totPr = Result.result.totalPrice;
            var rentBeg = Result.result.rentBegin.split("T")[0];
            var rentEnd = Result.result.rentEnd.split("T")[0];
            $("#CarId").val(carId);
            $("#Id").val(Id);
            $("#CustomerNoInput").val(custId);
            $("#RentBegin").val(rentBeg);
            $("#RentEnd").val(rentEnd);
            $("#TotalPrice").val(totPr);
            $("#CarPrice").val(Price);

            $(".rentalmodal").modal("show");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('error');
        }

    });
});


$('#CustomerNoInput').change(function () {
    $("#CustomerNameSurname").val("");
    //$("#CustomerSurname").html("");
    var customerId = $(this).val();

    // AJAX request
    $.ajax({
        async: true,
        url: '/Customer/GetCustomer',
        type: 'POST',
        dataType: "json",
        data: { 'customerId': customerId },

        success: function (Customer) {
            // debugger;
            if (Customer.success == false) {
                alert(Customer.responseText);
            } else {
                var CustomerName = Customer.name;
                var CustomerSurname = Customer.surname;
                $("#CustomerNameSurname").val(CustomerName + " " + CustomerSurname);
                //$("#CustomerSurname").html(CustomerSurname);
            }

        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('error');
        }

    });
});
$('.dateinput').change(function () {
    $("#TotalPrice").html("");
    // debugger;
    var RentBegin = new Date($('#RentBegin').val());
    var RentBegind = RentBegin.getDate().toString();
    var RentEnd = new Date($('#RentEnd').val());
    var RentEndd = RentEnd.getDate().toString();
    if (RentBegind == "NaN" || RentEndd == "NaN") {
        return;
    } else {
        var Day = Math.floor((Date.UTC(RentEnd.getFullYear(), RentEnd.getMonth(), RentEnd.getDate()) - Date.UTC(RentBegin.getFullYear(), RentBegin.getMonth(), RentBegin.getDate())) / (1000 * 60 * 60 * 24));/*RentEnd.getDate() - RentBegin.getDate();*/
        if (Day < 1) {
            alert("lütfen tarihleri kontrol ediniz alış tarihi veriş tarihinden sonra olamaz");
            $("#TotalPrice").html("");
        } else {
            var carPrice = $("#CarPrice").val();
            var totalPrice = Day * carPrice;
            var carId = $("#CarId").val();
            $("#CarId").val(carId);
            $("#TotalPrice").val(totalPrice);
        }
    }

});
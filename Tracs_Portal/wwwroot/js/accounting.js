
$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
    var currentpath = "/" + location.pathname.split("/")[1];
    $('li.active').removeClass('active');
    $('a[href="' + currentpath + '"]').closest('li').addClass('active');

    var dateObj = new Date();
    $('#datepickerTo').datepicker("setDate", dateObj);
    dateObj.setDate(dateObj.getDate() - 7);
    $('#datepickerFrom').datepicker("setDate", dateObj);

    $(".btnSearch").prop('disabled', true);

    var selectedSearchBy = $('#selectedRaido').data("value");
    $('.searchType').hide();
    if (selectedSearchBy == null || selectedSearchBy == "") {
        $('.searchType').hide();
        $(".btnSearch").prop('disabled', true);
    }
    else {
        $('#divSearch' + selectedSearchBy).show();
        $(".btnSearch").prop('disabled', false);
    }

    $("input[name$='RadioSearch']").click(function () {
        var idSeaarch = $(this).val();
        $("div.searchType").val('');
        $('.caselist').hide();
        $("div.searchType").prop('disabled', true);
        $("div.searchType").hide();
        $("#divSearch" + idSeaarch).show();
        $(".btnSearch").prop('disabled', false);
        $("#divSearch" + idSeaarch).prop('disabled', false);

        $("#ddlList").removeAttr('required');
        $("#txtSearch1").removeAttr('required');
        
        switch (idSeaarch) {
            case "1":
                $(".txtSearch").text("");
                $("#txtSearch1").prop('required', true);
                break;
            case "2":
                $("#ddlList").prop('required', true);
                break;
            default:
                break;
        }
    });

    $("#searchButton").click(function (e) {
        var $form = $(this.form);
        $form[0].classList.add('was-validated');
        if ($form[0].checkValidity() === false) {
            e.preventDefault();
            e.stopPropagation();
            return false;
        }
        $.ajax({
            cache: false,
            type: "GET",
            url: "/Accounting/Home/GetCaseList",
            contentType: "application/json; charset=utf-8",
            data: $('#form1').serialize(),
            dataType: "HTML",
            async: true,
            success: function (response) {

                $('#divCaseList').html(response);
                $('#divCaseList').show();
            },
            failure: function (response) {
                alert('Customer content load failed.');
            }
        })
    });

});
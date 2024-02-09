// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    if ($('[type="date"]').prop('type') != 'date') {
        $('[type="date"]').datepicker();
    }
    if (typeof String.prototype.endsWith !== 'function') {
        String.prototype.endsWith = function (suffix) {
            return this.indexOf(suffix, this.length - suffix.length) !== -1;
        };
    }
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }

    today = yyyy + '-' + mm + '-' + dd;
    $('[type="date"]').attr("max", today);
    $('[type="date"]').attr("min", '2000-01-01');
    $("input[id*='assword']").each(function () {
        ToggleEyeButtonDisplay($(this));
    });
    $("input").each(function () {
        $(this).attr("autocomplete", "none");

    });
    $("textarea").each(function () {
        $(this).attr("autocomplete", "none");
    });
    $("input[id*='assword']").on('keyup keypress blur change paste', function (e) {
        ToggleEyeButtonDisplay($(this))
    });
    $('.show-password').click(function show() {
        $(this).find('.icon').hasClass('fa fa-eye-slash')
            ?
            $(this).find('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye')
            :
            $(this).find('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
        var PasswordField = $(this).closest('tr,div').find("input[id*='assword']");
        if (!PasswordField)
            PasswordField = $(this).closest("input[id*='Password']");
        if (PasswordField)
            PasswordField.attr('type', $(this).find('.icon').hasClass('fa-eye-slash') ? 'text' : 'password');
    });
    ResizeForMobile();

    fixBootstrapModalZoomBug();


});


function ResizeForMobile() {
    var resize = function () {
        var height = $(window).height();  // Get the height of the browser window area.
        var element = $("body");          // Find the element to resize.
        element.height(height);           // Set the element's height.
    }
    resize();
    $(window).bind("resize", resize);
}

if ($('#formReturnAddressSave').length) $("#formReturnAddressSave").validate({ errorClass: 'validate-error' });
if ($('#formCompanyBranchSave').length) $("#formCompanyBranchSave").validate({ errorClass: 'validate-error' });
if ($('#formCompanyDetailsSave').length) $("#formCompanyDetailsSave").validate({ errorClass: 'validate-error' });




$("input[type='password']").attr('maxlength', '20');
function ToggleEyeButtonDisplay(e) {
    var ShowPasswordField = $(e).closest('tr,div').find(".show-password");
    ShowPasswordField.css('display', $.trim($(e).val()) == '' ? 'none' : '');
}



$('textarea').blur(function (e) {

    var sentences = $(this).val().split(".");
    var out_text = "";
    if (sentences.length <= 1) {
        $(this).val(ucFirst($(this).val()));
        return;
    }
    var text = $(this).val();

    for (var index = 0; index < sentences.length; index++) {
        var sentence = sentences[index];
        var cp_value = ucFirst(sentence);
        out_text += cp_value;
        //if (index < $(this).length-1)
        if (!sentence.endsWith(".") && $.trim(cp_value).length > 0 && !(index >= sentences.length - 1 && !$.trim(text).endsWith(".")))
            out_text += '.';
    }
    $(this).val(out_text);
});
function ucFirst(str, force) {
    str = force ? str.toLowerCase() : str;

    return str.replace(/(?:^|(?:^\s+)|(?:\.\s))([a-zA-Z])/,

        function (firstLetter) {
            return firstLetter.toUpperCase();
        });
}

function ComboChangeEvent(e, freeText) {
    var divParent = $(e).closest('div');
    $(divParent).find("label.error:visible, label.validate-error:visible").each(function () {
        $(this).remove();
    });
    var combobox = $(e).data("kendoComboBox") || $(e).data("kendoDropDownList");
    if (combobox.selectedIndex === -1 && combobox.value()) {
        if (combobox.dataSource.view().length > 0) {
            combobox.select(0);
        }
        else {
            if (!freeText) {
                combobox.value("");
                var $label = $("<label class='validate-error' for='" + $(e).attr('id') + "'>");
                $label.attr('id', $(e).attr('id') + "-error");
                $label.text("This field is required."); $label.css("color", "red");
                $label.appendTo(divParent);
            }
        }
    }

}

//  address area
if ($('#formReturnAddressSave').length) $("#formReturnAddressSave").validate({ errorClass: 'validate-error' });
if ($('#formCompanyBranchSave').length) $("#formCompanyBranchSave").validate({ errorClass: 'validate-error' });
if ($('#formCompanyDetailsSave').length) $("#formCompanyDetailsSave").validate({ errorClass: 'validate-error' });

function ValidateFormForKendo(FormName) {
    var status = true;
    var scrolled = false;
    $("#" + FormName).find("input[data-role='combobox'][optional!='true'], input[data-role='dropdownlist'][optional!='true']").each(function () {
        if (!$(this).closest('div').is(':visible'))
            return;
        if (this.id.toLowerCase().indexOf('branchid') >= 0 || this.id.toLowerCase().indexOf('siteid') >= 0)
            if ($(this).text().length == 0) {
                var data = ($(this).data('kendoComboBox') || $(this).data("kendoDropDownList")).dataSource._data
                for (var x = 0; x < data.length; x++) {
                    if (data[x].Text == $(this).val()) {
                        $(this).val(data[x].Value);
                    }
                }
            }

        if ($(this).val().length == 0 && $(this).closest('form').attr('id') == FormName) {
            var $label = $("<label  class='error' for='" + this.id + "'>");
            $label.attr('id', this.id + "-error");

            $label.text("This field is required."); $label.css("color", "red");
            var divParent = $(this).closest('div');
            $(divParent).find("label.error, label.validate-error").each(function () {
                $(this).remove();
            });
            $label.appendTo(divParent);
            status = false;
        }

    });
    return status;
}
var bank_address_submits = 0;
var return_address_submits = 0;
var bank_details_submits = 0;
function ShowAddNewAddressForm(e, divName, formName, saveButtonName) {

    var $Company = $(e).closest('.form-group').find("[id $= 'CompanyId']");
    var $CallingElement = e;
    var $UserId = $(e).closest('form').find("[id $= 'UserId']")
    if (!$Company.val() && formName == "formCompanyBranchSave") {
        //alert('Bank is not selected!');
        changeFeedbackMessage("error", 'End User Company is not selected!')
        return;
    }
    var cancelButtonName = "btnCancelDialog_" + saveButtonName;
    var isMobile = $("#IsMobile").val().toLowerCase() == "false" ? false : true;

    $('#' + divName).css('zIndex', 99999999999999);
    $('#' + divName).dialog({
        autoOpen: true,
        position: { my: "center", at: !isMobile ? "top+" + $("#navigation").height : "", of: window },
        //width: !isMobile ? $(window).width()/2 : $(window).width(),
        resizable: true,
        modal: true,
        title: formName == "formCompanyBranchSave" ? "New Branch" : (formName == "formCompanyDetailsSave" ? "New End User Company" : "New Return Address"),
        create: function (event) {

            if (!isMobile)
                $(this).parent().css({ 'position': 'fixed' });
        },
        beforeClose: function (event, ui) {
            if (!isMobile)
                $("body").css({ overflow: 'inherit' })
        },
        open: function () {
            $('.ui-dialog').css('z-index', 9999999999);
            if (!isMobile) {
                var dialog = $(this).data("ui-dialog");
                dialog.option("width", $(window).width() / 2);
                $(window).resize(function () {
                    var dialog = $('#' + divName).data("ui-dialog");
                    dialog.option("position", dialog.options.position);
                    dialog.option("width", $(window).width() / 2);

                });
                $("body").css({ overflow: 'hidden' })
            }


            if (formName == "formCompanyBranchSave") {
                $(this).find("#CompanyId").val($Company.val());
                $(this).find("#CompanyAddressUserId").val($UserId.val());
                bank_address_submits = 0;
                CompanyAddressInitUSA();
            }
            else if (formName == "formCompanyDetailsSave") {
                bank_details_submits = 0;
                CompanyDetailsInitUSA();
            }
            else
                return_address_submits = 0;

            $('#' + saveButtonName).attr('form', formName);
            $('#' + saveButtonName).attr('class', "btn btn-primary");
            $('#' + cancelButtonName).attr('class', "btn btn-primary");
            $('.btn-primary').css('background-color', '#F57B20')
            $("#" + formName).submit(function (e) {

                FixAutoCompleteValidation();
                e.preventDefault();
                if (!ValidateFormForKendo(formName))
                    return;

                switch (formName) {
                    case "formCompanyBranchSave":
                        if (bank_address_submits > 0) {
                            return;
                        }
                        break;
                    case "formCompanyDetailsSave":
                        if (bank_details_submits > 0) {
                            return;
                        }
                        break;
                    case "formReturnAddressSave":
                        if (return_address_submits > 0) {
                            return;
                        }
                        break;
                }

                if ($(this).find(".error:visible").length == 0 && $(this).find(".validate-error:visible").length == 0)
                    SaveNewAddress(divName, formName, $CallingElement);

            });

        },
        close: function () {
            //clear();
            $('label.error').remove();
            $('label.validate-error').remove();
            $('#' + formName)[0].reset();
        },
        buttons: [
            {
                style: "float:right",
                id: saveButtonName,
                text: "Save",
                click: function () {
                    $("#" + formName).submit();
                }
            },
            {
                style: "float:right",
                id: cancelButtonName,
                text: "Cancel",
                click: function () {
                    $(this).dialog("close");
                    //$(this).remove();
                }
            }

        ]
    });
}
function SaveNewAddress(divName, formName, callingElement) {
    $.ajax({
        url: $("#" + formName).attr('action'),
        type: 'POST',
        data: $("#" + formName).serialize(),
        async: false,
        success: function (result) {
            var data = result.data;
            switch (formName) {
                case "formCompanyBranchSave":
                    break;
                case "formCompanyDetailsSave":
                    break;
                case "formReturnAddressSave":
                    break;
            }

            if (result.status == 1) {
                switch (formName) {
                    case "formCompanyBranchSave":
                        bank_address_submits++;
                        LoadCompanyAddresses(data.siteId);
                        break;
                    case "formCompanyDetailsSave":
                        bank_details_submits++;
                        var $Company = $(callingElement).closest('.form-group').find("[id $= 'CompanyId']");
                        var dataSource = $Company.data("kendoComboBox").dataSource;
                        dataSource = dataSource.add({ BankID: data.companyId, BankName: $("#CompanyName").val() });
                        var combobox = $Company.data("kendoComboBox");
                        combobox.select(function (dataItem) {
                            return dataItem.BankID == data.companyId;
                        });
                        LoadCompanyAddresses(data.siteId);
                        break;
                    case "formReturnAddressSave":
                        return_address_submits++;
                        var new_address = $("#divReturnAddresstemplate").find(".return-address-class:first").clone();
                        $(new_address).find("#rdSelectedAdress").attr("checked", data.IsDefault);
                        $(new_address).find("#rdSelectedAdress").attr("index", data.ReturnAddressId);
                        $(new_address).find("#lblReturnAddress").text(data.FullAddress);

                        $("#divReturnAddresses").append(new_address);
                        break;
                }


                $('#' + divName).dialog("close");
                return true;
            }
            else {
                changeFeedbackMessage("error", result.message)
                return false;
            }
        },
        error: function (request, status, error) {

            changeFeedbackMessage("error", request.statusText)
            return false;
        }
    });
}
function FixAutoCompleteValidation(errorLabelElements) {

    if (!errorLabelElements)
        errorLabelElements = $("label.error:visible");
    errorLabelElements.each(function () {
        if ($(this).siblings('input.custom-combobox-input-left').length > 0) {
            var divParent = $(this).closest('div');
            var cloned_label = $(this).clone();
            $(this).remove();
            cloned_label.insertAfter(divParent);
        }
    });
}
$("input[name*='Tracking']").each(function () {
    $(this).rules('add', {
        maxlength: 12
    }); $(this).rules('add', {
        number: true
    });
    $(this).rules('add', {
        number: true
    });
});
$("input[name$='serial_no']").each(function () {
    $(this).rules('add', {
        maxlength: 6
    });
});
$("input[name$='SerialNumber']").each(function () {
    $(this).rules('add', {
        number: true
    });
});
$("input[name$='DispatchNumber']").each(function () {

    $(this).rules('add', {
        maxlength: 14
    });
    $(this).rules('add', {
        number: true
    });
});





var profile_submits = 0;
function ShowUserProfile(e) {


    if (!$('.navbar-toggle').hasClass('collapsed'))
        $('.navbar-toggle').click();
    var divName = "divUserProfile";
    var formName = "frmUserProfile";
    var saveButtonName = "btnUpdateUserProfile";
    var cancelButtonName = "btnCancelUserProfile";
    var changePasswordButtonName = "btnChangePassword";
    var isMobile = $("#IsMobile").val().toLowerCase() == "false" ? false : true;


    $('#' + divName).css('zIndex', 99999999999999);
    //$('#' + divName).css('overflow', 'auto');
    $('#' + divName).dialog({
        autoOpen: true,
        position: { my: "center", at: "", of: window },

        resizable: true,
        modal: true,
        title: "Profile",
        create: function (event) {

            if (!isMobile)
                $(this).parent().css({ 'position': 'fixed' });
        },
        beforeClose: function (event, ui) {
            if (!isMobile)
                $("body").css({ overflow: 'inherit' })
            //else
            //    $("body").css("overflow-y", 'auto');
        },
        open: function () {
            $('.ui-dialog').css('z-index', 9999999999999);
            if (!isMobile) {
                var dialog = $(this).data("ui-dialog");
                dialog.option("width", $(window).width() / 2);
                $(window).resize(function () {
                    var dialog = $('#' + divName).data("ui-dialog");
                    dialog.option("position", dialog.options.position);
                    dialog.option("width", $(window).width() / 2);
                    if (!$('.navbar-toggle').hasClass('collapsed'))
                        $('.navbar-toggle').click();
                });
                $("body").css({ overflow: 'hidden' })
            }
            else {
                $('input').css("font-size", "initial");
                $(window).resize(function () {
                    var dialog = $('#' + divName).data("ui-dialog");
                    dialog.option("position", dialog.options.position);
                    dialog.option("width", $(window).width());
                });
            }
            profile_submits = 0;
            if (typeof CountryChangeEvent == 'function') CountryChangeEvent();
            $('#' + saveButtonName).attr('form', formName);
            $('#' + saveButtonName).parent().css("width", "100%")
            $('#' + saveButtonName).attr('class', "btn btn-primary");
            $('#' + cancelButtonName).attr('class', "btn btn-primary");
            $('#' + changePasswordButtonName).attr('class', "btn btn-primary");
            //$('#' + formName)[0].reset();
            $('.btn-primary').css('background-color', '#F57B20')

            $("#navEditAddress").removeClass("active");
            $("#edit-address").removeClass("active");
            $("#navEditProfile").addClass("active");
            $("#edit-profile").addClass("active");
            $("#" + formName).submit(function (e) {
                e.preventDefault();
                if (profile_submits > 0)
                    return;
                var status1 = (typeof ValidateProfile == 'function') ? ValidateProfile(formName) : true;;
                var status2 = ValidatePhoneNumber($("#prof-phone-txt"));
                if (!status1 || !status2)
                    return;
                if ($(this).find(".error:visible").length == 0 && $(this).find(".validate-error:visible").length == 0) {
                    SaveUserProfile(divName, formName);
                }
            });

        },
        close: function () {
            //clear();
            $('label.error').remove();
            $('label.validate-error').remove();
            $('#' + formName)[0].reset();
            if (typeof CheckIsContractor == 'function') CheckIsContractor();

            $("#" + formName).find("input[data-role='combobox'][optional!='true'], input[data-role='dropdownlist'][optional!='true']").each(function () {
                var comboBox = $(this).data("kendoComboBox") || $(this).data("kendoDropDownList");
                var comboValue = comboBox.value();
                comboBox.select(function (dataItem) {
                    return dataItem.Value == parseInt(comboValue);
                });
            });


        },
        buttons: [
            {
                id: changePasswordButtonName,
                text: "Change Password",
                click: function () {
                    ShowChangePassword();
                }
            },
            {
                style: "float:right",
                id: saveButtonName,
                text: "Update",
                click: function () {
                    $("#" + formName).submit();
                }
            },
            {
                style: "float:right",
                id: cancelButtonName,
                text: "Cancel",
                click: function () {
                    $(this).dialog("close");
                    //$(this).remove();
                }
            }

        ]
    });
}
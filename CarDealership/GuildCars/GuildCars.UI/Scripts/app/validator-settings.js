$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        }
        else {
            error.insertAfter(element);
        }
    }
});

$.validator.addMethod("lessThan", function (value, element, param) {
    var $otherElement = $(param);
    return parseInt(value, 10) <= parseInt($otherElement.val(), 10);
}, 'Sales Price must not be greater than MSRP');

$.validator.addMethod("rangeBasedOnType", function (value, element, param) {
    if ($(param).val() == 'New') {
        return parseInt(value, 10) >= 0 && parseInt(value, 10) <= 1000;
    }
    else {
        return parseInt(value, 10) > 1000;
    }
}, 'New mileage must be equal to or less than 1000. Used must be above.');
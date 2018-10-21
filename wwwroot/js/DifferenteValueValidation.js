$.validator.addMethod('different-value',
    function (value, element, params) {
        var otherValues = $(params).val();

        return typeof(otherValues) === "string" 
            ? otherValues !== value
            : otherValues.indexOf(value) < 0;
    });

$.validator.unobtrusive.adapters.add('different-value',
    ['exclude'],
    function (options) {
        var element = $(options.form).find(options.params['exclude']);
        options.rules['different-value'] = element;
        options.messages['different-value'] = options.message;
    });
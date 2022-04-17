jQuery.postJson = function (url, data, success, error, dataType) {
    if (dataType === void 0) { dataType = "json"; }
    if (typeof (data) === "object") { data = JSON.stringify(data); }
    var ajax = {
        url: url,
        type: "POST",
        //contentType: "application/json; charset=utf-8",
        dataType: dataType,
        data: data,
        success: success,
        error: error
    };

    return jQuery.ajax(ajax);
};

jQuery.postJson = function (url, data, success, error, antiForgeryToken, dataType) {
    if (dataType === void 0) { dataType = "json"; }
    //if (typeof (data) === "object") { data = JSON.stringify(data); }
    var ajax = {
        url: url,
        type: "POST",
        //contentType: "application/json; charset=utf-8",
        dataType: dataType,
        data: data,
        success: success,
        error: error
    };
    if (antiForgeryToken) {
        ajax.headers = {
            "__RequestVerificationToken": antiForgeryToken
        };
    };

    return jQuery.ajax(ajax);
};

function WarningMsg(msg, id) {
    Notiflix.Report.warning(
        'Warning',
        msg,
        'OK',
        () => {
            var l_Id = $(id);
            log({ l_Id });
            if (!isInvalidData(l_Id)) {
                l_Id.focus();
            }
        },
    );
}

function log(obj) {
    //console.log(obj);
}

function isInvalidData(val) {
    return val == undefined || val == null || val == '' || val.length == 0;
}
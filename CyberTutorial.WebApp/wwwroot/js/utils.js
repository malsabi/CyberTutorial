function ToggleSpinner(id, content, showSpinner = true) {
    let button = document.getElementById(id.replace('#', ''));

    if (showSpinner) {
        button.setAttribute("disabled", "disabled");
        button.innerHTML = '<div class="d-flex align-items-center"><div class="spinner-grow spinner-grow-sm me-2" role="status" aria-hidden="true"></div>'.concat(content, '</div>');
        return;
    }

    button.removeAttribute("disabled");
    button.innerHTML = content;
}

function toCamel(o) {
    var newO, origKey, newKey, value
    if (o instanceof Array) {
        return o.map(function (value) {
            if (typeof value === "object") {
                value = toCamel(value)
            }
            return value
        })
    } else {
        newO = {}
        for (origKey in o) {
            if (o.hasOwnProperty(origKey)) {
                newKey = (origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey).toString()
                value = o[origKey]
                if (value instanceof Array || (value !== null && value.constructor === Object)) {
                    value = toCamel(value)
                }
                newO[newKey] = value
            }
        }
    }
    return newO
}
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
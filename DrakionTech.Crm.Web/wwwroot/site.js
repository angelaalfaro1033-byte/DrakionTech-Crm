window.initTooltips = () => {
    if (typeof bootstrap === "undefined") {
        console.warn("Bootstrap no está cargado");
        return;
    }

    document
        .querySelectorAll('[data-bs-toggle="tooltip"]')
        .forEach(el => {
            new bootstrap.Tooltip(el);
        });
};
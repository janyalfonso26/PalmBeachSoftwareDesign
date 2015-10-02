// Show spinner
function ShowSpinner(message) {

    if (message === undefined) {

        $.blockUI({
           
            message: '<img src=/Content/images/AnimatedLoadingStatusBar.gif>',
            css: {
                border: '3px solid #009FD6',
                padding: 15
            },
            baseZ: 2000
        });
    } else {
        $.blockUI({
            message: '<b>' + message + '</b>',
            css: {
                border: '3px solid #009FD6',
                padding: 15,
                color: '#000000'
            },
            baseZ: 2000
        });
    }
}

// Hide spinner
function HideSpinner() {
    $.unblockUI();
}
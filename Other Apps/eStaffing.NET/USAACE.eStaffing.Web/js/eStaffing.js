/* Selects all text of a text control */
function SelectAll(textControl) {
    setTimeout(function () { textControl.select(); }, 50);
}

function SignData(data, signatureField) {
    var pluginName = "USAACE.eStaffing.Web.ActiveX.DigitalSignatures";

    try {
        var signaturePlugin = new ActiveXObject(pluginName);
        var result = signaturePlugin.SignData(data);
        if (result != null && result != "") {
            document.getElementById(signatureField).value = result;
            __doPostBack('reviewSignature');
        }
    }
    catch (ex) {
        alert("The eStaffing ActiveX Control is not available or not installed.")
    }
}

function OpenServerDocument(strid) {
    var pluginName = "USAACE.eStaffing.Web.ActiveX.OpenDocuments";

    try {
        var openDocumentPlugin = new ActiveXObject(pluginName);
        if (!openDocumentPlugin.OpenServerDocument(strid)) {
            alert("Error opening document from server.");
        }
    }
    catch (ex) {
        alert("The eStaffing ActiveX Control is not available or not installed.")
    }
}

function pageLoad() {
    // Fix IE9 large tables

    $('.formGrid').html(function () {
        var value = $(this).html();
        $(this).html(value.replace(/td>\s+<td/g, 'td><td'));
    });

    //Slideshow code

    var slideShow = $('.slideShow > *');
    if (slideShow.length > 0)
    {
        slideShow.hide();
        slideShow.first().show();
        slideShow.first().toggleClass('activeSlide');
        setInterval(function () {
            var active = $('.slideShow > .activeSlide');
            active.toggleClass('show').fadeOut(600);

            var next = active.is(':last-child') ? slideShow.first() : active.next();
            next.toggleClass('activeSlide').fadeIn(600);
        }, 3000);
    }
}
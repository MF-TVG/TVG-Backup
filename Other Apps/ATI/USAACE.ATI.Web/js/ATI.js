/* Prints the contents of a div in another window */
function PrintDiv(strid) {
    var content = document.getElementById(strid);
    var printWindow = window.open('', '', 'left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
    printWindow.document.write('<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"><html><body>');
    printWindow.document.write('<link href="style/ATIPrint.css" type="text/css" rel="Stylesheet" />');
    printWindow.document.write(content.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
    printWindow.close();
}

/* Downloads a div to excel */
function DownloadReport(strid) {
    var content = document.getElementById(strid);
    var printWindow = window.open('', '', '');
    printWindow.document.writeln('<meta http-equiv="Content-type" content="application/vnd.ms-excel; charset=UTF-8;"/>');
    printWindow.document.writeln('<meta http-equiv="Content-Disposition" content="attachment; filename=Report.xls">');
    printWindow.document.write(content.innerHTML);
    printWindow.document.close();
}

/* Selects all text of a text control */
function SelectAll(textControl) {
    setTimeout(function () { textControl.select(); }, 50);
}
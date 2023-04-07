/* --------------------------------------- FOR CSV ---------------------------------------- */

/* Collect Data from Table into an array then make a csv table*/
function htmlToCSV(html, filename) {
    var data = [];
    var get_rows = document.querySelectorAll("table tr");

    for (var i = 0; i < get_rows.length; i++) {
        var rows = [];
        var cols = get_rows[i].querySelectorAll("td, th");

        for (var j = 0; j < cols.length; j++) {
            rows.push(cols[j].innerText);
        }

        data.push(rows.join(","));
    }

    downloadCSVFile(data.join("\n"), filename);
}

/* Download CSV FIle - unclear */
function downloadCSVFile(csv, filename) {
    var csv_file, download_link;

    csv_file = new Blob([csv], { type: "text/csv" });

    download_link = document.createElement("a");

    download_link.download = filename;

    download_link.href = window.URL.createObjectURL(csv_file);

    download_link.style.display = "none";

    document.body.appendChild(download_link);

    download_link.click();
}

/* Apply function to button */
document.getElementById("download-csv").addEventListener("click", function () {

    var html = document.querySelector("table").outerHTML;

    htmlToCSV(html, "students.csv");
});

/* --------------------------------------- FOR PDF ---------------------------------------- */

function htmlToPDF() {
    var doc = new jsPDF('p', 'pt', 'letter');
    var htmlstring = '';
    var tempVarToCheckPageHeight = 0;
    var pageHeight = 0;
    pageHeight = doc.internal.pageSize.height;
    specialElementHandlers = {
        // element with id of "bypass" - jQuery style selector  
        '#bypassme': function (element, renderer) {
            // true = "handled elsewhere, bypass text extraction"  
            return true
        }
    };
    margins = {
        top: 150,
        bottom: 60,
        left: 40,
        right: 40,
        width: 50
    };
    var y = 20;
    doc.setLineWidth(2);
    doc.text(200, y = y + 70, "List of All Students");
    doc.autoTable({
        html: '#dataTable',
        startY: 70,
        theme: 'grid',
        columnStyles: {
            //0: {
            //    cellWidth: 45,
            //},
            //1: {
            //    cellWidth: 45,
            //},
            //2: {
            //    cellWidth: 45,
            //},
            //3: {
            //    cellWidth: 45,
            ////}
        },
        styles: {
            minCellHeight: 40
        }
    })
    doc.save('List of Students.pdf');
}

/* --------------------------------------- FOR PRINT ---------------------------------------- */

function printTable() {

    var today = new Date(); //make date instance
    var date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear(); //get current date,month, & year
    var table = document.getElementById("dataTable"); //get table 
    var header = document.getElementById("header"); // get header
    // get footer


    var style = "<style>";
    style = style + "body {background: none; color: #000; -webkit-print-color-adjust: exact !important;}";
    style = style + "table {width: 100%;}";
    style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
    style = style + "padding: 2px 3px;text-align: center;}";
    style = style + "p {text-align: right; color: maroon; margin-top: 3rem;}";
    style = style + "header {height: fit-content; width: 100%; background-color: rgb(181, 218, 255); font-weight: 700; font-size: 1.6rem; padding: 20px 0 20px 0; text-align: center; margin-bottom: 2rem;}";
    style = style + "footer {width: 100%; background-color: rgb(181, 218, 255); height: fit-content; padding: 20px 0 20px 0; text-align:center;}"
    style = style + "</style>";

    var win = window.open();                                    //   opens a new window
    win.document.write(style);                                  //   add the style.
    win.document.write(header.outerHTML);                       //   write header to new window
    win.document.write(table.outerHTML);                        //   write table to new window
    win.document.write("<p> Sheet Printed on: " + date + "</p>");   //   write current date to new window

    win.print();
    win.document.close();

} 

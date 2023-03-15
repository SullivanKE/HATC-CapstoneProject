// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function findElementIndex(table, selector) {
    "use strict";
    let elementSearch = document.querySelectorAll(selector);
    let i = -1;
    for (let j = 0; j < elementSearch.length; j++) { // Find the next available index
        let node = elementSearch[j];
        if (node.id.startsWith(table)) { // Is it the right type of input
            if (node.id != table + j) {
                i = j;
                j = elementSearch.length + 1;
            }
        }
    }
    return i;
}

function addResourceTable() {

    let i = findElementIndex("resourceTableP", "input");
    if (i == -1) {
        i = 0;
    }

    let input = document.getElementById("newResource").value;
    let newTable = document.getElementById("hiddenResourcesTable").cloneNode(true);
    newTable.id = "resourceTable" + i;
    newTable.removeAttribute("hidden");

    let p = newTable.getElementsByTagName("input");
    p[0].innerHTML = input;
    p[0].id = "resourceTableP" + i;
    p[0].name = "Dt.Resources.ToList()[" + i + "].Item";
    p[0].for = "Dt.Resources.ToList()[" + i + "].Item";
    p[0].value = input;

    resourceArr.push(input);

    newTable.childNodes[3].onclick = function () { // Delete table
        removeResourceTable(input);
        let table = document.getElementById("resourceTable" + i);
        table.parentElement.removeChild(table);
    }
    document.getElementById("resources").appendChild(newTable);
}
function removeResourceTable(i) {
    let index = resourceArr.indexOf(i)
    {
        resourceArr.splice(index, 1);
    }
}

function addResolutionTable() {

    let i = findElementIndex("resolutionTableP", "input");
    if (i == -1) {
        i = 0;
    }

    let input = document.getElementById("newResolution").value;
    let newTable = document.getElementById("hiddenResolutionsTable").cloneNode(true);
    newTable.id = "resolutionTable" + i;
    newTable.removeAttribute("hidden");

    let p = newTable.getElementsByTagName("input");
    p[0].innerHTML = input;
    p[0].id = "resolutionTableP" + i;

    p[0].name = "Dt.Resolution.ToList()[" + i + "].Item";
    p[0].for = "Dt.Resolution.ToList()[" + i + "].Item";
    p[0].value = input;

    resolutionArr.push(input);

    newTable.childNodes[3].onclick = function () { // Delete table
        removeResolutionTable(input);
        let table = document.getElementById("resolutionTable" + i);
        table.parentElement.removeChild(table);
    }
    document.getElementById("resolutions").appendChild(newTable);
}
function removeResolutionTable(i) {
    let index = resolutionArr.indexOf(i)
    if (index >= 0) {
        resolutionArr.splice(index, 1);
    }
}

function addDowntimeTable() {

    let i = findElementIndex("tableTableP", "input");
    if (i == -1) {
        i = 0;
    }

    let head = document.getElementById("newTableHead").value;
    let input = document.getElementById("newTable").value;
    let newTable = document.getElementById("hiddenTablesTable").cloneNode(true);
    newTable.id = "downtimeTable" + i;
    newTable.removeAttribute("hidden");

    let b = new tableObj(head, input);
    let p = newTable.getElementsByTagName("input");

    console.log(p);

    p[0].id = "tableHeadP" + i;
    p[0].name = "Dt.Tables.ToList()[" + i + "].Name";
    p[0].for = "Dt.Tables.ToList()[" + i + "].Name";
    p[0].value = head;

    p[1].id = "tableInputP" + i;
    p[1].name = "CsvTables[" + i + "]";
    p[1].for = "CsvTables[" + i + "]";
    p[1].value = input;

    p[2].id = "tableHeadP" + i;
    p[2].name = "Dt.Tables.ToList()[" + i + "].HasHead";
    p[2].for = "Dt.Tables.ToList()[" + i + "].HasHead";

    p[3].id = "tableHeadP" + i;
    p[3].name = "Dt.Tables.ToList()[" + i + "].IsComplication";
    p[3].for = "Dt.Tables.ToList()[" + i + "].IsComplication";

    tableArr.push(b);
    console.log(newTable.childNodes);
    newTable.childNodes[3].onclick = function () { // Delete table
        removeDowntimeTable(head);
        let table = document.getElementById("downtimeTable" + i);
        table.parentElement.removeChild(table);
    }
    document.getElementById("tables").appendChild(newTable);
}
function removeDowntimeTable(i) {
    let index = tableArr.findIndex(e => e.head === i);
    if (index >= 0) {
        tableArr.splice(index, 1);
    }
    
}

function debug() {
    console.log(document.getElementById("resources"));
    console.log(document.getElementById("resolutions"));
    console.log(document.getElementById("tables"));
    console.log(resourceArr);
    console.log(resolutionArr);
    console.log(tableArr);
}
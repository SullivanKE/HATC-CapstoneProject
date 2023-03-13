// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addResourceTable() {
    let i = tableCount;
    let newTable = document.getElementById("hiddenResourcesTable").cloneNode(true);
    newTable.id = "resourceTable" + i;
    newTable.removeAttribute("hidden");

    newTable.childNodes[3].onclick = function () { // Delete table
        let table = document.getElementById("resourceTable" + i);
        table.parentElement.removeChild(table);
    }
    console.log(document.getElementById("resources"));
    document.getElementById("resources").appendChild(newTable);
    resourceCount++;
}

function addResolutionTable() {
    let i = tableCount;
    let newTable = document.getElementById("hiddenResolutionsTable").cloneNode(true);
    newTable.id = "resolutionTable" + i;
    newTable.removeAttribute("hidden");

    newTable.childNodes[3].onclick = function () { // Delete table
        let table = document.getElementById("resolutionTable" + i);
        table.parentElement.removeChild(table);
    }
    console.log(document.getElementById("resolutions"));
    document.getElementById("resolutions").appendChild(newTable);
    resolutionCount++;
}

function addDowntimeTable() {
    let i = tableCount;
    let newTable = document.getElementById("hiddenTablesTable").cloneNode(true);
    newTable.id = "downtimeTable" + i;
    newTable.removeAttribute("hidden");

    newTable.childNodes[5].onclick = function () { // Delete table
        let table = document.getElementById("downtimeTable" + i);
        table.parentElement.removeChild(table);
    }
    document.getElementById("tables").appendChild(newTable);
    tableCount++;
}

function debug() {
    console.log(document.getElementById("resources"));
    console.log(document.getElementById("resolutions"));
    console.log(document.getElementById("tables"));
}

function initialize() {
    students[0] = new Student("Lucy Pevensie", "A+");
    students[1] = new Student("Jill Pole", "A");
    students[2] = new Student("Eustace Scrubb", "A-");
    addRows();
}

// Add rows to the table with content from the students array
function addRows() {
    for (let i = 0; i < students.length; i++) {
        addRow(i);
    }
}

// Add a row to the table
function addRow(i) {
    let newRow = document.getElementById("hiddenRow").cloneNode(true);
    newRow.id = "row" + i; // tr
    newRow.removeAttribute("hidden"); // tr
    newRow.childNodes[1].innerHTML = students[i].name; // Student name
    newRow.childNodes[5].innerHTML = students[i].grade; // grade
    newRow.childNodes[3].firstChild.onclick = function () { // delete button
        removeStudent(i);
        let row = document.getElementById("row" + i);
        row.parentElement.removeChild(row);
    };
    newRow.childNodes[7].lastChild.onclick = function () { // enter button
        let rowElements = document.getElementById("row" + i).childNodes;
        changeGrade(students[i].name, rowElements[7].firstChild.value);
        rowElements[5].innerHTML = students[i].grade;
    };
    document.getElementById("gradeBookRows").appendChild(newRow);
}

function addRowAndStudent() {
    let name = document.getElementById("studentName").value;
    addStudent(name);
    addRow(students.length - 1);
}
var SelectedRow = "";

function highlight(row) {
    SelectedRow = row.cells[0].textContent;
    deHighlight();
    row.style.backgroundColor = '#d5dec8';
    row.classList.toggle("selectedRow");
}

function deHighlight() {
    let table = document.getElementById("mytable");
    let rows = table.rows;
    for (let i = 0; i < rows.length; i++) {
        rows[i].style.backgroundColor = "transparent";
    }
}


function getSelectedRow() {
    alert(SelectedRow);
}
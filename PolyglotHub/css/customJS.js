document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("addButton").addEventListener("click", function () {

        var rowDiv = document.createElement("div");
        rowDiv.classList.add("row");

        var colDiv = document.createElement("div");
        colDiv.classList.add("col-sm-6");

        var formGroupDiv = document.createElement("div");
        formGroupDiv.classList.add("form-group");

        var label = document.createElement("label");
        label.innerHTML = "Level";

        var input = document.createElement("input");
        input.type = "text";
        input.classList.add("form-control");
        input.placeholder = "Input Number";

        formGroupDiv.appendChild(label);
        formGroupDiv.appendChild(input);

        colDiv.appendChild(formGroupDiv);

        rowDiv.appendChild(colDiv);

    });
});
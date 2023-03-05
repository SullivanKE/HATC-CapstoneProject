// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addCharacter() {
    var container = document.getElementById("character-container");

    // create a new div for the character
    var characterDiv = document.createElement("div");
    characterDiv.classList.add("character");

    // create the user dropdown list
    var userSelect = document.createElement("select");
    userSelect.name = "users";
    userSelect.classList.add("form-control");
    // populate the user dropdown list with data from the server
    // this assumes you have a route in your ASP.NET app to retrieve the user data
    fetch("/users")
        .then(response => response.json())
        .then(users => {
            for (var i = 0; i < users.length; i++) {
                var option = document.createElement("option");
                option.value = users[i].id;
                option.text = users[i].name;
                userSelect.appendChild(option);
            }
        })
        .catch(error => console.log(error));

    // create the character dropdown list
    var characterSelect = document.createElement("select");
    characterSelect.name = "characters";
    characterSelect.classList.add("form-control");

    // add the user dropdown and character dropdown to the character div
    characterDiv.appendChild(userSelect);
    characterDiv.appendChild(characterSelect);

    // create a remove button for the character div
    var removeButton = document.createElement("button");
    removeButton.textContent = "Remove Character";
    removeButton.classList.add("btn", "btn-danger");
    removeButton.addEventListener("click", function () {
        container.removeChild(characterDiv);
    });

    // add the remove button to the character div
    characterDiv.appendChild(removeButton);

    // add the character div to the container
    container.appendChild(characterDiv);
}
let head2 = document.querySelector("h2")
let button = document.querySelector("button")


function changeH2() {
    head2.textContent = "You clicked the button."
}

button.addEventListener("click", changeH2)
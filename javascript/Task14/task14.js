let listcontainer = document.getElementById("list_container")
let input = document.querySelector("input")
let btn = document.querySelector("button")

function additem() {
    let newItem = document.createElement('li')
    let textItem = input.value
    newItem.textContent = textItem;
    listcontainer.appendChild(newItem)
    input.value = ""
}

btn.addEventListener("click", additem)


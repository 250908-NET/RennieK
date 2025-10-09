const RedBtn = document.getElementById("red")
const NormalBtn = document.getElementById("normal")
const paragraph = document.getElementById("text");
paragraph.style.color = "blue";
paragraph.style.fontSize = "24px";

function changeBtn() {
    paragraph.style.color = "red";
    paragraph.style.fontWeight = "bold";
}

function changeBack() {
    paragraph.style.color = "blue";
    paragraph.style.fontWeight = "";
}

RedBtn.addEventListener("click", changeBtn)
NormalBtn.addEventListener("click", changeBack)
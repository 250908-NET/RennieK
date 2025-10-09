function greetUser() {
    let name = document.getElementById("nameInput").value;
    let color = document.getElementById("color").value;
    let colorString = "";
    if (color.length > 0) {
        colorString = ` Your favorite ${color} is lame`;
    }
    if (name.trim() === "") {
        alert("Please enter your name first!");
    } else {
        alert("Hello, " + name + "!" + colorString);
    }
}

document.getElementById("greetBtn").addEventListener("click", greetUser);
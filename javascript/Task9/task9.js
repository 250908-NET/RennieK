function sayHello() {
    alert("Hello from the external file!");
}

function sayGoodby() {
    alert("GoodBye")
}

// Connect the function to the button
let btn = document.getElementById("helloBtn");
let sayGoodByeButton = document.getElementById("goodbyebutton")
btn.addEventListener("click", sayHello);
sayGoodByeButton.addEventListener("click", sayGoodby)

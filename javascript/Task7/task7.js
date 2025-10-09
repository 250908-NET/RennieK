function square() {
    const number = document.getElementById("mainInput").value
    console.log(number)

    return number * number;
}

function alertSquare() {
    alert(`the square is ${square()}`);
    document.getElementById("mainInput").value = null;
}
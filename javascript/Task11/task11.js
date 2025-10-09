function addNumbers() {
    let n1 = Number(document.getElementById("num1").value);
    let n2 = Number(document.getElementById("num2").value);
    let sum = n1 + n2;

    document.getElementById("result").textContent = "Result: " + sum;
}
function subNumber() {
    let n1 = Number(document.getElementById("num1").value);
    let n2 = Number(document.getElementById("num2").value);
    let sum = n1 - n2;

    document.getElementById("result").textContent = "Result: " + sum;
}

function mulNumber() {
    let n1 = Number(document.getElementById("num1").value);
    let n2 = Number(document.getElementById("num2").value);
    let sum = n1 * n2;

    document.getElementById("result").textContent = "Result: " + sum;
}

function divNumber() {
    let n1 = Number(document.getElementById("num1").value);
    let n2 = Number(document.getElementById("num2").value);
    let sum = n1 / n2;

    document.getElementById("result").textContent = "Result: " + sum;
}



document.getElementById("addBtn").addEventListener("click", addNumbers);
document.getElementById("subBtn").addEventListener("click", subNumber);
document.getElementById("divBtn").addEventListener("click", divNumber);
document.getElementById("mulBtn").addEventListener("click", mulNumber);
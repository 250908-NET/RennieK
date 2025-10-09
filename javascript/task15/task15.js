let btn = document.querySelector("button")
let image = document.querySelector("img")

function changePicture() {
    if (image.alt == "cat") {
        image.alt = "dog"
        image.src = "dog.jpg"
    }
    else if (image.alt == "dog") {
        image.src = "cat.avif"
        image.alt = "cat"
    }

}

btn.addEventListener("click", changePicture)
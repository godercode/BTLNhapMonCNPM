const files = document.getElementById("files")

const imageSection = document.getElementById("imageSection")

const submitButton = document.getElementById("submit")

imageSection.addEventListener("click", () => {
    files.click()
})

const images = [...document.getElementsByClassName("image")]?.map(
    (imageTag) => {
        const imageId = imageTag.id?.split("-")[1]
        return `${imageTag.src} ${imageId}`
    }
)

console.log("images:", images)

files.addEventListener("change", async (event) => {
    const files = [...event?.target?.files]

    const formData = new FormData()

    files.forEach((file) => {
        formData.append("files", file)
    })

    const res = await fetch("/Drink/Upload", {
        method: "POST",
        body: formData,
        headers: {
            Accept: "*/*",
        },
    })

    const { message, url } = await res.json()

    if (message === "uploaded successfully") {
        alert("Image uploaded successfully!")
        const div = document.createElement("div")
        const img = document.createElement("img")
        img.src = url
        images.push(url)
        console.log(images, "image")
        img.className = "w-20 h-20"
        div.appendChild(img)
        const addImage = document.getElementById("imageSection")
        addImage.insertAdjacentElement("afterbegin", div)
    } else {
        alert("Failed to upload image.")
    }
})

files.addEventListener("click", (event) => {
    event.target.value = null
})

submitButton.addEventListener("click", async () => {
    const formData = new FormData()

    images.forEach((image) => {
        formData.append("images", image)
    })

    formData.append("id", document.getElementById("drinkId").value)
    formData.append("name", document.getElementById("name").value)
    formData.append("price", document.getElementById("price").value)
    formData.append(
        "comparePrice",
        document.getElementById("comparePrice").value
    )
    formData.append("description", document.getElementById("description").value)
    formData.append("categoryId", document.getElementById("categoryId").value)

    const res = await fetch("/Drink/Edit", {
        method: "POST",
        body: formData,
        headers: {
            Accept: "*/*",
        },
    })

    const { message } = await res.json()

    if (message === "updated successfully") {
        alert(message)
        window.location.href = "/Drink"
        return
    }

    alert(message)
})

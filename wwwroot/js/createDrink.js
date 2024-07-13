const files = document.getElementById("files")

const imageSection = document.getElementById("imageSection")

const images = []

const submitButton = document.getElementById("submit")

imageSection.addEventListener("click", () => {
  files.click()
})

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
    img.className = "w-20 h-20"
    div.appendChild(img)
    const addImage = document.getElementById("imageSection")
    addImage.insertAdjacentElement("afterbegin", div)
    console.log(images, "image")
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

  formData.append("name", document.getElementById("name").value)

  formData.append("price", document.getElementById("price").value)
  formData.append("comparePrice", document.getElementById("comparePrice").value)
  formData.append("description", document.getElementById("description").value)

  const res = await fetch("/Drink/Create", {
    method: "POST",
    body: formData,
    headers: {
      Accept: "*/*",
    },
  })

  const { message } = await res.json()

  if (message === "created successfully") {
    window.location.href = "/Drink"
    return
  }

  alert(message)
})

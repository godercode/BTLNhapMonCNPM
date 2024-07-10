const files = document.getElementById("files")

const imageSection = document.getElementById("imageSection")

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

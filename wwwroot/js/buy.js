async function handleBuyNow(itemId, quantity) {
  const formData = new FormData()

  formData.append("id", itemId)

  formData.append("quantity", quantity)

  const res = await fetch("/Buy/BuyNow", {
    method: "POST",
    body: formData,
    headers: {
      Accept: "*/*",
    },
  })

  const { message, billId } = await res.json()

  if (message === "purchased successfully") {
    window.location.href = `/Bill/Detail/${billId}`
    return
  }

  alert("Mua Thất bại")
}

function handleQuantityChanged(
  itemId,
  quantity,
  defaultPrice,
  defaultComparedPrice
) {
  const itemPriceContainer = document.getElementById(`price-${itemId}`)

  const comparedPriceContainer = document.getElementById(
    `comparedPrice-${itemId}`
  )

  itemPriceContainer.innerText = `${+defaultPrice * +quantity} đ`
  comparedPriceContainer.innerText = `${defaultComparedPrice * +quantity} đ`
}

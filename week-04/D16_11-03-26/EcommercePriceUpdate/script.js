const prices = [1200, 800, 1500, 2000];

// Apply 10% discount
const discountedPrices = prices.map(price => price * 0.9);

console.log(discountedPrices);

// Show result on webpage
document.getElementById("result").innerText = discountedPrices;
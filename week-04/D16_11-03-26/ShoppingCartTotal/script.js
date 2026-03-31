const cart = [500, 1200, 800, 1500];

// Calculate total price
const total = cart.reduce((sum, price) => sum + price, 0);

console.log(total);

// Show result on webpage
document.getElementById("result").innerText = total;
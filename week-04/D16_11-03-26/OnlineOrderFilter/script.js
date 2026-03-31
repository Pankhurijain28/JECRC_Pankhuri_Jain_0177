const orders = [450, 1200, 700, 3000, 1500];

// Filter orders greater than 1000
const bigOrders = orders.filter(order => order > 1000);

console.log(bigOrders);

// Show result on webpage
document.getElementById("result").innerText = bigOrders;
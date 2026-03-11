const marks = [65, 70, 80, 55, 90];

// Add 5 bonus marks
const updatedMarks = marks.map(mark => mark + 5);

// Display result in console
console.log(updatedMarks);

// Display result on webpage
document.getElementById("result").innerText = updatedMarks;
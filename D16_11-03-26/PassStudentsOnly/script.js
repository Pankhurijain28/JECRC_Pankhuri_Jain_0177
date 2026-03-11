const marks = [35, 67, 48, 90, 55, 30];

// Filter students who passed
const passedStudents = marks.filter(mark => mark > 50);

console.log(passedStudents);

// Display on webpage
document.getElementById("result").innerText = passedStudents;
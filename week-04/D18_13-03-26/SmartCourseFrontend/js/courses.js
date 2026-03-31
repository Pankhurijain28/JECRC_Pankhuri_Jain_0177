let courseList=[];

async function loadCourses(){

const res=await fetch(API_BASE+"/courses");

courseList=await res.json();

displayCourses(courseList);

}

function displayCourses(list){

let html="";

list.forEach(c=>{

html+=`
<div class="card">

<h3>${c.courseName}</h3>

<p><b>Department:</b> ${c.department}</p>
<p><b>Credits:</b> ${c.credits}</p>
<p><b>Seats:</b> ${c.seatsAvailable}</p>

<button onclick="enroll(${c.courseId})">
Enroll
</button>

</div>
`;

});

document.getElementById("courses").innerHTML=html;

}

function searchCourses(){

const keyword=document.getElementById("search").value.toLowerCase();

const filtered=courseList.filter(c=>
c.courseName.toLowerCase().includes(keyword) ||
c.department.toLowerCase().includes(keyword)
);

displayCourses(filtered);

}

async function enroll(courseId){

const token=localStorage.getItem("token");

await fetch(API_BASE+`/enrollment/enroll?courseId=${courseId}&studentId=2`,{
method:"POST",
headers:{
Authorization:"Bearer "+token
}
});

alert("Enrollment successful");

}

loadCourses();
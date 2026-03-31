async function loadMyCourses(){

const token=localStorage.getItem("token");

const res=await fetch(API_BASE+"/enrollment/student/2",{
headers:{
Authorization:"Bearer "+token
}
});

const data=await res.json();

let html="";

data.forEach(e=>{

html+=`
<div class="card">

<h3>Course ID: ${e.courseId}</h3>

<p>Date: ${e.enrollmentDate}</p>

<button onclick="drop(${e.courseId})">
Drop Course
</button>

</div>
`;

});

document.getElementById("mycourses").innerHTML=html;

}

async function drop(courseId){

const token=localStorage.getItem("token");

await fetch(API_BASE+`/enrollment/drop?courseId=${courseId}&studentId=2`,{
method:"DELETE",
headers:{
Authorization:"Bearer "+token
}
});

loadMyCourses();

}

loadMyCourses();
async function login(){

const email=document.getElementById("email").value;
const password=document.getElementById("password").value;

const res=await fetch(API_BASE+"/auth/login",{
method:"POST",
headers:{
"Content-Type":"application/json"
},
body:JSON.stringify({email,password})
});

const data=await res.json();

localStorage.setItem("token",data.token);
localStorage.setItem("role",data.role);

window.location="dashboard.html";

}
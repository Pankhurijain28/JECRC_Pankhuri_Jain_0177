import { useState } from "react";
import { useNavigate } from "react-router-dom";

function Register() {
  const [form, setForm] = useState({ email: "", password: "" });
  const navigate = useNavigate();

  const register = () => {
    localStorage.setItem("user", JSON.stringify(form));
    alert("Registered!");
    navigate("/login");
  };

  return (
    <div className="auth-card">
      <h2>Register</h2>

      <input placeholder="Email" onChange={(e)=>setForm({...form,email:e.target.value})}/>
      <input type="password" placeholder="Password" onChange={(e)=>setForm({...form,password:e.target.value})}/>

      <button onClick={register}>Register</button>
    </div>
  );
}

export default Register;
import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";

function Login() {
  const [form, setForm] = useState({ email: "", password: "" });
  const navigate = useNavigate();

  const login = () => {
    const user = JSON.parse(localStorage.getItem("user"));

    if (!user) return alert("Please register first");

    if (user.email === form.email && user.password === form.password) {
      localStorage.setItem("auth", "true");
      navigate("/dashboard");
    } else {
      alert("Invalid credentials");
    }
  };

  return (
    <div className="auth-card">
      <h2>Login</h2>

      <input placeholder="Email" onChange={(e)=>setForm({...form,email:e.target.value})}/>
      <input type="password" placeholder="Password" onChange={(e)=>setForm({...form,password:e.target.value})}/>

      <button onClick={login}>Login</button>

      <p>Don't have account? <Link to="/register">Register</Link></p>
    </div>
  );
}

export default Login;
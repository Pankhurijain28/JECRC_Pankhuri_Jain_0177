import React, { useState, useContext } from "react";
import { AuthContext } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";
import "./Login.css";

const Login = () => {
  const { login } = useContext(AuthContext);
  const navigate = useNavigate();

  const [form, setForm] = useState({ email: "", password: "" });
  const [error, setError] = useState("");

  const handleLogin = () => {
    if (!form.email || !form.password) {
      setError("All fields required");
      return;
    }

    const success = login(form.email, form.password);

    if (!success) {
      setError("Invalid credentials");
    } else {
      if (form.email.includes("admin"))
        navigate("/admin");
      else navigate("/employee");
    }
  };

  return (
    <div className="login-container">
      <div className="login-box">
        <h2>Employee Portal</h2>

       <div className="input-group">
  <label>Email</label>
  <input
    type="email"
    onChange={(e) => setForm({ ...form, email: e.target.value })}
  />
</div>

<div className="input-group">
  <label>Password</label>
  <input
    type="password"
    onChange={(e) => setForm({ ...form, password: e.target.value })}
  />
</div>

        {error && <p className="error">{error}</p>}

        <button onClick={handleLogin}>Login</button>
      </div>
    </div>
  );
};

export default Login;
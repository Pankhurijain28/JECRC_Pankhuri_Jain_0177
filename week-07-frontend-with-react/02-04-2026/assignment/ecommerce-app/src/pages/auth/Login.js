import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { FaEnvelope, FaLock, FaEye, FaEyeSlash } from "react-icons/fa";

function Login() {
  const [form, setForm] = useState({ email: "", password: "" });
  const [show, setShow] = useState(false);
  const navigate = useNavigate();

  const login = () => {
    const user = JSON.parse(localStorage.getItem("user"));

    if (!user) {
      alert("Please register first");
      return;
    }

    if (user.email === form.email && user.password === form.password) {
      localStorage.setItem("auth", "true");
      navigate("/dashboard");
    } else {
      alert("Invalid credentials");
    }
  };

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Welcome Back 👋</h2>

        {/* EMAIL */}
        <div className="input-group">
          <FaEnvelope className="input-icon" />
          <input
            type="email"
            placeholder="Enter email"
            onChange={(e) =>
              setForm({ ...form, email: e.target.value })
            }
          />
        </div>

        {/* PASSWORD */}
        <div className="input-group">
          <FaLock className="input-icon" />
          <input
            type={show ? "text" : "password"}
            placeholder="Enter password"
            onChange={(e) =>
              setForm({ ...form, password: e.target.value })
            }
          />

          <span
            className="toggle-icon"
            onClick={() => setShow(!show)}
          >
            {show ? <FaEyeSlash /> : <FaEye />}
          </span>
        </div>

        <button className="auth-btn" onClick={login}>
          Login
        </button>

        <Link to="/register" className="auth-link">
          Don’t have an account? Register
        </Link>
      </div>
    </div>
  );
}

export default Login;
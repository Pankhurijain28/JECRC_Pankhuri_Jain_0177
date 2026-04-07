import { useState } from "react";
import { useAuth } from "../hooks/useAuth";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const { login } = useAuth();
  const nav = useNavigate();

  const [form, setForm] = useState({ u: "", p: "" });

  const handle = () => {
    if (form.u === "admin" && form.p === "123") {
      login({ name: "Admin" });
      nav("/dashboard");
    } else alert("Wrong credentials");
  };

  return (
    <div className="text-center mt-5">
      <input placeholder="username" onChange={(e)=>setForm({...form,u:e.target.value})} />
      <br/>
      <input type="password" placeholder="password" onChange={(e)=>setForm({...form,p:e.target.value})}/>
      <br/>
      <button className="btn btn-primary mt-2" onClick={handle}>Login</button>
    </div>
  );
}
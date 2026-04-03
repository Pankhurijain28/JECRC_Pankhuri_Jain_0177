import React, { useContext } from "react";
import { AuthContext } from "../../context/AuthContext";
import { ThemeContext } from "../../context/ThemeContext";

const Navbar = () => {
  const { logout } = useContext(AuthContext);
  const { dark, setDark } = useContext(ThemeContext);

  return (
    <div style={{ padding: "10px", background: "#667eea", color: "white" }}>
      <button onClick={()=>setDark(!dark)}>
        {dark ? "Light" : "Dark"}
      </button>

      <button onClick={logout}>Logout</button>
    </div>
  );
};

export default Navbar;
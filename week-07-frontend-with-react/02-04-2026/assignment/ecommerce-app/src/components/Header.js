import { NavLink, useNavigate } from "react-router-dom";
import { FaShoppingCart, FaUser } from "react-icons/fa";

function Header() {
  const navigate = useNavigate(); // ✅ FIXED

  const logout = () => {
    localStorage.removeItem("auth");
    navigate("/login");
  };

  return (
    <header className="header">
      <h2>🛒 ShopPro</h2>

      <nav>
        <NavLink to="/">Home</NavLink>
        <NavLink to="/products">Products</NavLink>
        <NavLink to="/dashboard">Dashboard</NavLink>
      </nav>

      <div className="header-right">
        <FaShoppingCart />
        <FaUser />

        <button onClick={() => navigate("/login")}>Login</button>
        <button onClick={() => navigate("/register")}>Register</button>
        <button onClick={logout}>Logout</button>
      </div>
    </header>
  );
}

export default Header; // ✅ VERY IMPORTANT
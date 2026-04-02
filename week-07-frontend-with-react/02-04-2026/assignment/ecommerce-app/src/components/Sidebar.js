import { NavLink } from "react-router-dom";
import { FaHome, FaBox, FaInfoCircle } from "react-icons/fa";

function Sidebar() {
  return (
    <div className="sidebar">
      <NavLink to="/"><FaHome /> Home</NavLink>
      <NavLink to="/about"><FaInfoCircle /> About</NavLink>
      <NavLink to="/contact"><FaInfoCircle /> Contact</NavLink>
      <NavLink to="/products"><FaBox /> Products</NavLink>
    </div>
  );
}

export default Sidebar;
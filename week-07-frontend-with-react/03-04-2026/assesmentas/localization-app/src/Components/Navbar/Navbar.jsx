import React, { useContext } from "react";
import { LanguageContext } from "../../context/LanguageContext";
import { Link } from "react-router-dom";
import LanguageSwitcher from "../LanguageSwitcher/LanguageSwitcher";
import "./Navbar.css";

const Navbar = () => {
  const { t } = useContext(LanguageContext);

  return (
    <nav className="navbar">
      <h2 className="logo">🌍 LocalApp</h2>

      <div className="nav-links">
        <Link to="/">{t.home}</Link>
        <Link to="/about">{t.about}</Link>
      </div>

      <LanguageSwitcher />
    </nav>
  );
};

export default Navbar;
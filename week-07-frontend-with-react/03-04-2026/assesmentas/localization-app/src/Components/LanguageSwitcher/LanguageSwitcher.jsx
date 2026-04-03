import React, { useContext, useState } from "react";
import { LanguageContext } from "../../context/LanguageContext";
import "./LanguageSwitcher.css";

const languages = [
  { code: "en", label: "English 🇺🇸" },
  { code: "hi", label: "हिन्दी 🇮🇳" },
  { code: "fr", label: "Français 🇫🇷" },
  { code: "es", label: "Español 🇪🇸" },
];

const LanguageSwitcher = () => {
  const { changeLanguage, language } = useContext(LanguageContext);
  const [open, setOpen] = useState(false);

  return (
    <div className="dropdown">
      <button className="dropdown-btn" onClick={() => setOpen(!open)}>
        🌐 {languages.find(l => l.code === language)?.label}
      </button>

      {open && (
        <div className="dropdown-menu">
          {languages.map((lang) => (
            <div
              key={lang.code}
              className="dropdown-item"
              onClick={() => {
                changeLanguage(lang.code);
                setOpen(false);
              }}
            >
              {lang.label}
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default LanguageSwitcher;
import React, { createContext, useState, useEffect } from "react";
import en from "../translations/en";
import hi from "../translations/hi";
import fr from "../translations/fr";
import es from "../translations/es";

export const LanguageContext = createContext();

const translations = { en, hi, fr, es };

export const LanguageProvider = ({ children }) => {
  const [language, setLanguage] = useState("en");

  useEffect(() => {
    const savedLang = localStorage.getItem("lang");
    if (savedLang && translations[savedLang]) {
      setLanguage(savedLang);
    }
  }, []);

  const changeLanguage = (lang) => {
    setLanguage(lang);
    localStorage.setItem("lang", lang);
  };

  return (
    <LanguageContext.Provider
      value={{
        language,
        changeLanguage,
        t: translations[language],
      }}
    >
      {children}
    </LanguageContext.Provider>
  );
};
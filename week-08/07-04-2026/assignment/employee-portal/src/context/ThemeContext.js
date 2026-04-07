import { createContext, useState, useEffect } from "react";

export const ThemeContext = createContext();

export const ThemeProvider = ({ children }) => {
  const [dark, setDark] = useState(() => {
    return localStorage.getItem("theme") === "true";
  });

  useEffect(() => {
    document.body.style.background = dark ? "#121212" : "#f4f6f9";
    document.body.style.color = dark ? "white" : "black";

    localStorage.setItem("theme", dark);
  }, [dark]);

  return (
    <ThemeContext.Provider value={{ dark, toggle: () => setDark(!dark) }}>
      {children}
    </ThemeContext.Provider>
  );
};
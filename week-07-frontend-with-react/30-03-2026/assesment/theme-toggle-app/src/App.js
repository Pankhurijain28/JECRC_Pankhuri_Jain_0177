import React, { useState } from "react";
import "./App.css";

function App() {
  const [isDark, setIsDark] = useState(false);

  const toggleTheme = () => {
    setIsDark(!isDark);
  };

  return (
    <div className={isDark ? "container dark" : "container light"}>
      <div className="card">
        <h1>{isDark ? "Dark Mode" : " Light Mode"}</h1>

        <button onClick={toggleTheme}>
          Switch to {isDark ? "Light" : "Dark"} Mode
        </button>
      </div>
    </div>
  );
}

export default App;
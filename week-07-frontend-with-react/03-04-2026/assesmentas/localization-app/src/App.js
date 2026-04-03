import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { LanguageProvider } from "./context/LanguageContext";

import Navbar from "./Components/Navbar/Navbar";
import Home from "./pages/Home/Home";
import About from "./pages/About/About";

import "./App.css";

function App() {
  return (
    <LanguageProvider>
      <Router>
        <Navbar />

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
        </Routes>
      </Router>
    </LanguageProvider>
  );
}

export default App;
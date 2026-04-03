import React, { useContext } from "react";
import { LanguageContext } from "../../context/LanguageContext";
import "./Home.css";

const Home = () => {
  const { t } = useContext(LanguageContext);

  return (
    <div className="home">
      <h1>{t.welcome}</h1>
      <p>{t.description}</p>
    </div>
  );
};

export default Home;
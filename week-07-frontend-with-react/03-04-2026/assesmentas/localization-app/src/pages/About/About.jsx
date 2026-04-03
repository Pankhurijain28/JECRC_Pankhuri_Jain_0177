import React, { useContext } from "react";
import { LanguageContext } from "../../context/LanguageContext";
import "./About.css";

const About = () => {
  const { t } = useContext(LanguageContext);

  return (
    <div className="about">
      <h1>{t.about}</h1>
      <p>{t.description}</p>
    </div>
  );
};

export default About;
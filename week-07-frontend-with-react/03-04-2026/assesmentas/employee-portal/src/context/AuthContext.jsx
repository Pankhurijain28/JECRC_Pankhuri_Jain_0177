import React, { createContext, useState } from "react";

export const AuthContext = createContext();

const users = [
  {
    id: 1,
    name: "Admin User",
    email: "admin@test.com",
    password: "1234",
    role: "admin",
  },
  {
    id: 2,
    name: "Pankhuri Jain",
    email: "emp@test.com",
    password: "1234",
    role: "employee",
  },
  {
    id: 3,
    name: "Rahul Sharma",
    email: "rahul@test.com",
    password: "1234",
    role: "employee",
  },
];

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(
    JSON.parse(localStorage.getItem("user")) || null
  );

  const login = (email, password) => {
    const foundUser = users.find(
      (u) => u.email === email && u.password === password
    );

    if (foundUser) {
      setUser(foundUser);
      localStorage.setItem("user", JSON.stringify(foundUser));
      return true;
    }
    return false;
  };

  const logout = () => {
    setUser(null);
    localStorage.removeItem("user");
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
import React, { createContext, useState } from "react";
import { v4 as uuidv4 } from "uuid";

export const EmployeeContext = createContext();

export const EmployeeProvider = ({ children }) => {
  const [employees, setEmployees] = useState([
  {
    id: "1",
    name: "Pankhuri Jain",
    email: "emp@test.com",
    department: "IT",
    role: "employee",
  },
  {
    id: "2",
    name: "Rahul Sharma",
    email: "rahul@test.com",
    department: "HR",
    role: "employee",
  },
]);

  const addEmployee = (emp) => {
    setEmployees([...employees, { ...emp, id: uuidv4() }]);
  };

  const updateEmployee = (updatedEmp) => {
    setEmployees(
      employees.map((emp) =>
        emp.id === updatedEmp.id ? updatedEmp : emp
      )
    );
  };

  const deleteEmployee = (id) => {
    setEmployees(employees.filter((emp) => emp.id !== id));
  };

  return (
    <EmployeeContext.Provider
      value={{ employees, addEmployee, updateEmployee, deleteEmployee }}
    >
      {children}
    </EmployeeContext.Provider>
  );
};
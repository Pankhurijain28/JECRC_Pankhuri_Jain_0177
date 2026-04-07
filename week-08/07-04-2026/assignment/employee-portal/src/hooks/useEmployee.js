// useEmployee.js
import { useContext } from "react";
import { EmployeeContext } from "../context/EmployeeContext";
export const useEmployee = () => useContext(EmployeeContext);
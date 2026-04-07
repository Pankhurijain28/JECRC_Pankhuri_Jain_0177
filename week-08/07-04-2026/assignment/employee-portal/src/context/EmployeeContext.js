import { createContext, useReducer, useEffect } from "react";

export const EmployeeContext = createContext();

const defaultData = [
  { id: 1, name: "Rahul" },
  { id: 2, name: "Priya" },
];

const reducer = (state, action) => {
  switch (action.type) {
    case "ADD":
      return [...state, action.payload];
    case "DELETE":
      return state.filter((e) => e.id !== action.payload);
    default:
      return state;
  }
};

export const EmployeeProvider = ({ children }) => {
  const [employees, dispatch] = useReducer(
    reducer,
    JSON.parse(localStorage.getItem("employees")) || defaultData
  );

  useEffect(() => {
    localStorage.setItem("employees", JSON.stringify(employees));
  }, [employees]);

  return (
    <EmployeeContext.Provider
      value={{
        employees,
        add: (e) => dispatch({ type: "ADD", payload: e }),
        remove: (id) => dispatch({ type: "DELETE", payload: id }),
      }}
    >
      {children}
    </EmployeeContext.Provider>
  );
};
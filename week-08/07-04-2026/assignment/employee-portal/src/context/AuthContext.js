import { createContext, useReducer, useEffect } from "react";

export const AuthContext = createContext();

const reducer = (state, action) => {
  switch (action.type) {
    case "LOGIN":
      return { user: action.payload, isAuthenticated: true };
    case "LOGOUT":
      return { user: null, isAuthenticated: false };
    default:
      return state;
  }
};

export const AuthProvider = ({ children }) => {
  const [state, dispatch] = useReducer(
    reducer,
    JSON.parse(localStorage.getItem("auth")) || {
      user: null,
      isAuthenticated: false,
    }
  );

  useEffect(() => {
    localStorage.setItem("auth", JSON.stringify(state));
  }, [state]);

  return (
    <AuthContext.Provider
      value={{
        ...state,
        login: (user) => dispatch({ type: "LOGIN", payload: user }),
        logout: () => dispatch({ type: "LOGOUT" }),
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
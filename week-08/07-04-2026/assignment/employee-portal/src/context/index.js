import { AuthProvider } from "./AuthContext";
import { ThemeProvider } from "./ThemeContext";
import { EmployeeProvider } from "./EmployeeContext";

export const AppProviders = ({ children }) => (
  <AuthProvider>
    <ThemeProvider>
      <EmployeeProvider>{children}</EmployeeProvider>
    </ThemeProvider>
  </AuthProvider>
);
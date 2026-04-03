import { BrowserRouter, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import { EmployeeProvider } from "./context/EmployeeContext";
import { ThemeProvider } from "./context/ThemeContext";
import { ToastContainer } from "react-toastify";

import Login from "./pages/Login/Login";
import AdminDashboard from "./pages/AdminDashboard/AdminDashboard";
import EmployeeDashboard from "./pages/EmployeeDashboard/EmployeeDashboard";
import ProtectedRoute from "./components/ProtectedRoute";

function App() {
  return (
    <ThemeProvider>
      <AuthProvider>
        <EmployeeProvider>
          <BrowserRouter>
            <ToastContainer />

            <Routes>
              <Route path="/" element={<Login />} />

              <Route
                path="/admin"
                element={
                  <ProtectedRoute role="admin">
                    <AdminDashboard />
                  </ProtectedRoute>
                }
              />

              <Route
                path="/employee"
                element={
                  <ProtectedRoute role="employee">
                    <EmployeeDashboard />
                  </ProtectedRoute>
                }
              />
            </Routes>
          </BrowserRouter>
        </EmployeeProvider>
      </AuthProvider>
    </ThemeProvider>
  );
}

export default App;
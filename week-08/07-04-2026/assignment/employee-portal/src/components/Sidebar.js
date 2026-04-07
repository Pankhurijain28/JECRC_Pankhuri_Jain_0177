import { Link } from "react-router-dom";

export default function Sidebar() {
  return (
    <div className="bg-dark text-white p-3 vh-100" style={{ width: "200px" }}>
      <Link to="/dashboard" className="d-block text-white mb-2">Dashboard</Link>
      <Link to="/employees" className="d-block text-white mb-2">Employees</Link>
      <Link to="/analytics" className="d-block text-white mb-2">Analytics</Link>
      <Link to="/settings" className="d-block text-white">Settings</Link>
    </div>
  );
}
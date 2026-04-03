import { Outlet, NavLink } from "react-router-dom";

function DashboardLayout() {
  return (
    <div className="dashboard-container">

      <h2 className="dashboard-title">📊 Dashboard</h2>

      <div className="dashboard-nav">
        <NavLink to="/dashboard">Home</NavLink>
        <NavLink to="/dashboard/analytics">Analytics</NavLink>
        <NavLink to="/dashboard/settings">Settings</NavLink>
      </div>

      <Outlet />
    </div>
  );
}

export default DashboardLayout;
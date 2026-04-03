import React, { useContext, useState } from "react";
import { EmployeeContext } from "../../context/EmployeeContext";
import EmployeeCard from "../../components/EmployeeCard/EmployeeCard";
import EmployeeForm from "../../components/EmployeeForm/EmployeeForm";
import "./AdminDashboard.css";

const AdminDashboard = () => {
  const { employees } = useContext(EmployeeContext);
  const [search, setSearch] = useState("");

  const filtered = employees.filter((e) =>
    e.name.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className="dashboard">
      <h1>👩‍💼 Admin Dashboard</h1>

      {/* Stats */}
      <div className="stats">
        <div className="stat-card">
          <h3>Total Employees</h3>
          <p>{employees.length}</p>
        </div>
        <div className="stat-card">
          <h3>Departments</h3>
          <p>IT</p>
        </div>
      </div>

      {/* Search */}
      <input
        className="search"
        placeholder="🔍 Search employee..."
        onChange={(e) => setSearch(e.target.value)}
      />

      {/* Form */}
      <EmployeeForm />

      {/* Employee Grid */}
      <div className="grid">
        {filtered.map((emp) => (
          <EmployeeCard key={emp.id} emp={emp} />
        ))}
      </div>
    </div>
  );
};

export default AdminDashboard;
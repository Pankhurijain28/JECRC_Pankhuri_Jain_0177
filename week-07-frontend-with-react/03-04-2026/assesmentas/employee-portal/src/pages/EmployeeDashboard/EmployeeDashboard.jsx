import React, { useContext } from "react";
import { AuthContext } from "../../context/AuthContext";
import { EmployeeContext } from "../../context/EmployeeContext";
import "./EmployeeDashboard.css";

const EmployeeDashboard = () => {
  const { user } = useContext(AuthContext);
  const { employees } = useContext(EmployeeContext);

  const myData = employees.find((e) => e.email === user.email);

  return (
    <div className="profile-container">
      <div className="profile-card">

        {/* Header */}
        <div className="profile-header">
          <div className="avatar">
            {myData?.name?.charAt(0)}
          </div>
          <h2>{myData?.name}</h2>
          <p>{myData?.email}</p>
        </div>

        {/* Details */}
        <div className="profile-body">
          <div className="info">
            <span>Department</span>
            <p>{myData?.department}</p>
          </div>

          <div className="info">
            <span>Role</span>
            <p>{myData?.role || "Employee"}</p>
          </div>
        </div>

      </div>
    </div>
  );
};

export default EmployeeDashboard;
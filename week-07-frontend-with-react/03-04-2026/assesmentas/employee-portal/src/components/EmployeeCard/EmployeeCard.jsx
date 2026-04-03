import React, { useContext, useState } from "react";
import { EmployeeContext } from "../../context/EmployeeContext";
import { toast } from "react-toastify";
import "./EmployeeCard.css";

const EmployeeCard = ({ emp }) => {
  const { deleteEmployee } = useContext(EmployeeContext);
  const [confirm, setConfirm] = useState(false);

  const handleDelete = () => {
    deleteEmployee(emp.id);
    toast.success("Employee deleted");
  };

  return (
    <div className="employee-card">
      <div className="avatar">
        {emp.name.charAt(0)}
      </div>

      <h3>{emp.name}</h3>
      <p>{emp.email}</p>
      <span className="dept">{emp.department}</span>

      <button className="delete-btn" onClick={() => setConfirm(true)}>
        Delete
      </button>

      {confirm && (
        <div className="confirm-box">
          <p>Delete this employee?</p>
          <button onClick={handleDelete}>Yes</button>
          <button onClick={() => setConfirm(false)}>No</button>
        </div>
      )}
    </div>
  );
};

export default EmployeeCard;
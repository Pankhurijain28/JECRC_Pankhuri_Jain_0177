import React, { useState, useContext } from "react";
import { EmployeeContext } from "../../context/EmployeeContext";
import { toast } from "react-toastify";

const EmployeeForm = () => {
  const { addEmployee } = useContext(EmployeeContext);

  const [emp, setEmp] = useState({
    name: "",
    email: "",
    department: "",
  });

  const handleSubmit = () => {
    if (!emp.name || !emp.email) {
      toast.error("All fields required");
      return;
    }

    addEmployee(emp);
    toast.success("Employee added");

    setEmp({ name: "", email: "", department: "" });
  };

  return (
    <div className="card">
      <h3>Add Employee</h3>

      <input
        value={emp.name}
        placeholder="Name"
        onChange={(e)=>setEmp({...emp,name:e.target.value})}
      />
      <input
        value={emp.email}
        placeholder="Email"
        onChange={(e)=>setEmp({...emp,email:e.target.value})}
      />
      <input
        value={emp.department}
        placeholder="Department"
        onChange={(e)=>setEmp({...emp,department:e.target.value})}
      />
      
      <button onClick={handleSubmit}>Add</button>
      
    </div>
    
  );
};

export default EmployeeForm;
import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { addEmployee } from '../features/employees/employeeSlice';

const EmployeeForm = () => {
  const [name, setName] = useState('');
  const dispatch = useDispatch();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!name.trim()) return;

    dispatch(addEmployee({ id: Date.now(), name }));
    setName('');
  };

  return (
    <div className="card">
      <h3>Add Employee</h3>

      <form onSubmit={handleSubmit}>
        <input
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Enter employee name"
        />
        <button className="btn-primary">Add</button>
      </form>
    </div>
  );
};

export default EmployeeForm;
import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { deleteEmployee, updateEmployee } from '../features/employees/employeeSlice';

const EmployeeList = () => {
  const employees = useSelector(state => state.employees.list);
  const dispatch = useDispatch();

  const [editId, setEditId] = useState(null);
  const [name, setName] = useState('');

  return (
    <div className="card">
      <h3>Employees</h3>

      {employees.map(emp => (
        <div key={emp.id} style={{
          display: 'flex',
          justifyContent: 'space-between',
          marginBottom: '10px'
        }}>
          {editId === emp.id ? (
            <>
              <input value={name} onChange={(e) => setName(e.target.value)} />
              <button className="btn-secondary" onClick={() => {
                dispatch(updateEmployee({ id: emp.id, name }));
                setEditId(null);
              }}>
                Save
              </button>
            </>
          ) : (
            <>
              <span>{emp.name}</span>

              <div>
                <button
                  className="btn-secondary"
                  onClick={() => {
                    setEditId(emp.id);
                    setName(emp.name);
                  }}
                >
                  Edit
                </button>

                <button
                  className="btn-danger"
                  onClick={() => dispatch(deleteEmployee(emp.id))}
                  style={{ marginLeft: '10px' }}
                >
                  Delete
                </button>
              </div>
            </>
          )}
        </div>
      ))}
    </div>
  );
};

export default EmployeeList;
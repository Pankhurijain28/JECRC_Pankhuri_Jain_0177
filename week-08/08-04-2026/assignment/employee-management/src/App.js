import React from 'react';
import { useSelector } from 'react-redux';
import Navbar from './components/Navbar';
import Login from './components/Login';
import EmployeeForm from './components/EmployeeForm';
import EmployeeList from './components/EmployeeList';

function App() {
  const { isLoggedIn } = useSelector(state => state.auth);
  const theme = useSelector(state => state.ui.theme);

  return (
    <div className={`app ${theme}`}>
      <Navbar />

      {!isLoggedIn ? (
        <Login />
      ) : (
        <>
          <EmployeeForm />
          <EmployeeList />
        </>
      )}
    </div>
  );
}

export default App;
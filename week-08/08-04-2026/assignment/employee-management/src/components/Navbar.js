import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { logout } from '../features/auth/authSlice';
import { toggleTheme } from '../features/ui/uiSlice';

const Navbar = () => {
  const dispatch = useDispatch();
  const { isLoggedIn, user } = useSelector(state => state.auth);
  const theme = useSelector(state => state.ui.theme);

  return (
    <div className="navbar">
      <h2>EMS Dashboard</h2>

      <div className="nav-right">
        <button onClick={() => dispatch(toggleTheme())}>
          {theme === 'light' ? '🌙 Dark' : '☀️ Light'}
        </button>

        {isLoggedIn && (
          <>
            <span>👤 {user?.name}</span>
            <button className="btn-danger" onClick={() => dispatch(logout())}>
              Logout
            </button>
          </>
        )}
      </div>
    </div>
  );
};

export default Navbar;
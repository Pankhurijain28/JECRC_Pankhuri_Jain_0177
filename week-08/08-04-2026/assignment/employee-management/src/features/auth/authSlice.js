import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  isLoggedIn: false,
  user: null,
  error: null
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    login: (state, action) => {
      const { username, password } = action.payload;

      // Dummy credentials
      if (username === 'admin' && password === '1234') {
        state.isLoggedIn = true;
        state.user = { name: username };
        state.error = null;
      } else {
        state.error = 'Invalid credentials';
      }
    },
    logout: (state) => {
      state.isLoggedIn = false;
      state.user = null;
    }
  }
});

export const { login, logout } = authSlice.actions;
export default authSlice.reducer;
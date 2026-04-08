import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  list: []
};

const employeeSlice = createSlice({
  name: 'employees',
  initialState,
  reducers: {
    addEmployee: (state, action) => {
      state.list.push(action.payload);
    },
    deleteEmployee: (state, action) => {
      state.list = state.list.filter(emp => emp.id !== action.payload);
    },
    updateEmployee: (state, action) => {
      const index = state.list.findIndex(emp => emp.id === action.payload.id);
      if (index !== -1) {
        state.list[index] = action.payload;
      }
    }
  }
});

export const { addEmployee, deleteEmployee, updateEmployee } = employeeSlice.actions;
export default employeeSlice.reducer;
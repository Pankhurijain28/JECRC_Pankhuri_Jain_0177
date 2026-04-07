import { useEmployee } from "../hooks/useEmployee";

export default function Dashboard() {
  const { employees } = useEmployee();

  return (
    <div>
      <h2>Dashboard</h2>
      <h4>Total Employees: {employees.length}</h4>
    </div>
  );
}
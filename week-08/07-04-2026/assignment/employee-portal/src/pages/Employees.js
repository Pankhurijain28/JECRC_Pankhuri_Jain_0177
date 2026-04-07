import { useEmployee } from "../hooks/useEmployee";
import { v4 as uuid } from "uuid";

export default function Employees() {
  const { employees, add, remove } = useEmployee();

  return (
    <div>
      <button onClick={() => add({ id: uuid(), name: "New" })}>
        Add
      </button>

      {employees.map((e) => (
        <div key={e.id}>
          {e.name}
          <button onClick={() => remove(e.id)}>Delete</button>
        </div>
      ))}
    </div>
  );
}
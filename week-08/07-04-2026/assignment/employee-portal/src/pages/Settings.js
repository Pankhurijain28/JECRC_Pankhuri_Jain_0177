import { useTheme } from "../hooks/useTheme";

export default function Settings() {
  const { dark, toggle } = useTheme();

  return (
    <div>
      <h3>Settings</h3>
      <button onClick={toggle}>
        {dark ? "Light Mode" : "Dark Mode"}
      </button>
    </div>
  );
}
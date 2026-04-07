import { useAuth } from "../hooks/useAuth";

export default function Navbar() {
  const { user, logout } = useAuth();

  return (
    <div className="d-flex justify-content-between p-3 bg-dark text-white">
      <h5>Employee Portal</h5>
      <div>
        {user?.name}
        {user && (
          <button className="btn btn-danger btn-sm ms-2" onClick={logout}>
            Logout
          </button>
        )}
      </div>
    </div>
  );
}
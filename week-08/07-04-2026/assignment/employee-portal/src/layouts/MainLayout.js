import Navbar from "../components/Navbar";
import Sidebar from "../components/Sidebar";

export default function MainLayout({ children }) {
  return (
    <div className="d-flex">
      <Sidebar />
      <div className="w-100">
        <Navbar />
        <div className="p-3">{children}</div>
      </div>
    </div>
  );
}
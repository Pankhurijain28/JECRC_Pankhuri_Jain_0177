function DashboardHome() {
  return (
    <div>
      <h2>Dashboard Overview</h2>
      <div style={{ display: "flex" }}>
        <div className="card">Orders: 120</div>
        <div className="card">Revenue: ₹50,000</div>
        <div className="card">Users: 300</div>
      </div>
    </div>
  );
}
export default DashboardHome;
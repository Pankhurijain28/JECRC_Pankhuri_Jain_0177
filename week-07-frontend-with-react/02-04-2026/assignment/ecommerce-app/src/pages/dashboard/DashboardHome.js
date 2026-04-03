function DashboardHome() {
  return (
    <div>

      <h2 style={{ marginBottom: "20px" }}>Overview</h2>

      <div className="dashboard-cards">

        <div className="dashboard-card card-orders">
          <h3>📦 Orders</h3>
          <p>120</p>
        </div>

        <div className="dashboard-card card-revenue">
          <h3>💰 Revenue</h3>
          <p>₹50,000</p>
        </div>

        <div className="dashboard-card card-users">
          <h3>👤 Users</h3>
          <p>300</p>
        </div>

      </div>

    </div>
  );
}

export default DashboardHome;
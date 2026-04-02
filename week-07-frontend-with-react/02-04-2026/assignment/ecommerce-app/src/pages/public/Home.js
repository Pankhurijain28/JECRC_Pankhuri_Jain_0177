function Home() {
  return (
    <div>
      <div className="hero">
        <h1>Welcome to ShopPro 🚀</h1>
        <p>Best Deals • Fast Delivery • Secure Payment</p>
      </div>

      <h2>🔥 Trending Products</h2>

      <div className="product-grid">
        <div className="product-card">
          <img src="https://images.unsplash.com/photo-1517336714731-489689fd1ca8"/>
          <h3>Laptop</h3>
          <p>₹50,000</p>
          <button>Buy Now</button>
        </div>

        <div className="product-card">
          <img src="https://images.unsplash.com/photo-1511707171634-5f897ff02aa9"/>
          <h3>Phone</h3>
          <p>₹20,000</p>
          <button>Buy Now</button>
        </div>
      </div>
    </div>
  );
}
export default Home;
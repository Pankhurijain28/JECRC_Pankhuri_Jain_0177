import { Link } from "react-router-dom";
const products = [
  { id: 1, name: "MacBook", price: 120000, image: "https://images.unsplash.com/photo-1517336714731-489689fd1ca8" },
  { id: 2, name: "iPhone", price: 80000, image: "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9" },
  { id: 3, name: "Shoes", price: 3000, image: "https://images.unsplash.com/photo-1528701800489-20be3c5c7f3c" },
  { id: 4, name: "Watch", price: 15000, image: "https://images.unsplash.com/photo-1516574187841-cb9cc2ca948b" },
  { id: 5, name: "Headphones", price: 5000, image: "https://images.unsplash.com/photo-1518449037997-1a1d8f3a4d5e" },
];

function ProductList() {
  return (
    <div>
      <h2>Products</h2>

      <div className="product-grid">
        {products.map(p => (
          <div className="product-card" key={p.id}>
            <img src={p.image} alt={p.name} />
            <h3>{p.name}</h3>
            <p>₹{p.price}</p>

            <Link to={`/products/${p.id}`}>
              <button>View Details</button>
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}

export default ProductList;
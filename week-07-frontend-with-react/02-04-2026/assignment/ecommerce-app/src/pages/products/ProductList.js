import { Link } from "react-router-dom";
import products from "../../data/products";

function ProductList() {
  return (
    <div>
      <h2>🛍 All Products</h2>

      <div className="product-grid">
        {products.map(p => (
          <div className="product-card" key={p.id}>
            <img src={p.image} alt={p.name} />

            <h3>{p.name}</h3>
            <p>₹{p.price}</p>
            <p>⭐ {p.rating}</p>

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
import { useParams, Link, Outlet } from "react-router-dom";
import products from "../../data/products";

function ProductDetails() {
  const { productId } = useParams();

  const product = products.find(p => p.id === Number(productId));

  if (!product) return <h2>Product not found</h2>;

  return (
    <div className="product-details">
      <div style={{ display: "flex", gap: "30px" }}>
        
        {/* IMAGE */}
        <img
          src={product.image}
          alt={product.name}
          style={{ width: "300px", borderRadius: "12px" }}
        />

        {/* DETAILS */}
        <div>
          <h2>{product.name}</h2>
          <p>⭐ {product.rating}</p>
          <p><b>Category:</b> {product.category}</p>
          <p>{product.description}</p>
          <h3>₹{product.price}</h3>

          <button>Add to Cart</button>
        </div>
      </div>

      {/* NESTED LINKS */}
      <div style={{ marginTop: "20px" }}>
        <Link to="reviews">Reviews</Link> | 
        <Link to="specs">Specs</Link>
      </div>

      <Outlet />
    </div>
  );
}

export default ProductDetails;
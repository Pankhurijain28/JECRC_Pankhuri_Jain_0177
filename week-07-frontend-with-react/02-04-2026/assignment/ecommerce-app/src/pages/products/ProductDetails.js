import { useParams, Link, Outlet } from "react-router-dom";

function ProductDetails() {
  const { productId } = useParams();

  return (
    <div className="product-details">
      <h2>Product #{productId}</h2>

      <p>🔥 High quality premium product with best performance.</p>

      <div>
        <Link to="reviews">Reviews</Link> | 
        <Link to="specs">Specs</Link>
      </div>

      <Outlet />
    </div>
  );
}

export default ProductDetails;
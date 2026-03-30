import React, { useState } from "react";
import ProductList from "./components/ProductList";
import Cart from "./components/Cart";
import "./App.css";

function App() {
  const products = [
    { id: 1, name: "React T-Shirt", price: 25 },
    { id: 2, name: "Angular Hoodie", price: 40 },
    { id: 3, name: "Vue Cap", price: 15 }
  ];

  const [cart, setCart] = useState([]);

  // Add to cart
  const addToCart = (product) => {
    const existing = cart.find((item) => item.id === product.id);

    if (existing) {
      setCart(
        cart.map((item) =>
          item.id === product.id
            ? { ...item, quantity: item.quantity + 1 }
            : item
        )
      );
    } else {
      setCart([...cart, { ...product, quantity: 1 }]);
    }
  };

  // Update quantity
  const updateQuantity = (id, delta) => {
    setCart(
      cart
        .map((item) =>
          item.id === id
            ? { ...item, quantity: item.quantity + delta }
            : item
        )
        .filter((item) => item.quantity > 0)
    );
  };

  // Remove item
  const removeItem = (id) => {
    setCart(cart.filter((item) => item.id !== id));
  };

  // Total price
  const total = cart.reduce(
    (sum, item) => sum + item.price * item.quantity,
    0
  );

  return (
    <div style={{ padding: "20px" }}>
      <h1>Shopping Cart</h1>

      <ProductList products={products} addToCart={addToCart} />

      <hr />

      <Cart
        cart={cart}
        updateQuantity={updateQuantity}
        removeItem={removeItem}
        total={total}
      />
    </div>
  );
}

export default App;
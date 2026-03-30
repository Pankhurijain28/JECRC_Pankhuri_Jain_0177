import React from "react";

function CartItem({ item, updateQuantity, removeItem }) {
  return (
    <div style={styles.item}>
      <div>
        <h4>{item.name}</h4>
        <p>${item.price} x {item.quantity}</p>
      </div>

      <div>
        <button onClick={() => updateQuantity(item.id, -1)}>-</button>
        <span>{item.quantity}</span>
        <button onClick={() => updateQuantity(item.id, 1)}>+</button>

        <button onClick={() => removeItem(item.id)}>Remove</button>
      </div>
    </div>
  );
}

const styles = {
  item: {
    display: "flex",
    justifyContent: "space-between",
    marginBottom: "10px",
    borderBottom: "1px solid #ccc"
  }
};

export default CartItem;
import React, {useState, useReducer} from 'react';
import './App.css';

function App() {
  //7
  // 🔹 Initial State
  const initialCounterState = {
    count: 0,
    history: []
  };

  // 🔹 Reducer Function
  function counterReducer(state, action) {
    switch (action.type) {
      case "increment":
        return {
          count: state.count + 1,
          history: [
            ...state.history,
            { type: "increment", value: state.count + 1, time: new Date().toLocaleTimeString() }
          ]
        };

      case "decrement":
        return {
          count: state.count - 1,
          history: [
            ...state.history,
            { type: "decrement", value: state.count - 1, time: new Date().toLocaleTimeString() }
          ]
        };

      case "reset":
        return {
          count: 0,
          history: [
            ...state.history,
            { type: "reset", value: 0, time: new Date().toLocaleTimeString() }
          ]
        };

      case "set":
        return {
          count: action.payload,
          history: [
            ...state.history,
            { type: "set", value: action.payload, time: new Date().toLocaleTimeString() }
          ]
        };

      default:
        return state;
    }
  }

  // useReducer Hook
  const [counterState, dispatch] = useReducer(counterReducer, initialCounterState);

  // Input State for SET
  const [inputValue, setInputValue] = useState("");

  return (
    <div style={styles.container}>
      <h1>useReducer Counter (Advanced)</h1>

      <h2>Count: {counterState.count}</h2>

      {/* 🔹 Actions */}
      <div>
        <button style={styles.btn} onClick={() => dispatch({ type: "increment" })}>
          +1
        </button>

        <button style={styles.btn} onClick={() => dispatch({ type: "decrement" })}>
          -1
        </button>

        <button style={styles.resetBtn} onClick={() => dispatch({ type: "reset" })}>
          Reset
        </button>
      </div>

      {/* 🔹 Set Value */}
      <div style={{ marginTop: "20px" }}>
        <input
          type="number"
          placeholder="Enter value"
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
          style={styles.input}
        />

        <button
          style={styles.btn}
          onClick={() =>
            dispatch({ type: "set", payload: Number(inputValue) })
          }
        >
          Set Value
        </button>
      </div>

      {/* 🔹 History */}
      <h3 style={{ marginTop: "30px" }}>History</h3>

      <ul style={styles.list}>
        {counterState.history.map((item, index) => (
          <li key={index} style={styles.card}>
            <b>{item.type.toUpperCase()}</b> → {item.value}
            <br />
            <small>{item.time}</small>
          </li>
        ))}
      </ul>

      <p style={styles.info}>
        👉 useReducer is best for <b>complex state logic & history tracking</b>
      </p>
    </div>
  );
}

// 🎨 Styling
const styles = {
  container: {
    textAlign: "center",
    marginTop: "40px",
    fontFamily: "Arial"
  },
  btn: {
    margin: "10px",
    padding: "10px 15px",
    cursor: "pointer"
  },
  resetBtn: {
    margin: "10px",
    padding: "10px 15px",
    backgroundColor: "red",
    color: "white",
    border: "none",
    cursor: "pointer"
  },
  input: {
    padding: "10px",
    marginRight: "10px"
  },
  list: {
    listStyle: "none",
    padding: 0
  },
  card: {
    border: "1px solid #ccc",
    margin: "10px auto",
    padding: "10px",
    width: "250px"
  },
  info: {
    marginTop: "20px",
    color: "green"
  }
};

  //6
  //array state
  // const [items, setItems] = useState([]);

  // //add single item
  // const addItem = () => {
  //   const newItem = {
  //     id: Date.now(),
  //     name: "Item" + (items.length + 1),
  //     created : new Date().toLocaleTimeString()
  //   };
    
  //   setItems(prevItems => [...prevItems, newItem]);
  // };

  // // add multiple items
  // const addMultipleItems = () => {
  //   const newItems = [
  //     {id: Date.now(), name: "Batch Item 1", created: new Date().toLocaleTimeString()},
  //     {id: Date.now() + 1, name: "Batch Item 2", created: new Date().toLocaleTimeString()},
  //     {id: Date.now() + 2, name: "Batch Item 3", created: new Date().toLocaleTimeString()}
  //   ];
    
  //   setItems(prevItems => [...prevItems, ...newItems]);
  //   };

  //   // update item
  //   const updateItem = (id) => {
  //     setItems(prev => prev.map(item => item.id === id ? {...item, name: "Updated Item", updated: new Date().toLocaleTimeString()} : item));
  //   };

  //   //delete item
  //   const deleteItem = (id) => {
  //     setItems(prev => prev.filter(item => item.id !== id));
  //   };

  //   //delete all
  //   const deleteAllItems = () => {
  //     setItems([]);
  //   };

  //   return (
  //     <div style={style.container}>
  //       <h1>Array State Demo</h1>
  //       <button style={style.btn} onClick={addItem}>Add Item</button>
  //       <button style={style.btn} onClick={addMultipleItems}>Add Multiple Items</button>
  //       <button style={style.btn} onClick={deleteAllItems}>Delete All Items</button>

  //       <ul style={{listStyle: 'none', padding: 0}}>
  //         {items.map(item => (
  //           <li key={item.id} style={{margin: '10px 0', border: '1px solid #ccc', padding: '10px'}}>
  //             <p><strong>{item.name}</strong></p>
  //             <p>Created: {item.created}</p>
  //             {item.updated && <p>Updated: {item.updated}</p>}
  //             <button style={style.btn} onClick={() => updateItem(item.id)}>Update</button>
  //             <button style={style.btn} onClick={() => deleteItem(item.id)}>Delete</button>
  //           </li>
  //         ))}
  //       </ul>
  //     </div>
  //   );

  //5

 //Object State
  // const [user, setUser] = useState({
  //   name: '',
  //   age: '',
  //   email: '',
  // });

  // //update Functions
  // const updateUserName = (value) => {
  //   setUser(prevUser => ({
  //     ...prevUser,
  //     name: value,
  //   }));
  // };

  // const updateUserAge = (value) => {
  //   setUser(prevUser => ({
  //     ...prevUser,
  //     age: value,
  //   }));
  // };

  // const updateUserEmail = (value) => {
  //   setUser(prevUser => ({
  //     ...prevUser,
  //     email: value,
  //   }));
  // };

  // const resetUser = () => {
  //   setUser({
  //     name: '',
  //     age: '',
  //     email: '',
  //   });
  // };


  // return(
  //   <div style={style.container}>
  //     <h1>Object State Demo</h1>
      
  //     <input
  //       type="text"
  //       placeholder="Enter Name:"
  //       onChange={(e) => updateUserName(e.target.value)}
  //       style={style.input}
  //     />

  //     <input
  //       type="text"
  //       placeholder="Enter Age:"
  //       onChange={(e) => updateUserAge(e.target.value)}
  //       style={style.input}
  //     />

  //     <input
  //       type="text"
  //       placeholder="Enter Email:"
  //       onChange={(e) => updateUserEmail(e.target.value)}
  //       style={style.input}
  //     />

  //     <button style={style.btn} onClick={resetUser}>Reset</button>

  //     <h3>Name: {user.name}</h3>
  //     <h3>Age: {user.age}</h3>
  //     <h3>Email: {user.email}</h3>
  //   </div>
  // );


//   //4.

//   //lazy lnitialization

//   const [data, setData] = useState(() => {
//     console.log("Expensive compuation running...");

//     let result =0;
//     for(let i=0; i< 1000000; i++){
//       result += i;
//     }

//     return result%1000;;

//   });

//   const recalculate = () => {
//     setData(prev => {
//       console.log("Recalculating data...");
//       return prev +100;
//     });

//   };


//   return (
//     <div style={style.container}>
//       <h1>Lazy Initialization Demo</h1>
//       <h2>Computed Value: {data}</h2>
//       <button style={style.btn} onClick={recalculate}>Recalculate Data</button>

//       <p style={style.info}>Expensive demo only runs once during initial render</p>

//       <p style={style.info}>Open console to see the log messages</p>
//     </div>
//   );

  //3
  // const [count, setCount] = useState(0);

  // //Functional updates 
  // const increment = () => {
  //   setCount(prev => prev + 1);
  // };

  // const incrementByTwo = () => {
  //   setCount(prev => prev + 2);
  // };

  // const resetCount = () => {
  //   setCount(0);
  // };

  // return(
  //   <div style={style.container}>
  //     <h1>Functional Update Demo</h1>
  //     <h2>Count: {count}</h2>

  //     <div> 
  //       <button style={style.btn} onClick={increment}>Increment by 1</button>
  //       <button style={style.btn} onClick={incrementByTwo}>Increment by 2</button>
  //       <button style={style.btn} onClick={resetCount}>Reset Count</button>
  //     </div>
  //   </div>
  // );


  //2
  // const [count, setCount] = useState(0);

  // return (
  //   <div style={style.container}>
  //     <h1>Counter App</h1>
  //     <h2>Count: {count}</h2>
  //     <button style={style.btn} onClick={() => setCount(prev => prev + 1)}>Increment by 1</button>
  //     <button style={style.btn} onClick={() => setCount(prev => prev - 1)}>Decrement by 1</button>
  //   </div>
  // )


  //1
  // //Step:1 Basic state
  // const [count, setCount] = useState(0);

  // //Step 2: Function to update state
  // const increment = () => {
  //   setCount(prev => prev + 1);
  // };

  // const incrementByTwo = () => {
  //   setCount(prev => prev + 2);
  // };

  // const resetCount = () => {
  //   setCount(0);
  // };

  // return (
  //   <div className="App">
  //     <h1>Count: {count}</h1>
  //     <button onClick={increment}>Increment by 1</button>
  //     <button onClick={incrementByTwo}>Increment by 2</button>
  //     <button onClick={resetCount}>Reset Count</button>
  //   </div>
  // );

// const style = {
//   container: {
//     textAlign: 'center',
//     marginTop: '50px',
//   },
//   btn: {
//     margin: '10px',
//     padding: '10px 20px',
//     fontSize: '16px',
//   },
//   input: {
//     display: 'block',
//     margin: '10px auto',
//     padding: '10px',
//   }
// };

export default App;
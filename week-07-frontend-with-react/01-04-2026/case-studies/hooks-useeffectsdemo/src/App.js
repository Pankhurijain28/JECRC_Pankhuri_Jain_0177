import React, { useState, useEffect } from "react";

function App() {

  const [posts, setPosts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const [searchTerm, setSearchTerm] = useState("");
  const [debouncedTerm, setDebouncedTerm] = useState("");

  // ==================== EFFECT 8: Fetch Data ====================
  useEffect(() => {
    let isMounted = true;

    const fetchPosts = async () => {
      console.log("📡 Effect 8: Fetching posts");

      setLoading(true);
      setError(null);

      try {
        const response = await fetch(
          "https://jsonplaceholder.typicode.com/posts?_limit=5"
        );

        if (!response.ok) throw new Error("Failed to fetch");

        const data = await response.json();

        if (isMounted) {
          setPosts(data);
          setLoading(false);
        }

      } catch (err) {
        if (isMounted) {
          setError(err.message);
          setLoading(false);
        }
      }
    };

    fetchPosts();

    return () => {
      console.log("🧹 Cleanup: Cancelling data fetch");
      isMounted = false;
    };
  }, []);

  // ==================== EFFECT 9: Debounced Search ====================
  useEffect(() => {
    console.log(`🔍 Effect 9: Debouncing search: "${searchTerm}"`);

    const timer = setTimeout(() => {
      setDebouncedTerm(searchTerm);
    }, 500);

    return () => {
      clearTimeout(timer);
    };
  }, [searchTerm]);

  // 🔹 Filtered Posts
  const filteredPosts = posts.filter(post =>
    post.title.toLowerCase().includes(debouncedTerm.toLowerCase())
  );

  return (
    <div style={styles.container}>
      <h1>API + Debounced Search</h1>

      {/* 🔹 Search */}
      <input
        type="text"
        placeholder="Search posts..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        style={styles.input}
      />

      {/* 🔹 Status */}
      {loading && <p>Loading...</p>}
      {error && <p style={{ color: "red" }}>{error}</p>}

      {/* 🔹 Posts */}
      <div>
        {filteredPosts.map(post => (
          <div key={post.id} style={styles.card}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
          </div>
        ))}
      </div>

      <p style={styles.info}>
        👉 API fetch with cleanup + debounced search (performance optimized)
      </p>

      <p style={styles.note}>
        Open console to see logs 👀
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
  input: {
    padding: "10px",
    width: "250px",
    marginBottom: "20px"
  },
  card: {
    border: "1px solid #ccc",
    padding: "15px",
    margin: "10px auto",
    width: "300px"
  },
  info: {
    marginTop: "20px",
    color: "green"
  },
  note: {
    color: "gray"
  }
};

export default App;

// import React, { useState, useEffect } from "react";
// function App() {
//   const [name, setName] = useState("");
//   const [count, setCount] = useState(0);

//   // 🔹 Effect 1: Runs only once (Component Mount)
//   useEffect(() => {
//     console.log("Effect 2: Component mounted");

//     // Load saved name
//     const savedName = localStorage.getItem("name");
//     if (savedName) setName(savedName);

//     // Load saved count
//     const savedCount = localStorage.getItem("count");
//     if (savedCount) setCount(parseInt(savedCount));
//   }, []);

//   // 🔹 Effect 2: Save data whenever it changes
//   useEffect(() => {
//     localStorage.setItem("name", name);
//     localStorage.setItem("count", count);
//   }, [name, count]);

//    return (
//   <div style={styles.container}>
//     <h1>useEffect - Component Mount</h1>

//     {/* 🔹 Name Input */}
//     <input
//       type="text"
//       placeholder="Enter your name"
//       value={name}
//       onChange={(e) => setName(e.target.value)}
//       style={styles.input}
//     />

//     <h3>Hello, {name || "Guest"} 👋</h3>

//     {/* 🔹 Counter */}
//     <h2>Count: {count}</h2>

//     <button
//       style={styles.btn}
//       onClick={() => setCount(count + 1)}
//     >
//       Increment
//     </button>

//     <button
//       style={styles.resetBtn}
//       onClick={() => {
//         setName("");
//         setCount(0);
//         localStorage.clear();
//       }}
//     >
//       Reset
//     </button>

//     <p style={styles.info}>
//       📌 Data is saved in <b>localStorage</b> and restored on refresh
//     </p>

//     <p style={styles.note}>
//       🔄 Refresh the page to test persistence
//     </p>
//   </div>
// );
// }

// // 🔹 Styling
// const styles = {
//   container: {
//     textAlign: "center",
//     marginTop: "50px",
//     fontFamily: "Arial",
//   },

//   input: {
//     padding: "10px",
//     margin: "10px",
//     width: "200px",
//   },

//   btn: {
//     padding: "10px 20px",
//     margin: "10px",
//     cursor: "pointer",
//   },

//   resetBtn: {
//     padding: "10px 20px",
//     margin: "10px",
//     cursor: "pointer",
//     backgroundColor: "red",
//     color: "white",
//   },

//   info: {
//     marginTop: "20px",
//     fontSize: "14px",
//     color: "gray",
//   },

//   note: {
//     fontSize: "13px",
//     color: "#555",
//   },
// };

// export default App;




// import React, { useState, useEffect } from "react";

// function App() {
//   const [count, setCount] = useState(0);
//   const [text, setText] = useState("");

//   // 🔹 Effect 1: Runs after EVERY render
//   useEffect(() => {
//     console.log("Effect 1: After every render");
//   });

//   return (
//     <div style={styles.page}>
//       <div style={styles.container}>
//         <h1 style={styles.heading}>⚡ useEffect Demo</h1>

//         {/* 🔹 Counter Section */}
//         <div style={styles.card}>
//           <h2 style={styles.count}>Count: {count}</h2>
//           <button
//             style={styles.btn}
//             onClick={() => setCount(count + 1)}
//           >
//             ➕ Increment
//           </button>
//         </div>

//         {/* 🔹 Input Section */}
//         <div style={styles.card}>
//           <input
//             type="text"
//             placeholder="Type something..."
//             value={text}
//             onChange={(e) => setText(e.target.value)}
//             style={styles.input}
//           />
//           <p style={styles.preview}>
//             You typed: <b>{text || "Nothing yet..."}</b>
//           </p>
//         </div>

//         {/* 🔹 Info */}
//         <p style={styles.info}>
//           This effect runs after <b>every render</b> (state change)
//         </p>
//       </div>
//     </div>
//   );
// }

// // 🔹 Styles
// const styles = {
//   page: {
//     height: "100vh",
//     background: "linear-gradient(135deg, #667eea, #764ba2)",
//     display: "flex",
//     justifyContent: "center",
//     alignItems: "center",
//     fontFamily: "Arial, sans-serif",
//   },

//   container: {
//     background: "#fff",
//     padding: "30px",
//     borderRadius: "12px",
//     width: "350px",
//     textAlign: "center",
//     boxShadow: "0 8px 20px rgba(0,0,0,0.2)",
//   },

//   heading: {
//     marginBottom: "20px",
//     color: "#333",
//   },

//   card: {
//     marginBottom: "20px",
//     padding: "15px",
//     borderRadius: "10px",
//     background: "#f5f7ff",
//   },

//   count: {
//     marginBottom: "10px",
//     color: "#444",
//   },

//   btn: {
//     padding: "10px 20px",
//     background: "#667eea",
//     color: "#fff",
//     border: "none",
//     borderRadius: "6px",
//     cursor: "pointer",
//     fontSize: "16px",
//     transition: "0.3s",
//   },

//   input: {
//     padding: "10px",
//     width: "100%",
//     borderRadius: "6px",
//     border: "1px solid #ccc",
//     outline: "none",
//   },

//   preview: {
//     marginTop: "10px",
//     color: "#555",
//   },

//   info: {
//     marginTop: "10px",
//     fontSize: "14px",
//     color: "#777",
//   },
// };

// export default App;
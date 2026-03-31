import React, { useState } from "react";

function Counter(){
    const [count, setCount] = useState(0);
    const[step, setStep] = useState(1);

    const [lastAction, setLastAction] = useState("None");

    const increment = () => {
        setCount(count + step);

        setLastAction("Increment by " + step);
    }
    const decrement = () => {
        setCount(count - step);

        setLastAction("Decrement by " + step);
    }

    const reset = () => {
        setCount(0);
        setStep(1);
        setLastAction("Reset to 0");
    }

    return(
        <div style= {{ padding: "20px", textAlign: "center"}}>

            {/*display current state*/}

        <div style={{ fontSize: "20px", margin: "20px"}}>
            <h1>Counter: {count}</h1>
        </div>

        {/* Step Input */}
        <div style={{ marginBottom: "20px"}}>
            <label>
                Step:
                <input 
                    type="number" 
                    value={step} 
                    onChange={(e) => setStep(Number(e.target.value))} 
                    style={{ marginLeft: "10px", width: "60px" }}
                />
            </label>
        </div>

        {/*action buttons */}

        <div>
            <button onClick={increment}>Increment</button>
            <button onClick={decrement}>Decrement</button>
            <button onClick={reset} style ={{ marginLeft: "10px"}}>Reset</button>
        </div>
        {/*last action display */}
        <div style={{ marginTop: "20px", fontStyle: "italic"}}>
            Last Action: {lastAction}
        </div>
</div>
    );
}

const buttonStyle = {
    padding: "10px 20px",
    fontSize: "16px",
    margin: "0 10px",
    cursor: "pointer",
    backgroundColor: "#007bff",
    color: "white",
    border: "none",
    borderRadius: "5px",
};


export default Counter;
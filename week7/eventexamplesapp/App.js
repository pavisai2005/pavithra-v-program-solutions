import React, { useState } from 'react';
import CurrencyConvertor from './CurrencyConvertor';
import './App.css';

function App() {
  const [count, setCount] = useState(0);

  const handleIncrement = () => {
    increment();
    sayHello();
  };

  const increment = () => {
    setCount(prevCount => prevCount + 1);
  };

  const decrement = () => {
    setCount(prevCount => prevCount - 1);
  };

  const sayHello = () => {
    alert("INCREMENTING... \nHello Student");
  };

  const sayMessage = (message) => {
    alert(message);
  };

  const handlePress = () => {
    alert("I was clicked");
  };

  return (
    <div className="container">
      <h1>React App</h1>
      <div className="button-section">
        <button onClick={handleIncrement}>Increment</button>
        <button onClick={decrement}>Decrement</button>
        <button onClick={() => sayMessage("Say welcome")}>Say Welcome</button>
        <button onClick={handlePress}>Click on me</button>
      </div>
      <h3>Counter: {count}</h3> {/* ✅ Added line to display count */}
      <CurrencyConvertor />
    </div>
  );
}

export default App;
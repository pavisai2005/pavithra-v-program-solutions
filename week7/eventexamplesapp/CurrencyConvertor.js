import React, { useState } from 'react';
import './App.css';

function CurrencyConvertor() {
  const [rupees, setRupees] = useState('');
  const [euro, setEuro] = useState(null);

  const handleSubmit = () => {
    if (!rupees || isNaN(rupees)) {
      alert("Please enter a valid number!");
      return;
    }
    const euroValue = parseFloat(rupees) / 90;
    setEuro(euroValue.toFixed(2));
  };

  return (
    <div className="currency-box">
      <h2>Currency Convertor!!!</h2>
      <label>Amount</label>
      <input
        type="number"
        placeholder="INR"
        value={rupees}
        onChange={(e) => setRupees(e.target.value)}
      />
      <br />
      <label>Currency</label>
      <input type="text" value="Euro" disabled />
      <br />
      <button onClick={handleSubmit}>Submit</button>
      {euro && <p>€ {euro}</p>}
    </div>
  );
}

export default CurrencyConvertor;
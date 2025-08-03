import React from 'react';
import './App.css';

function App() {
  const element = "Office Space";
  const imgSrc = "https://images.unsplash.com/photo-1570129477492-45c003edd2be"; // Replace with your preferred office image URL

  const itemName = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai"
  };

  const rentColor = itemName.Rent <= 60000 ? "textRed" : "textGreen";

  return (
    <div className="App">
      <h1>{element} , at Affordable Range</h1>
      <img src={imgSrc} width="25%" height="25%" alt="Office Space" />

      <h2>Name: {itemName.Name}</h2>
      <h3 className={rentColor}>Rent: Rs. {itemName.Rent}</h3>
      <h3>Address: {itemName.Address}</h3>
    </div>
  );
}

export default App;
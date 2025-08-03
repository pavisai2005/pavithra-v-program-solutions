import React from 'react';

const flights = [
  { id: 1, from: 'Chennai', to: 'Delhi', time: '10:00 AM' },
  { id: 2, from: 'Mumbai', to: 'Kolkata', time: '2:30 PM' },
  { id: 3, from: 'Bangalore', to: 'Hyderabad', time: '6:45 PM' },
];

function FlightList() {
  const handleBook = (flight) => {
    alert(`Booked flight from ${flight.from} to ${flight.to} at ${flight.time}`);
  };

  return (
    <ul style={{ listStyle: 'none', padding: 0 }}>
      {flights.map((flight) => (
        <li key={flight.id} style={{ marginBottom: '15px' }}>
           {flight.from} → {flight.to} at {flight.time}
          <button onClick={() => handleBook(flight)} style={{ marginLeft: '10px' }}>
            Book
          </button>
        </li>
      ))}
    </ul>
  );
}

export default FlightList;
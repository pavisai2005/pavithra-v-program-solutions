import React from 'react';
import FlightList from './FlightList';

function GuestPage() {
  return (
    <div>
      <h2>Welcome, Guest!</h2>
      <p>Browse available flights below:</p>
      <FlightList showBookButton={false} />
    </div>
  );
}

export default GuestPage;
import React from 'react';
import FlightList from './FlightList';

function UserPage() {
  return (
    <div>
      <h2>Welcome, User!</h2>
      <p>You can book your flights below:</p>
      <FlightList showBookButton={true} />
    </div>
  );
}

export default UserPage;
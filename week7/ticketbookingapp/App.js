import React, { useState } from 'react';
import Greeting from './Greeting';
import LoginButton from './LoginButton';
import LogoutButton from './LogoutButton';
import FlightList from './FlightList';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => {
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
  };

  return (
    <div style={{ textAlign: 'center', marginTop: '100px' }}>
      {/* Greeting Message */}
      <Greeting isLoggedIn={isLoggedIn} />

      {/* Login or Logout Button */}
      {isLoggedIn ? (
        <LogoutButton onClick={handleLogout} />
      ) : (
        <LoginButton onClick={handleLogin} />
      )}

      {/* Show Flights only if logged in */}
      {isLoggedIn && (
        <>
          <h2 style={{ marginTop: '30px' }}>Available Flights</h2>
          <FlightList />
        </>
      )}
    </div>
  );
}

export default App;
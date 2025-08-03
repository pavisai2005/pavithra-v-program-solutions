import React, { useState } from 'react';
import ListOfPlayers from './ListOfPlayers';
import Scorebelow70 from './Scorebelow70';
import OddPlayers from './OddPlayers';
import EvenPlayers from './EvenPlayers';
import ListOfIndianPlayers from './ListOfIndianPlayers';

const App = () => {
  const [flag, setFlag] = useState(true); 
  const players = [
    { name: 'Jack', score: 50 },
    { name: 'Michael', score: 70 },
    { name: 'John', score: 40 },
    { name: 'Ann', score: 61 },
    { name: 'Elisabeth', score: 61 },
    { name: 'Sachin', score: 105 },
    { name: 'Dhoni', score: 100 },
    { name: 'Virat', score: 84 },
    { name: 'Jadeja', score: 64 },
    { name: 'Raina', score: 75 },
    { name: 'Rohit', score: 80 }
  ];

  const IndianPlayers = [
    'Sachin1', 'Dhoni2', 'Virat3', 'Rohit4', 'Yuvraj5', 'Raina6'
  ];

  return (
    <div style={{ padding: '20px', fontFamily: 'Arial' }}>
      <button onClick={() => setFlag(!flag)}>
        Toggle Flag (Current: {flag ? 'true' : 'false'})
      </button>

      {flag ? (
        <div>
          <h1>List of Players</h1>
          <ListOfPlayers players={players} />

          <h1>List of Players having Scores Less than 70</h1>
          <Scorebelow70 players={players} />
        </div>
      ) : (
        <div>
          <h3>When Flag=false</h3>
          <h4>Odd Players</h4>
          <OddPlayers IndianTeam={IndianPlayers} />

          <h4>Even Players</h4>
          <EvenPlayers IndianTeam={IndianPlayers} />

          <h4>List of Indian Players Merged</h4>
          <ListOfIndianPlayers IndianPlayers={IndianPlayers} />
        </div>
      )}
    </div>
  );
};

export default App;
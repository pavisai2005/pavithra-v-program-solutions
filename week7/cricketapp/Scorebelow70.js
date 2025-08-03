import React from 'react';

const Scorebelow70 = ({ players }) => {
  const filtered = players.filter(player => player.score < 70);
  return (
    <ul>
      {filtered.map((item, index) => (
        <li key={index}>
          Mr. {item.name} - <span>{item.score}</span>
        </li>
      ))}
    </ul>
  );
};

export default Scorebelow70;
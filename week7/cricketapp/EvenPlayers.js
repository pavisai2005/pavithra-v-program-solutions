import React from 'react';

const EvenPlayers = ({ IndianTeam }) => {
  const [, second, , fourth, , sixth] = IndianTeam;

  return (
    <ul>
      <li>Second: {second}</li>
      <li>Fourth: {fourth}</li>
      <li>Sixth: {sixth}</li>
    </ul>
  );
};

export default EvenPlayers;
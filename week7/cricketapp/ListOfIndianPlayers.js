import React from 'react';

const ListOfIndianPlayers = ({ IndianPlayers }) => {
  return (
    <ul>
      {IndianPlayers.map((player, index) => (
        <li key={index}>{player}</li>
      ))}
    </ul>
  );
};

/**
 * A React component that displays a list of Indian cricket players.
 *
 * @component
 * @example
 * return (
 *   <ListOfIndianPlayers />
 * )
 */
export default ListOfIndianPlayers;
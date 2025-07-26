import React from 'react';
import { Link } from 'react-router-dom';

const TrainersList = ({ trainers }) => (
  <div>
    <h2>Trainers List</h2>
    <ul>
      {trainers.map((trainer) => (
        <li key={trainer.id}>
          <Link to={`/trainers/${trainer.id}`}>{trainer.name}</Link>
        </li>
      ))}
    </ul>
  </div>
);

export default TrainersList;
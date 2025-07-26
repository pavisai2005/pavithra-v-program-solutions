import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

import Home from './Home';
import TrainersList from './TrainerList';
import TrainerDetail from './TrainerDetail'; 

const mockTrainerData = [
  { id: '1', name: 'Syed Khaleelullah' },
  { id: '2', name: 'Jojo Jose' },
  { id: '3', name: 'Elisa Jones' }
];

function App() {
  return (
    <Router>
      <div style={{ padding: '20px' }}>
        <h1>My Academy Trainers App</h1>

        <nav style={{ marginBottom: '15px' }}>
          <Link to="/" style={{ marginRight: '10px' }}>Home</Link>
          <Link to="/trainers">Show Trainers</Link>
        </nav>

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/trainers" element={<TrainersList trainers={mockTrainerData} />} />
          <Route path="/trainers/:id" element={<TrainerDetail />} /> {/*  New Route */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
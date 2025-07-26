import React from 'react';
import Posts from './Posts'; //  Importing the Posts component

function App() {
  return (
    <div className="App">
      <h1>Welcome to the Blog</h1>
      <Posts /> {/* Rendering the Posts component */}
    </div>
  );
}

export default App;
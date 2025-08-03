import React from 'react';

function BlogDetails() {
  const isLoggedIn = false; // Example condition

  return (
    <div className="v1">
      <h1>Blog Details</h1>
      {isLoggedIn && (
        <div>
          <p>1. How to Learn React</p>
          <p>2. Understanding State and Props</p>
        </div>
      )}
      {!isLoggedIn && <p>Please log in to see blog details.</p>}
    </div>
  );
}

export default BlogDetails;
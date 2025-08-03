import React from 'react';

const books = [
  { id: 101, bname: 'Master React', price: 670 },
  { id: 102, bname: 'Deep Dive into Angular 11', price: 800 },
  { id: 103, bname: 'Mongo Essentials', price: 450 },
];

function BookDetails() {
  const showBooks = true; // Toggle to test conditional rendering

  return (
    <div className="st2">
      <h1>Book Details</h1>
      {showBooks ? (
        <ul>
          {books.map((book) => (
            <div key={book.id}>
              <h3>{book.bname}</h3>
              <h4>₹{book.price}</h4>
            </div>
          ))}
        </ul>
      ) : (
        <p>No book details available</p>
      )}
    </div>
  );
}

export default BookDetails;
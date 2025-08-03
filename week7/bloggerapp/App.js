 import React from 'react';
import './App.css';

function App() {
  const courses = [
    { name: 'Angular', date: '6/1/2023' },
    { name: 'React', date: '6/2/2023' }
  ];

  const books = [
    { name: 'Angular Essentials', price: '400' },
    { name: 'React Handbook', price: '450' }
  ];

  const blogs = [
    { title: 'React Learning', content: 'React is a JavaScript library for building UI.' },
    { title: 'Installation', content: 'You can install React from npm.' }
  ];

  return (
    <div className="container">
      <div className="column">
        <h2>Course Details</h2>
        {courses.map((course, index) => (
          <div key={index}>
            <h3>{course.name}</h3>
            <p>{course.date}</p>
          </div>
        ))}
      </div>

      <div className="divider"></div>

      <div className="column">
        <h2>Book Details</h2>
        {books.map((book, index) => (
          <div key={index}>
            <h3>{book.name}</h3>
            <p>{book.price}</p>
          </div>
        ))}
      </div>

      <div className="divider"></div>

      <div className="column">
        <h2>Blog Details</h2>
        {blogs.map((blog, index) => (
          <div key={index}>
            <h3>{blog.title}</h3>
            <p>{blog.content}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
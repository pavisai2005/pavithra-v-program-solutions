import React, { useState } from 'react';

function Register() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: ''
  });

  const [error, setError] = useState('');

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { name, email, password } = formData;

    // Validations
    if (name.length < 5) {
      setError('Name should have at least 5 characters.');
    } else if (!email.includes('@') || !email.includes('.')) {
      setError('Email must contain "@" and "."');
    } else if (password.length < 8) {
      setError('Password should have at least 8 characters.');
    } else {
      setError('');
      alert('Registered Successfully!');
      setFormData({ name: '', email: '', password: '' });
    }
  };

  return (
    <div style={{ width: '300px', margin: '50px auto', textAlign: 'left' }}>
      <h2 style={{ color: 'red', textAlign: 'center' }}>Register Here!!!</h2>

      {error && (
        <div style={{ color: 'red', marginBottom: '10px', textAlign: 'center' }}>
          <strong>{error}</strong>
        </div>
      )}

      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label><br />
          <input
            type="text"
            name="name"
            value={formData.name}
            onChange={handleChange}
            style={{ width: '100%', marginBottom: '10px' }}
          />
        </div>
        <div>
          <label>Email:</label><br />
          <input
            type="text"
            name="email"
            value={formData.email}
            onChange={handleChange}
            style={{ width: '100%', marginBottom: '10px' }}
          />
        </div>
        <div>
          <label>Password:</label><br />
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            style={{ width: '100%', marginBottom: '10px' }}
          />
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default Register;
import React, { Component } from 'react';

class ComplaintRegister extends Component {
  constructor(props) {
    super(props);
    this.state = {
      employeeName: '',
      complaintText: ''
    };
  }

  handleChange = (e) => {
    const { name, value } = e.target;
    this.setState({ [name]: value });
  };

  generateReferenceNumber = () => {
    return 'REF' + Math.floor(100000 + Math.random() * 900000);
  };

  handleSubmit = (e) => {
    e.preventDefault();
    const { employeeName, complaintText } = this.state;

    if (!employeeName || !complaintText) {
      alert('Please fill in all fields.');
      return;
    }

    const refNumber = this.generateReferenceNumber();
    alert(
      `Complaint submitted successfully!\nRef No: ${refNumber}`
    );

    this.setState({
      employeeName: '',
      complaintText: ''
    });
  };

  render() {
    const { employeeName, complaintText } = this.state;

    return (
      <div style={{ width: '500px', margin: '50px auto', textAlign: 'left' }}>
        <h2 style={{ color: 'red', fontWeight: 'bold', textAlign: 'center' }}>
          Register your complaints here!!!
        </h2>

        <form onSubmit={this.handleSubmit}>
          <div style={{ marginBottom: '15px' }}>
            <label><strong>Name:</strong></label><br />
            <input
              type="text"
              name="employeeName"
              value={employeeName}
              onChange={this.handleChange}
              style={{ width: '100%', padding: '6px' }}
            />
          </div>

          <div style={{ marginBottom: '15px' }}>
            <label><strong>Complaint:</strong></label><br />
            <textarea
              name="complaintText"
              value={complaintText}
              onChange={this.handleChange}
              rows="4"
              style={{ width: '100%', padding: '6px' }}
            />
          </div>

          <button type="submit" style={{ padding: '8px 16px' }}>
            Submit
          </button>
        </form>
      </div>
    );
  }
}

export default ComplaintRegister;
import React from 'react';

class CountPeople extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      entryCount: 0,
      exitCount: 0,
    };
  }

  updateEntry = () => {
    this.setState((prevState) => ({
      entryCount: prevState.entryCount + 1,
    }));
  };

  updateExit = () => {
    this.setState((prevState) => ({
      exitCount: prevState.exitCount + 1,
    }));
  };

  render() {
    return (
      <div style={{ padding: '20px', fontFamily: 'Arial' }}>
        <h2>Mall Entry/Exit Counter</h2>
        <p><strong>People Entered:</strong> {this.state.entryCount}</p>
        <p><strong>People Exited:</strong> {this.state.exitCount}</p>
        <button onClick={this.updateEntry} style={{ marginRight: '10px' }}>
          Login
        </button>
        <button onClick={this.updateExit}>Exit</button>
      </div>
    );
  }
}

export default CountPeople;
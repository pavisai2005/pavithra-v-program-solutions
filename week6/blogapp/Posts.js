
import React from 'react';
 
class Posts extends React.Component {
  constructor(props) {
    super(props);
    // Step 5: Initialize state
    this.state = {
      posts: [],
      hasError: false
    };
  }

  // Step 6: Fetch data
  loadPosts() {
    fetch('(https://jsonplaceholder.typicode.com/posts')
      .then(response => response.json())
      .then(data => {
        this.setState({ posts: data });
      })
      .catch(error => {
        console.error('Error fetching posts:', error);
        this.setState({ hasError: true });
      });
  }

  // Step 7: Call API after mounting
  componentDidMount() {
    this.loadPosts();
  }

  //  Step 8: Render posts using <h3> and <p>
  render() {
    return (
      <div>
        <h2>Posts Component</h2>
        {this.state.posts.map(post => (
          <div key={post.id}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }

  //  Step 9: Catch and alert errors in component
  componentDidCatch(error, info) {
    alert('An error occurred in Posts component.');
    console.error('Caught error:', error, info);
    this.setState({ hasError: true });
  }
}

export default Posts;
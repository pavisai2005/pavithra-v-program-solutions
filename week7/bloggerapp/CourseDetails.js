import React from 'react';

function CourseDetails() {
  const showCourses = true;

  return (
    <div className="mystyle1">
      <h1>Course Details</h1>
      {
        showCourses
          ? (
              <>
                <p>React Basics</p>
                <p>NodeJS Advanced</p>
              </>
            )
          : <p>Courses are not available at the moment.</p>
      }
    </div>
  );
}

export default CourseDetails;
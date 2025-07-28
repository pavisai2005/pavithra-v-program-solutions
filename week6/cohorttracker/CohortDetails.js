// CohortDetails.js
import React from 'react';
import styles from './CohortDetails.module.css';

const CohortDetails = ({ cohort }) => {
  const isOngoing = cohort.currentStatus.trim().toLowerCase() === 'ongoing';

  return (
    <div className={styles.box}>
      <h3 className={isOngoing ? styles.greenText : styles.blueText}>
        {cohort.cohortCode} {cohort.technology}
      </h3>
      <dl>
        <dt>Started On</dt>
        <dd>{cohort.startDate}</dd>

        <dt>Current Status</dt>
        <dd>{cohort.currentStatus}</dd>

        <dt>Coach</dt>
        <dd>{cohort.coachName}</dd>

        <dt>Trainer</dt>
        <dd>{cohort.trainerName}</dd>
      </dl>
    </div>
  );
};

export default CohortDetails;
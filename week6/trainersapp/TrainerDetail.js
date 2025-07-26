import React from 'react';
import { useParams } from 'react-router-dom';

const mockTrainerData = [
  {
    id: '1',
    name: 'Syed Khaleelullah',
    email: 'khaleelullah@cognizant.com',
    phone: '97676516962',
    technology: '.NET',
    skills: ['C#', 'SQL Server', 'React', '.NET Core']
  },
  {
    id: '2',
    name: 'Jojo Jose',
    email: 'jojo@cognizant.com',
    phone: '91234567890',
    technology: 'Java',
    skills: ['Java', 'Spring Boot', 'Hibernate']
  },
  {
    id: '3',
    name: 'Elisa Jones',
    email: 'elisa@cognizant.com',
    phone: '9876543210',
    technology: 'Python',
    skills: ['Python', 'Django', 'Flask']
  }
];

const TrainerDetail = () => {
  const { id } = useParams();
  const trainer = mockTrainerData.find((t) => t.id === id);

  if (!trainer) return <h2>Trainer not found</h2>;

  return (
    <div>
      <h2>Trainer Details</h2>
      <h3>{trainer.name} ({trainer.technology})</h3>
      <p>{trainer.email}</p>
      <p>{trainer.phone}</p>
      <ul>
        {trainer.skills.map((skill, index) => (
          <li key={index}>{skill}</li>
        ))}
      </ul>
    </div>
  );
};

export default TrainerDetail;
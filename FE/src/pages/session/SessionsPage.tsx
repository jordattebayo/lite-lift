import { Link } from 'react-router-dom';
import SessionCard from '../../components/SessionCard';
import { Session } from '../../shared/types';

export function SessionsPage() {
  const sessions: Session[] = [
    {
      id: '1',
      date: '01-02-2024',
      notes: 'Tough one',
      user_id: '001',
      status: 'complete',
      group: 'A',
      workouts: [
        {
          id: '1',
          activity: 'squat',
          reps: 4,
          sets: 4,
          weight: {
            value: 135,
            unit: 'lbs',
          },
        },
        {
          id: '2',
          activity: 'deadlift',
          reps: 2,
          sets: 4,
          weight: {
            value: 195,
            unit: 'lbs',
          },
        },
      ],
    },
    {
      id: '2',
      date: '01-04-2024',
      notes: 'Light work',
      user_id: '001',
      status: 'complete',
      group: 'B',
      workouts: [
        {
          id: '3',
          activity: 'squat',
          reps: 4,
          sets: 4,
          weight: {
            value: 135,
            unit: 'lbs',
          },
        },
        {
          id: '4',
          activity: 'deadlift',
          reps: 2,
          sets: 4,
          weight: {
            value: 195,
            unit: 'lbs',
          },
        },
      ],
    },
    {
      id: '3',
      date: '01-06-2024',
      notes: 'Okay',
      user_id: '001',
      status: 'complete',
      group: 'Mixed',
      workouts: [
        {
          id: '5',
          activity: 'squat',
          reps: 4,
          sets: 4,
          weight: {
            value: 135,
            unit: 'lbs',
          },
        },
        {
          id: '6',
          activity: 'deadlift',
          reps: 2,
          sets: 4,
          weight: {
            value: 195,
            unit: 'lbs',
          },
        },
      ],
    },
    {
      id: '4',
      date: '01-08-2024',
      notes: 'Okay okay',
      user_id: '001',
      status: 'complete',
      group: 'A',
      workouts: [
        {
          id: '7',
          activity: 'squat',
          reps: 4,
          sets: 4,
          weight: {
            value: 135,
            unit: 'lbs',
          },
        },
        {
          id: '8',
          activity: 'deadlift',
          reps: 2,
          sets: 4,
          weight: {
            value: 195,
            unit: 'lbs',
          },
        },
      ],
    },
  ];

  console.log(location);
  return (
    <>
      <h2>Sessions</h2>
      <div className="flex-row">
        {sessions.map((session) => {
          return <SessionCard session={session} key={session.id} />;
        })}
        <Link to={`new`}>New Session</Link>
      </div>
    </>
  );
}

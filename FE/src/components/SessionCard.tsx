import { Link } from 'react-router-dom';
import { Session } from '../shared/types';

function SessionCard({ session }: { session: Session }) {
  return (
    <div key={session.id} className="card">
      <div>{session.date}</div>
      <div>{session.status}</div>
      <div>Workout: {session.group}</div>
      <div>Notes: {session.notes}</div>
      <Link to={`/session/${session.id}`}>Edit Session</Link>
    </div>
  );
}

export default SessionCard;

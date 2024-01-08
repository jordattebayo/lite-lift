import { Outlet, Link } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <main>
      <h1 className="title">Lite Lift</h1>
      <nav className="flex-row justify-center">
        <Link to={`session`}>Sessions</Link>
        <Link to={`account`}>My Account</Link>
      </nav>

      <Outlet />
    </main>
  );
}

export default App;

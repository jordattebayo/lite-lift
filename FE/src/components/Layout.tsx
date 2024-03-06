import { Outlet, Link } from 'react-router-dom';

function Layout() {
  return (
    <>
      <Link to={`/`} className="lowkey-link">
        <h1 className="title">lite lift</h1>
      </Link>
      <nav className="flex-row justify-center">
        <Link to={`session`}>Sessions</Link>
        <Link to={`account`}>My Account</Link>
      </nav>
      <main>
        <Outlet />
      </main>
    </>
  );
}

export default Layout;

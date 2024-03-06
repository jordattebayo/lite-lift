import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from './pages/App.tsx';
import Layout from './components/Layout.tsx';
import ErrorPage from './pages/ErrorPage.tsx';
import './index.css';
import SessionPage from './pages/session/SessionPage.tsx';
import { SessionsPage } from './pages/session/SessionsPage.tsx';
import { AccountPage } from './pages/account/Account.tsx';

const router = createBrowserRouter([
  {
    element: <Layout />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: '/',
        element: <App />,
        errorElement: <ErrorPage />,
      },
      {
        path: 'session',
        element: <SessionsPage />,
        errorElement: <ErrorPage />,
      },
      {
        path: 'session/:sessionId',
        element: <SessionPage />,
        errorElement: <ErrorPage />,
      },
      {
        path: 'session/new',
        element: <SessionPage new />,
        errorElement: <ErrorPage />,
      },
      {
        path: 'account',
        element: <AccountPage />,
        errorElement: <ErrorPage />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);

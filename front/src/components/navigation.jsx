import React from 'react';
import { Link } from 'react-router-dom';

const Navigation = () => {
  return (
    <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div className="container-fluid">
        <div className="collapse navbar-collapse" id="navbarCollapse">
          <Link to="/" className="navbar-brand" >Home</Link>
          <Link to="/courses" className="navbar-brand" >Courses</Link>
        </div>

        <div>
          <ul className="navbar-nav me-auto mb-2 mb-md-0">
            <li className="naw-item">
              <Link to="/user" className="navbar-brand">My Account</Link>
            </li>
            <li className="nav-item">
              <Link to="/login" className="navbar-brand" >Login</Link>
            </li>
            <li className="nav-item">
              <Link to="/registeration" className="navbar-brand">Sign up</Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  )
}

export default Navigation;
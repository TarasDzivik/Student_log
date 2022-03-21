import React, { useState } from 'react';
import PropTypes from 'prop-types';
import loginUser from '../../models/LoginUser';

// export default function Login({setToken}) {
export const LoginPage= () => {
  const [userEmail, setUserEmail] = useState('');
  const [password, setPassword] = useState('');


  // const handleSubmit = async e => {
  //   e.preventDefault();
  //   const token = await loginUser({
  //     userEmail,
  //     password
  //   });
  //   setToken(token);
  // }

  return (
    // <form className="form-floating" onSubmit={handleSubmit}>
    <form className="form-floating">
      <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
      <div>
        <input
          id="input-fields" type="email"
          className="form-control"
          placeholder="name@example.com"
          onChange={e => setUserEmail(e.target.value)}
        />
      </div>
      <div>
        <input
          id="input-fields"
          type="password"
          className="form-control"
          placeholder="Password"
          onChange={e => setPassword(e.target.value)}
        />
      </div>
      <div className="form-check">
        <label>
          <h6>
            <input
              class="form-check-input"
              type="checkbox"
            />
            Remember me
          </h6>
        </label>
      </div>
      <button
        id="Button-Ok"
        className="w-100 btn btn-lg btn-primary"
        type="submit">
        Sign in
      </button>
    </form>
  )
}

// Login.propTypes = {
//   setToken: PropTypes.func.isRequired
// }
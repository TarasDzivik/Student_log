import React from 'react';
import { useState } from 'react';
import { getAge } from '../../Services/AgeCalculator';
import { Home, HomePage } from '../Home/HomePage';
import { Alert, Button, DatePicker, message } from 'antd';

export const RegistrationPage = () => {
  const [name, setName] = useState('');
  const [lastName, setLastName] = useState('')
  const [email, setEmail] = useState('');
  const [password, setPass] = useState('');
  const [rePassword, repeatPass] = useState('');
  const [age, setAge] = useState('');

  // formik`ом або redux`ом зробити хендлер полей для реэстрації 
  // для об'єднання значень values в один. 
  // потім викликати хуки axios'ом так як в UserPage
  // стилі для кожної сторінки прописувати окремо в папках тих сторінок
  // а замість <div> прописувати <pageStyle_якийсь> 
  const Registration = (values) => {

  }
  const [date, setDate] = useState('');

  const handleChange = value => {getAge(value)
    setDate(value);
  };


  return (
    <form onSubmit={HomePage}>
      <div className="form-floating mb-3">
        <h1 className="h1 mb-3 fw-nornal">Please register</h1>
        <div >
          <input
            id="input-fields"
            className="form-control"
            placeholder="Name"
            required type="value"
            onChange={e => setName(e.target.value)}
          />
          <input
            id="input-fields"
            className="form-control"
            placeholder="LastName"
            required type="value"
            onChange={e => setLastName(e.target.value)}
          />
          <input
            id="input-fields"
            className="form-control"
            placeholder="Email adress"
            required type="email"
            onChange={e => setEmail(e.target.value)}
          />
          <input
            id="input-fields"
            className="form-control"
            placeholder="Create password"
            required type="password"
            onChange={e => setPass(e.target.value)}
          />
          <input
            id="input-fields"
            className="form-control"
            placeholder="Repeat password"
            required type="password"
            onChange={e => repeatPass(e.target.value)}
          />

          <input
            id="Age"
            className="form-control"
            placeholder="Enter your age"
            required type="number"
            onChange={e => setAge(e.target.value)}
          />
          <button
            id="Button-SignUp"
            className="w-100 btn btn-lg btn-primary"
            type='submit'>
            Sign Up
          </button>
        </div>
      </div>
    </form>
  );
}
import React, { useState } from 'react';
import { Alert, Button, DatePicker, message } from 'antd';
import 'antd/dist/antd.css';
import { useEffect } from 'react/cjs/react.production.min';
import { getAge } from '../../Services/AgeCalculator';

export const CoursesPage = () => {
  const [date, setDate] = useState('');

  const handleChange = value => {
    message.info(`Selected Date: ${value ? value.format('DD-MM-YYYY') : 'None'}`);
    setDate(value);
  };
  console.log(getAge(date)); // test
  return (
    <div style={{ width: 400, margin: '100px auto' }}>
      <DatePicker onChange={value => handleChange(value)} />
    </div>
  )
}
import React, { useState } from 'react';
import { Alert, Button, DatePicker, message } from 'antd';
import 'antd/dist/antd.css';

export const CoursesPage = () => {
  const [date, setDate] = useState('');
  const handleChange = value => {
    message.info(`Selected Date: ${value ? value.format('YYYY-MM-DD') : 'None'}`);
    setDate(value);
  };
  return (
    <div style={{ width: 400, margin: '100px auto' }}>
      <DatePicker onChange={value => handleChange(value)} />
      {/* <div style={{ marginTop: 20 }}>
          <Alert message="Selected Date" description={date
            ? date.format('YYYY-MM-DD') : 'None'} />
        </div> */}
    </div>
  )
}
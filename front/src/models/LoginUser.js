// import React, { useState, useEffect } from 'react';
// import { LOGIN_URL } from "../Services/UrlStorage";
// import axios from 'axios';

// export const loginUser = (credentials) => {
//     useEffect(async () => {
//         try {
//             const login = (await axios(LOGIN_URL, {
//                 method: 'POST',
//                 headers: {
//                     'Content-Type': 'application/json'
//                 },
//                 body: JSON.stringify(credentials)
//             })
//                 .then(data => data.json()));
//         } catch (e) {
//             console.error(e);
//         }
//     }, []);
//     return (
//         <>

//         </>
//     )
// }
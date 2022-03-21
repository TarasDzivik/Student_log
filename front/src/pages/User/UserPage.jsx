import axios from "axios";
import React, { useEffect } from "react";
import { USER_URL } from "../../Services/UrlStorage"

export const UserPage = () => {
    
    useEffect(async () => {
        try {
            const allUsers = (await axios.get(USER_URL)).data;
            console.log(allUsers);

        }
        catch (e) {
            console.error(e);
        }
    }, [])

    return (
        <>
            <h1>
                Testing CORS policy
            </h1>
            <div>
                
            </div>
        </>
    )
};
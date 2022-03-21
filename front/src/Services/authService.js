import React from "react";
import axios from 'axios';
import { REGISTER_URL, LOGIN_URL } from "./UrlStorage";

export class authService{
    static registerUser(model){
        return axios.post(REGISTER_URL, model);
    }
    static loginUser(model){
        return axios.post(LOGIN_URL, model);
    }
}

import axios from "axios";

const baseURL = 'https://localhost:44382/api/';

export default {
    instance : () => {
        var token = window.localStorage.getItem('token');
        return axios.create({
            baseURL: baseURL,
            headers: {
              Authorization: `Bearer ${token}`
            }
          })
    }
}
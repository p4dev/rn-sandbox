import axios from "axios";

export const axiosWrapper = axios.create({
  baseURL: "http:/xam4.znl-qa01.com:50001",
  headers: {
    Authorization: "Basic dGVzdDp0ZXN0",
  },
});



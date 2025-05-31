import axios from "axios";

export const Api = axios.create({
	baseURL: "https://integramech-production.up.railway.app",
});

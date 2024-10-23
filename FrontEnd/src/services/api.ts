import axios from "axios";

export const Api = axios.create({
	baseURL: "https://mech-api.zaqbit.com",
});

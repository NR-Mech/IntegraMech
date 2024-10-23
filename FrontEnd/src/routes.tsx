import { createBrowserRouter } from "react-router-dom";
import { Dashbord } from "./pages/app/dashbord/Dashbord";
import { Medicos } from "./pages/app/medicos/Medicos";
import { AppLayout } from "./pages/_layout/app";

export const router = createBrowserRouter([
	{
		path: "/",
		element: <AppLayout />,
		children: [
			{ path: "/", element: <Dashbord /> },
			{ path: "/medicos", element: <Medicos /> },
		],
	},
]);

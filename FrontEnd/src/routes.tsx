import { createBrowserRouter } from "react-router-dom";
import { Dashbord } from "./pages/app/dashbord/Dashbord";
import { Medicos } from "./pages/app/medicos/Medicos";
import { AppLayout } from "./pages/_layout/app";
import { Pacientes } from "./pages/app/pacientes/Pacientes";
import { Exames } from "./pages/app/exames/Exames";
import { Medicacao } from "./pages/app/medicacao/Medicacao";
import { Triagens } from "./pages/app/triagens/Triagens";

export const router = createBrowserRouter([
	{
		path: "/",
		element: <AppLayout />,
		children: [
			{ path: "/", element: <Dashbord /> },
			{ path: "/medicos", element: <Medicos /> },
			{path: "/pacientes", element: <Pacientes />},
			{path: "/exames", element: <Exames />},
			{path: "/medicacao", element: <Medicacao />},
			{path: "/triagens", element: <Triagens />},
		],
	},
]);

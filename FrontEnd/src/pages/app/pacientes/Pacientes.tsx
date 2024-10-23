/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useEffect, useState } from "react";
import { Api } from "../services/api";

export function Pacientes() {
	const [data, setData] = useState([]);

	useEffect(() => {
		Api.get("/pacientes")
			.then((response) => {
				setData(response.data);
			})
			.catch((error) => {
				console.log(error);
			});
	}, []);

	return (
		<div className="ml-64 p-8">
			<h1 className="text-3xl font-roboto font-bold">Pacientes</h1>
			{data &&
				data.map((paciente: any, index) => {
					return (
						<div key={index}>
							<p>{paciente.nome}</p>
						</div>
					);
				})}
		</div>
	);
}

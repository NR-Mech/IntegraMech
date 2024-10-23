import { Button } from "@/components/ui/button";
import { Helmet } from "react-helmet-async";

export function Dashbord() {
	return (
		<>
			<Helmet title="Dashbord" />
			<div className="mt-3">
				<div className="flex h-56 bg-primary mt-10 p-8 justify-between">
					<h1 className=" text-3xl font-bold">Pacientes</h1>
					<Button variant="secondary" size="lg">
						<span>NOVO PACIENTE</span>
					</Button>
				</div>
			</div>
		</>
	);
}

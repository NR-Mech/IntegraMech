import { Button } from "@/components/ui/button";
import {
	ArrowCircleUp,
	Clock,
	ListChecks,
	UserList,
} from "@phosphor-icons/react";
import { Helmet } from "react-helmet-async";

export function Dashbord() {
	return (
		<>
			<Helmet title="Dashbord" />
			<div className="mt-3">
				<div className="relative flex flex-col h-56 bg-primary mt-10 p-8">
					<div className="flex justify-between">
					<h1 className=" text-3xl font-bold">Pacientes</h1>
					<Button variant="secondary" size="lg">
						<span>NOVO PACIENTE</span>
					</Button>
					</div>
				<div className="mt-10 flex gap-5 justify-end p-2">
					<div className="w-64 h-44 bg-zinc-900 border rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<Clock size={26} />
							<p className="font-semibold text-xl">Em Espera</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl font-bold">32</h1>
						</div>
					</div>
					<div className="w-64 h-44 bg-zinc-900 border rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<UserList size={26} />
							<p className="font-semibold text-xl">Total</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl font-bold">48</h1>
						</div>
					</div>
					<div className="w-64 h-44 bg-zinc-900 border rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<ListChecks size={26} />
							<p className="font-semibold text-xl">Atendidos</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl font-bold">16</h1>
						</div>
					</div>
					<div className="w-64 h-44 bg-zinc-900 border rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<ArrowCircleUp size={26} />
							<p className="font-semibold text-xl">Produtividade</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl font-bold">33%</h1>
						</div>
						</div>
					</div>
				</div>
			</div>
		</>
	);
}

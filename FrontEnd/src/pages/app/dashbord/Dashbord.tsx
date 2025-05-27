import { Button } from "@/components/ui/button";
import {
	FilePlusIcon,
	UserCheckIcon,
	UserPlusIcon,
	ClockIcon,
	UsersIcon
} from "@phosphor-icons/react";
import { Helmet } from "react-helmet-async";

export function Dashbord() {
	return (
		<>
			<Helmet title="Início" />
			<div className="mt-3 font-mulish">
				<div className="relative flex flex-col h-56 bg-p3 mt-10 p-8">
					<div className="flex justify-between">
					<h1 className=" text-3xl font-bold text-white">Início</h1>
					<div className="flex items-center gap-5">
					<Button className="rounded-xl" variant="secondary">
						<FilePlusIcon size={22} weight="fill" />
						<span>REALIZAR TRIAGEM</span>
					</Button>
					<Button className="rounded-xl" variant="primary">
						<UserPlusIcon size={22} weight="fill" />
						<span>ADICIONAR PACIENTE</span>
					</Button>
					</div>
					</div>
				<div className="mt-10 flex gap-5 justify-end">
					<div className="w-60 h-44 bg-background shadow-lg rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<ClockIcon size={28} weight="fill" className="text-title" />
							<p className="font-semibold text-xl text-title">Em Espera</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl text-title font-bold">0</h1>
						</div>
					</div>
					<div className="w-60 h-44 bg-background shadow-lg rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<UsersIcon size={28} weight="fill" className="text-title" />
							<p className="font-semibold text-xl text-title">Total</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl text-title font-bold">0</h1>
						</div>
					</div>
					<div className="w-60 h-44 bg-background shadow-lg rounded-3xl p-6 z-10">
						<div className="flex gap-2">
							<UserCheckIcon size={28} weight="fill" className="text-title" />
							<p className="font-semibold text-xl text-title">Atendidos</p>
						</div>
						<div className="mt-10">
							<h1 className="text-5xl text-title font-bold">0</h1>
						</div>
					</div>
					</div>
				</div>
			</div>
		</>
	);
}

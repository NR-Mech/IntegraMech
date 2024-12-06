import { NavBar } from "@/components/native/NavBar";
import { SideBar } from "@/components/native/SideBar";
import { Outlet } from "react-router-dom";

export function AppLayout() {
	return (
		<div className="flex w-screen min-h-screen">
			<SideBar />
			<div className="flex flex-1 flex-col mt-4 w-full">
				<NavBar />
				<Outlet />
			</div>
		</div>
	);
}

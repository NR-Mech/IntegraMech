import { MagnifyingGlass } from "@phosphor-icons/react";
import { Button } from "../ui/button";
import { Input } from "../ui/input";
import { SidebarTrigger } from "../ui/sidebar";
import { ThemeToggle } from "../theme/theme-toggle";

export function NavBar() {
	return (
		<div className="flex h-10 gap-2 items-center mr-4 ml-2">
			<SidebarTrigger size="sm" />
			<div className="flex gap-2 h-10 w-96">
				<Input placeholder="Pesquisar" />
				<Button className="">
					<MagnifyingGlass size={24} />
				</Button>
			</div>
			<div className="flex ml-auto">
				<ThemeToggle />
			</div>
		</div>
	);
}

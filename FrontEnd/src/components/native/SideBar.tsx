import {
	Sidebar,
	SidebarContent,
	SidebarGroup,
	SidebarGroupContent,
	SidebarGroupLabel,
	SidebarMenu,
	SidebarMenuButton,
	SidebarMenuItem,
} from "@/components/ui/sidebar";
import {
	House,
	User,
	Bandaids,
	FirstAidKit,
	Stethoscope,
} from "@phosphor-icons/react";

export function SideBar() {
	return (
		<Sidebar className="fixed left-0 top-0">
			<SidebarContent>
				<SidebarGroup>
					<SidebarGroupLabel>Mech</SidebarGroupLabel>
					<SidebarGroupContent>
						<SidebarMenu>
							<SidebarMenuItem key="a">
								<SidebarMenuButton asChild>
									<a href="/">
										<House size={18} />
										<span>Dashboard</span>
									</a>
								</SidebarMenuButton>
							</SidebarMenuItem>
							<SidebarMenuItem key="a">
								<SidebarMenuButton asChild>
									<a href="/pacientes">
										<User size={18} />
										<span>Pacientes</span>
									</a>
								</SidebarMenuButton>
							</SidebarMenuItem>
							<SidebarMenuItem key="a">
								<SidebarMenuButton asChild>
									<a href="/medicacao">
										<Bandaids size={18} />
										<span>Medicação</span>
									</a>
								</SidebarMenuButton>
							</SidebarMenuItem>
							<SidebarMenuItem key="a">
								<SidebarMenuButton asChild>
									<a href="/exames">
										<FirstAidKit size={18} />
										<span>Exames</span>
									</a>
								</SidebarMenuButton>
							</SidebarMenuItem>
							<SidebarMenuItem key="a">
								<SidebarMenuButton asChild>
									<a href="/medicos">
										<Stethoscope size={18} />
										<span>Médicos</span>
									</a>
								</SidebarMenuButton>
							</SidebarMenuItem>
						</SidebarMenu>
					</SidebarGroupContent>
				</SidebarGroup>
			</SidebarContent>
		</Sidebar>
	);
}

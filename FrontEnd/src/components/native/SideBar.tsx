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
  FileText,
} from "@phosphor-icons/react";
import MechLogo from '@/mech-logo.svg';
import { useLocation } from 'react-router-dom';

export function SideBar() {
  const location = useLocation();

  const isActive = (href: string) => {
    return location.pathname === href;
  };

  return (
    <Sidebar>
      <SidebarContent>
        <SidebarGroup>
          <SidebarGroupLabel className="font-bold font-raleway text-3xl mb-3 mt-3 text-title flex items-center gap-3 tracking-wider">
            <img src={MechLogo} alt="Logo da MECH" />
            MECH
          </SidebarGroupLabel>
          <SidebarGroupContent className="mt-10">
            <SidebarMenu className="space-y-3">
              <SidebarMenuItem key="inicio">
                <SidebarMenuButton 
                  className={`py-6 rounded-2xl text-lg font-medium transition-colors duration-300 ${
                    isActive('/') 
                      ? 'bg-p3 text-white pointer-events-none' 
                      : ''
                  }`} 
                  asChild
                >
                  <a href="/">
                    <House size={22} weight="fill" className={isActive('/') ? 'text-white' : ''} />
                    <span className="text-lg font-mulish">Início</span>
                  </a>
                </SidebarMenuButton>
              </SidebarMenuItem>
              <SidebarMenuItem key="triagens">
                <SidebarMenuButton 
                  className={`py-6 rounded-2xl text-lg font-medium transition-colors duration-300 ${
                    isActive('/triagens') 
                      ? 'bg-p3 text-white pointer-events-none' 
                      : ''
                  }`} 
                  asChild
                >
                  <a href="/triagens">
                    <FileText size={22} weight="fill" className={isActive('/triagens') ? 'text-white' : ''} />
                    <span className="text-lg font-mulish">Triagens</span>
                  </a>
                </SidebarMenuButton>
              </SidebarMenuItem>
              <SidebarMenuItem key="pacientes">
                <SidebarMenuButton 
                  className={`py-6 rounded-2xl text-lg font-medium transition-colors duration-300 ${
                    isActive('/pacientes') 
                      ? 'bg-p3 text-white pointer-events-none' 
                      : ''
                  }`} 
                  asChild
                >
                  <a href="/pacientes">
                    <User size={22} weight="fill" className={isActive('/pacientes') ? 'text-primary-500' : 'text-gray-400'} />
                    <span className="text-lg font-mulish">Pacientes</span>
                  </a>
                </SidebarMenuButton>
              </SidebarMenuItem>
              <SidebarMenuItem key="medicacao">
                <SidebarMenuButton 
                  className={`py-6 rounded-2xl text-lg font-medium transition-colors duration-300 ${
                    isActive('/medicacao') 
                      ? 'bg-p3 text-white pointer-events-none' 
                      : ''
                  }`} 
                  asChild
                >
                  <a href="/medicacao">
                    <Bandaids size={22} weight="fill" className={isActive('/medicacao') ? 'text-primary-500' : 'text-gray-400'} />
                    <span className="text-lg font-mulish">Medicação</span>
                  </a>
                </SidebarMenuButton>
              </SidebarMenuItem>
              <SidebarMenuItem key="exames">
                <SidebarMenuButton 
                  className={`py-6 rounded-2xl text-lg font-medium transition-colors duration-300 ${
                    isActive('/exames') 
                      ? 'bg-p3 text-white pointer-events-none' 
                      : ''
                  }`} 
                  asChild
                >
                  <a href="/exames">
                    <FirstAidKit size={22} weight="fill" className={isActive('/exames') ? 'text-primary-500' : 'text-gray-400'} />
                    <span className="text-lg font-mulish">Exames</span>
                  </a>
                </SidebarMenuButton>
              </SidebarMenuItem>
              <SidebarMenuItem key="medicos">
                <SidebarMenuButton 
                  className={`py-6 rounded-2xl text-lg font-medium transition-colors duration-300 ${
                    isActive('/medicos') 
                      ? 'bg-p3 text-white pointer-events-none' 
                      : ''
                  }`} 
                  asChild
                >
                  <a href="/medicos">
                    <Stethoscope size={22} weight="fill"  className={isActive('/medicos') ? 'text-primary-500' : 'text-gray-400'} />
                    <span className="text-lg font-mulish">Médicos</span>
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
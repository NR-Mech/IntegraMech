import "./index.css";
import { RouterProvider } from "react-router-dom";
import { router } from "./routes";
import { Helmet, HelmetProvider } from "react-helmet-async";
import { ThemeProvider } from "./components/theme/theme-provider";
import { SidebarProvider } from "./components/ui/sidebar";

export function App() {
	return (
		<SidebarProvider>
			<HelmetProvider>
				<ThemeProvider storageKey="mech-theme" defaultTheme="dark">
					<Helmet titleTemplate="%s | Mech" />
					<RouterProvider router={router} />
				</ThemeProvider>
			</HelmetProvider>
		</SidebarProvider>
	);
}

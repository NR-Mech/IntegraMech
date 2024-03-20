import React from "react";
import { SideBar } from "./components/SideBar";
import { Outlet } from "react-router-dom";

export function App() {
  return (
    <div className="flex flex-row gap-3">
      <SideBar/>
      <Outlet/>
    </div>
  )
}




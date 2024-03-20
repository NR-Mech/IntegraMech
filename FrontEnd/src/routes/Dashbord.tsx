import React from "react";
import { NavBar } from "../components/NavBar";
import { Body } from "../components/Body";

export function Dashbord () {
    return (
            <div className="flex flex-col">
                <NavBar/>
                <Body/>
            </div>
    )
}
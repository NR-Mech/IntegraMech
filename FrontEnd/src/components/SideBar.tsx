import React from 'react'
import { FaHouse, FaCalendarDays, FaAlignJustify } from "react-icons/fa6";
import { GoPeople } from "react-icons/go";
import { useNavigate } from 'react-router-dom';



export function SideBar() {

    const navigate = useNavigate();

    return (
        <div className="flex w-64 h-screen font-roboto bg-sky-950 fixed top-0 left-0 bottom-0 p-6 flex-col">
            <h2 className="text-3xl font-roboto font-bold text-white">Mech</h2>
            <div className=''>
                <div className='flex flex-row items-center gap-2'>
                    <FaHouse className="w-4 h-4 text-gray-400"/>
                    <button 
                        onClick={() => {navigate('/')}}
                        className="items-center w-12 h-12 rounded-full text-gray-400">Dashbord
                    </button>
                </div>
                <div className='flex flex-row items-center gap-2'>
                    <GoPeople className="w-4 h-4 text-gray-400"/>
                    <button 
                        onClick={() => {navigate('/pacientes')}} 
                        className="items-center w-12 h-12 rounded-full text-gray-400">Pacientes
                    </button>
                </div>
                <div className='flex flex-row items-center gap-2'>
                    <FaCalendarDays className="w-4 h-4 text-gray-400"/>
                    <button className="items-center w-12 h-12 rounded-full text-gray-400">Medicação</button>
                </div>
                <div className='flex flex-row items-center gap-2'>
                    <FaAlignJustify className="w-4 h-4 text-gray-400"/>
                    <button 
                    onClick={() => {navigate('/exames')}}
                    className="items-center w-12 h-12 rounded-full text-gray-400">Exames
                    </button>
                </div>
                <div className='flex flex-row items-center gap-2'>
                    <FaAlignJustify className="w-4 h-4 text-gray-400"/>
                    <button 
                    onClick={() => {navigate('/medicos')}}
                    className="items-center w-12 h-12 rounded-full text-gray-400">Médicos
                    </button>
                </div>
            </div>

        </div>
    )
}
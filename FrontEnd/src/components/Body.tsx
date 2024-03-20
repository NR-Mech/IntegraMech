/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useEffect, useState } from "react";
import { PiSuitcaseSimpleLight } from "react-icons/pi";
import { FaListUl } from "react-icons/fa6";
import { GoPeople } from "react-icons/go";
import { FaRegArrowAltCircleUp } from "react-icons/fa";
import { Api } from "../services/api";
import { CiEdit } from "react-icons/ci";


export function Body() {
    const [data, setData] = useState([])

    useEffect(() => {
        Api.get('/pacientes').then((response) => {
            setData(response.data)
            console.log(response.data)
        }).catch((error) => {
            console.log(error)
        })
    }, [])


    return (
        <div className="w-screen ml-64">
            <div className="flex h-48 bg-blue-600 mt-3 p-8 justify-between">
                <h1 className="text-white font-roboto font-bold text-3xl ">Pacientes</h1>
                <button className="w-32 h-11 bg-white rounded-lg text-blue-400 mr-72 font-roboto text-sm">Novo Paciente</button>
            </div>

            <div className="flex justify-center flex-row absolute top-0 mt-48 ml-64 gap-8 font-roboto">
                <div className="w-64 h-40 rounded-lg shadow-md bg-slate-100 p-6">
                    <div className="flex flex-row items-center">
                        <h3 className="text-xl">Em espera</h3>
                        <PiSuitcaseSimpleLight className="w-5 h-5 ml-20"/>
                    </div>
                    <h1 className="text-5xl font-bold mt-4">18</h1>
                </div>
                <div className="w-64 h-40 rounded-lg shadow-md bg-slate-100 p-6">
                    <div className="flex flex-row items-center">
                        <h3 className="text-xl">Total</h3>  
                        <FaListUl className="w-5 h-5 ml-36"/>
                    </div>
                    <h1 className="text-5xl font-bold mt-4">132</h1>    
                </div>
                <div className="w-64 h-40 rounded-lg shadow-md bg-slate-100 p-6">
                    <div className="flex flex-row items-center">  
                        <h3 className="text-xl">Atendidos Hoje</h3>  
                        <GoPeople className="w-5 h-5 ml-12"/>     
                    </div>
               
                    <h1 className="text-5xl font-bold mt-4">12</h1>
                </div>
                <div className="w-64 h-40 rounded-lg shadow-md bg-slate-100 p-6">
                    <div className="flex flex-row items-center">
                        <h3 className="text-xl">Produtividade</h3>
                        <FaRegArrowAltCircleUp className="w-5 h-5 ml-16"/>
                    </div>                   
                    <h1 className="text-5xl font-bold mt-4">76%</h1>
                </div>
            </div>

            <div className="flex flex-col gap-5 w-1/3 h-96 bg-slate-100 shadow-md mt-56 ml-24 rounded-lg justify-center items-center">
            <h2>Resumo dos Pacientes</h2>
            <table className="table-auto">
        <thead>
            <tr className="bg-slate-300">
                <th className="px-4 py-2 font-roboto">Nome</th>
                <th className="px-4 py-2 font-roboto">Idade</th>
                <th className="px-4 py-2 font-roboto">Gênero</th>
            </tr>
        </thead>
        <tbody>
            {data && data.map((paciente: any, index) => {
                return(
                    <tr key={index}>
                        <td className="border px-4 py-2 font-semibold font-roboto1">{paciente.nome}</td>
                        <td className="border px-4 py-2">
                            {(() => {
                                const birthDate = new Date(paciente.dataDeNascimento);
                                const currentYear = new Date().getFullYear();
                                const birthYear = birthDate.getFullYear();
                                const age = currentYear - birthYear;
                                return age;
                            })()}
                        </td>
                        <td className="border px-4 py-2">{paciente.genero}</td>
                        <button><CiEdit className="w-6 h-6" /></button>
                    </tr>
                )
            })}
        </tbody>

    </table>
            </div>
        </div>
    )
}
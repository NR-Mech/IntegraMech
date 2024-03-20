/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useEffect, useState } from "react" 
import { Api } from "../services/api"


export function Medicos() {
    const [data, setData] = useState([])

    useEffect(() => {
        Api.get('/medicos').then((response) => {
            setData(response.data)
            console.log(response.data)
        }).catch((error) => {
            console.log(error)
        })
    }, [])

    return(
        <div className="ml-64 p-8">
<table className="table-auto">
        <thead>
            <tr className="bg-slate-300">
                <th className="px-4 py-2 font-roboto">Médico</th>
                <th className="px-4 py-2 font-roboto">Especialidades</th>
            </tr>
        </thead>
        <tbody>
            {data && data.map((medico: any, index) => {
                return(
                    <tr key={index}>
                        <td className="border px-4 py-2 font-semibold font-roboto1">{medico.nome}</td>
                        <td className="border px-4 py-2">{medico.especialidades.toString().replaceAll(',', ', ')}</td>
                    </tr>
                )
            })}
        </tbody>

    </table>
        </div>
    )
}
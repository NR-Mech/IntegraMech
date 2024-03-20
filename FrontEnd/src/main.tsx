import React from 'react'
import ReactDOM from 'react-dom/client'
import {App} from './App.tsx'
import './index.css'

import {
  createBrowserRouter,
  RouterProvider
} from 'react-router-dom'

import { Dashbord } from './routes/Dashbord.tsx'
import { Pacientes } from './routes/Pacientes.tsx'
import { Exames } from './routes/Exames.tsx'
import { Medicos } from './routes/Medicos.tsx'

const router = createBrowserRouter([
  { path: '/', 
  element: <App/>,
  children: [
    { path: '/', element: <Dashbord/> },
    { path: '/pacientes', element: <Pacientes/> },
    { path: '/exames', element: <Exames/> },
    {path: '/medicos', element: <Medicos/>}
  ] },
 
])

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router}/>

  </React.StrictMode>,
)

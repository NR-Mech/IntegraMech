import { Helmet } from "react-helmet-async";
/* import {
  Table,
  TableBody,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"; */
import { Dialog, DialogTrigger } from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { PacientesTableRow } from "./Paciente-Table-Row";
import { PlusCircleIcon } from "@phosphor-icons/react";

export function Pacientes() {
  return (
    <>
      <Helmet title="Pacientes" />
      <div className="flex flex-col gap-4 font-mulish mt-[3.25rem]">
        <div className="flex flex-col bg-p3 p-8">
          <div className="flex justify-between items-center">
            <h1 className="text-3xl font-bold text-white">Pacientes</h1>
            <Dialog>
              <DialogTrigger asChild>
                <Button variant="primary" className="rounded-xl">
                  <PlusCircleIcon size={22} weight="fill" />
                  ADICIONAR PACIENTE
                </Button>
              </DialogTrigger>
              {/* <MedicosCreate /> */}
            </Dialog>
          </div>
        </div>

          <div className="flex w-full items-center justify-between px-8 mt-12">
            <h2 className="text-title font-semibold text-2xl font-raleway">Todos os Pacientes</h2>
          <div className="flex items-center gap-20">

          </div>
        </div>

{/*         <div className="space-y-2.5 px-4 pb-4 bg-white rounded-b-lg shadow-md">
          <div className="rounded-md border">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className="w-[700px]">Nome</TableHead>
                  <TableHead className="w-[140px]">Telefone</TableHead>
                  <TableHead className="w-[140px]">Médico</TableHead>
                  <TableHead>Especialidade</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                <PacientesTableRow />
              </TableBody>
            </Table>
          </div>
        </div> */}
      </div>
    </>
  );
}
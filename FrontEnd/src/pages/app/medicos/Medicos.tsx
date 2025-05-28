import { Helmet } from "react-helmet-async";
import {
  Table,
  TableBody,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { MedicosTableRow } from "./Medicos-Table-Row";
import { Dialog, DialogTrigger } from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { MedicosCreate } from "./Medicos-Create";
import { PlusCircleIcon } from "@phosphor-icons/react";

export function Medicos() {
  return (
    <>
      <Helmet title="Médicos" />

      <div className="flex flex-col gap-4 mt-[3.25rem] font-mulish">
        <div className="flex flex-col bg-p3 p-8">
          <div className="flex justify-between items-center">
            <h1 className="text-3xl font-bold text-white">Médicos</h1>
            <Dialog>
              <DialogTrigger asChild>
                <Button variant="primary" className="rounded-xl">
                  <PlusCircleIcon size={22} weight="fill" />
                  <span className="hidden md:inline">ADICIONAR MÉDICO</span>
                </Button>
              </DialogTrigger>
              <MedicosCreate />
            </Dialog>
          </div>
        </div>

          <div className="flex w-full items-center justify-between px-8 mt-12">
            <h2 className="text-title font-semibold text-2xl font-raleway">Todos os Médicos</h2>
          <div className="flex items-center gap-20">

          </div>
        </div>

        <div className="space-y-2.5 px-8 pb-4">
          <div>
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className="w-[140px] text-c3 text-lg font-semibold font-mulish">CRM</TableHead>
                  <TableHead className="w-[400px] text-c3 text-lg font-semibold font-mulish">Nome</TableHead>
                  <TableHead className="w-[300px] text-c3 text-lg font-semibold font-mulish">Especialidade</TableHead>
                  <TableHead className="text-c3 text-lg font-semibold font-mulish"></TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                <MedicosTableRow />
              </TableBody>
            </Table>
          </div>
        </div>
      </div>
    </>
  );
}
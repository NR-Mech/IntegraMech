import { Helmet } from "react-helmet-async";
/* import {
  Table,
  TableBody,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"; */
/* import { Dialog, DialogTrigger } from "@/components/ui/dialog"; */
import { Button } from "@/components/ui/button";
/* import { ExamesTableRow } from "./Exames-Table-Row"; */
import { PlusCircleIcon } from "@phosphor-icons/react";

export function Exames() {
  return (
    <>
      <Helmet title="Exames" />
      <div className="flex flex-col gap-4 mt-[3.25rem] font-mulish">
        <div className="relative flex flex-col bg-p3 p-8">
          <div className="flex justify-between items-center">
            <h1 className="text-3xl font-bold text-white">Exames</h1>
            <Button className="rounded-xl" variant="primary">
              <PlusCircleIcon size={22} weight="fill" />
              <span>ADICIONAR EXAME</span>
            </Button>
          </div>
        </div>

        <div className="flex w-full items-center justify-between px-8 mt-12">
          <h2 className="text-title font-semibold text-2xl font-raleway">Todos os Exames</h2>
          <div className="flex items-center gap-20">

          </div>
        </div>

{/*         <div className="space-y-2.5 p-4">
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
                <ExamesTableRow />
              </TableBody>
            </Table>
          </div>
        </div> */}

        {/* Dialog comentado */}
        {/* <Dialog>
          <DialogTrigger asChild>
            <Button variant="outline" size="lg" type="button">
              Novo Exame
            </Button>
          </DialogTrigger>
        </Dialog> */}
      </div>
    </>
  );
}
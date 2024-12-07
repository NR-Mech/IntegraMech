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

export function Medicos() {
  return (
    <>
      <Helmet title="Médicos" />

      <div className="flex flex-col gap-4">
        <div className="flex items-center text-center justify-between mr-4">
          <h1 className="text-3xl font-bold tracking-tight ml-4 mt-4">
            Médicos
          </h1>
          <Dialog>
            <DialogTrigger asChild>
              <Button variant="outline" size="lg" type="button">
                Novo Médico
              </Button>
            </DialogTrigger>
            <MedicosCreate />
          </Dialog>
        </div>

        <div className="space-y-2.5 ml-4 mr-4">
          <div className="rounded-md border">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className="w-[140px]">CRM</TableHead>
                  <TableHead className="w-[140px]">Telefone</TableHead>
                  <TableHead className="w-[700px]">Nome</TableHead>
                  <TableHead>Especialidade</TableHead>
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

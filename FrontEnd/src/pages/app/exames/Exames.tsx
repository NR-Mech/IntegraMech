import { Helmet } from "react-helmet-async";
import {
  Table,
  TableBody,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Dialog, DialogTrigger } from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { ExamesTableRow } from "./Exames-Table-Row";


export function Exames() {
  return (
    <>
      <Helmet title="Exames" />

      <div className="flex flex-col gap-4">
        <div className="flex items-center text-center justify-between mr-4">
          <h1 className="text-3xl font-bold tracking-tight ml-4 mt-4">
            Exames
          </h1>
          <Dialog>
            <DialogTrigger asChild>
              <Button variant="outline" size="lg" type="button">
                Novo Exame
              </Button>
            </DialogTrigger>
            {/* <MedicosCreate /> */}
          </Dialog>
        </div>

        <div className="space-y-2.5 ml-4 mr-4">
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
        </div>
      </div>
    </>
  );
}

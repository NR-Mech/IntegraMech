import { useEffect, useState } from "react";
import { Api } from "../../../services/api";
import { TableCell, TableRow } from "@/components/ui/table";


export function ExamesTableRow() {
  const [exames, setExames] = useState<[]>([]);

  useEffect(() => {
    Api.get("/exames")
      .then((response) => {
        setExames(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  return (
    <>
      {exames.map((paciente) => (
        <TableRow key={paciente.id}>
          <TableCell className="font-mono text-xs font-medium">
            {paciente.nome}
          </TableCell>
          <TableCell className="font-medium">(81)98303-8555</TableCell>
          <TableCell className="font-medium">{paciente.medico}</TableCell>
          <TableCell className="font-medium">
            {paciente.especialidades.join(", ")}
          </TableCell>
        </TableRow>
      ))}
    </>
  );
}

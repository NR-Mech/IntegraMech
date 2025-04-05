import { useEffect, useState } from "react";
import { Api } from "../../../services/api";
import { TableCell, TableRow } from "@/components/ui/table";


export function MedicacaoTableRow() {
  const [medicacoes, setMedicacoes] = useState<[]>([]);

  useEffect(() => {
    Api.get("/medicacao")
      .then((response) => {
        setMedicacoes(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  return (
    <>
      {medicacoes.map((paciente) => (
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

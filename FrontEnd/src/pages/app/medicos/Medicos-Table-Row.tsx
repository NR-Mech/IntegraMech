import { useEffect, useState } from "react";
import { Api } from "../../../services/api";
import { TableCell, TableRow } from "@/components/ui/table";
import type { Medico } from "@/types/medicos";

export function MedicosTableRow() {
  const [medicos, setMedicos] = useState<Medico[]>([]);

  useEffect(() => {
    Api.get("/medicos")
      .then((response) => {
        setMedicos(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  return (
    <>
      {medicos.map((medico) => (
        <TableRow key={medico.id}>
          <TableCell className="font-mulish text-base text-title font-medium">
            {medico.crm}
          </TableCell>
          <TableCell className="font-mulish text-base text-title font-medium">{medico.nome}</TableCell>
          <TableCell className="font-mulish text-base text-title font-medium">
            {medico.especialidades.join(", ")}
          </TableCell>
        </TableRow>
      ))}
    </>
  );
}

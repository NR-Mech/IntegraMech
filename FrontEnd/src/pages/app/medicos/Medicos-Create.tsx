import { Button } from "@/components/ui/button";
import {
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Api } from "@/services/api";
import { useState } from "react";

export function MedicosCreate() {
  const [nome, setNome] = useState("");
  const [crm, setCrm] = useState("");
  const [especialidades, setEspecialidades] = useState<string[]>([]);

  const handleEspecialidadesChange = (
    e: React.ChangeEvent<HTMLInputElement>
  ) => {
    const especialidadesArray = e.target.value.split(",");
    setEspecialidades(especialidadesArray);
  };

  const medicoData = {
    nome: nome,
    crm: crm,
    especialidades: especialidades,
  };

  const postMedico = async () => {
    try {
      const response = await Api.post("/medicos", medicoData);
      window.location.reload();
      console.log(response.data);
    } catch (error) {
      console.log(error);
    }
  };

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    postMedico();
  };

  return (
    <DialogContent>
      <DialogHeader>
        <DialogTitle>Novo Médico</DialogTitle>
        <DialogDescription>Cadastrar um novo médico</DialogDescription>
      </DialogHeader>
      <form className="flex flex-col space-y-4" onSubmit={handleSubmit}>
        <div>
          <Label className="text-title text-base mb-0.5 block" htmlFor="nome">
            Nome
          </Label>
          <Input
            onChange={(e) => setNome(e.target.value)}
            id="nome"
            type="text"
          />
        </div>
        <div>
          <Label className="text-title text-base mb-0.5 block" htmlFor="crm">
            CRM
          </Label>
          <Input
            onChange={(e) => setCrm(e.target.value)}
            id="crm"
            type="text"
            placeholder="XXX-XX 000.000"
          />
        </div>
        <div>
          <Label className="text-title text-base mb-0.5 block" htmlFor="especialidade">
            Especialidades
          </Label>
          <Input
            onChange={handleEspecialidadesChange}
            id="especialidade"
            type="text"
          />
        </div>
        <Button variant="primary">CADASTRAR</Button>
      </form>
    </DialogContent>
  );
}

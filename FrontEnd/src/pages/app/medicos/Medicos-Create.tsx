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
      <form className="flex flex-col gap-3" onSubmit={handleSubmit}>
        <Label htmlFor="nome">Nome</Label>
        <Input
          onChange={(e) => setNome(e.target.value)}
          id="nome"
          type="text"
          placeholder="Nome do médico"
        />
        <Label htmlFor="crm">CRM</Label>
        <Input
          onChange={(e) => setCrm(e.target.value)}
          id="crm"
          type="text"
          placeholder="CRM"
        />
        <Label htmlFor="especialidade">Especialidades</Label>
        <Input
          onChange={handleEspecialidadesChange}
          id="especialidade"
          type="text"
          placeholder="Especialidades"
        />
        <Button>Cadastrar</Button>
      </form>
    </DialogContent>
  );
}

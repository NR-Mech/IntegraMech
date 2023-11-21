INSERT INTO mech.departamentos (nome, descricao) VALUES
('Urgência e Emergência', 'Departamento de Urgência e Emergência'), -- 1
('Administração', 'Departamento de Administração'),                 -- 2
('Recursos Humanos', 'Departamento de Recursos Humanos'),           -- 3
('Apoio Terapêutico', 'Departamento de Apoio Terapêutico');         -- 4


INSERT INTO mech.especialidades (nome) VALUES
('Alergia e Imunologia'), -- 1
('Cardiologia'),          -- 2
('Cirurgia Oncológica'),  -- 3
('Geriatria'),            -- 4
('Homeopatia');           -- 5


INSERT INTO mech.estados (id, nome) VALUES
('AC', 'Acre'),
('AL', 'Alagoas'),
('AM', 'Amazonas'),
('AP', 'Amapá'),
('BA', 'Bahia'),
('CE', 'Ceará'),
('DF', 'Distrito Federal'),
('ES', 'Espirito Santo'),
('GO', 'Goiás'),
('MA', 'Maranhão'),
('MG', 'Minas Gerais'),
('MS', 'Mato Grosso do Sul'),
('MT', 'Mato Grosso'),
('PA', 'Pará'),
('PB', 'Paraíba'),
('PE', 'Pernambuco'),
('PI', 'Piauí'),
('PR', 'Paraná'),
('RJ', 'Rio de Janeiro'),
('RN', 'Rio Grande do Norte'),
('RO', 'Rondônia'),
('RR', 'Roraima'),
('RS', 'Rio Grande do Sul'),
('SC', 'Santa Catarina'),
('SE', 'Sergipe'),
('SP', 'São Paulo'),
('TO', 'Tocantins');


INSERT INTO mech.generos (nome) VALUES
('Feminino'),  -- 1
('Masculino'); -- 2


INSERT INTO mech.medicos (crm, nome) VALUES
('852456/SP', 'Dr. Hans Chucrutes'), -- 1
('159753/PE', 'Dr. Chico Science'),  -- 2
('354961/RJ', 'Dr. Zeca Pagodinho'); -- 3


INSERT INTO mech.tipos_de_quarto (nome) VALUES
('UTI'),             -- 1
('Leito Clínico'),   -- 2
('Leito Cirúrgico'); -- 3


INSERT INTO mech.cidades (estado_id, nome) VALUES
('PE', 'Caruaru'), -- 1
('PE', 'Recife'),  -- 2
('SP', 'Marília'); -- 3


INSERT INTO mech.departamentos__medicos (departamento_id, medico_id) VALUES
(1, 1),
(1, 2),
(1, 3),
(3, 3),
(2, 2);


INSERT INTO mech.medicos__especialidades (especialidade_id, medico_id) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(1, 2),
(5, 3);


INSERT INTO mech.quartos (esta_ocupado, tipo_de_quarto_id) VALUES
(TRUE, 1),  -- 1
(FALSE, 2), -- 2
(TRUE, 2),  -- 3
(FALSE, 3); -- 4


INSERT INTO mech.enderecos (bairro, cep, cidade_id, rua) VALUES
('Centenário', '5861618', 1, 'Paulo Afonso'),  -- 1
('Janga', '6746816', 2, 'Walter de Afogados'); -- 2


INSERT INTO mech.pacientes (cns, cpf, data_de_nascimento, endereco_id, genero_id, nome) VALUES
('4684686781', '05531923023', '1944-02-14', 1, 2, 'Reginaldo Rossi'),     -- 1
('6186168168', '29328343046', '1950-04-02', 2, 2, 'Faustão'),             -- 2
('8451947367', '48993836060', '1980-09-18', 2, 1, 'Raquel Dos Teclados'); -- 3


INSERT INTO mech.estadias (data_da_admissao, data_da_alta, medico_id, motivo_da_admissao, paciente_id, quarto_id) VALUES
('2023-11-16 13:57:45', NULL, 1, 'Coma alcoólico / deu PT', 1, 1), -- 1
('2023-10-18 02:10:59', '2023-11-07 12:05:20', 2, 'Transplante de coração', 2, 3);  -- 2

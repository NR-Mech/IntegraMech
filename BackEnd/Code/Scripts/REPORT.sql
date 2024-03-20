-- SELECTS
SELECT * FROM mech.estados;
SELECT * FROM mech.cidades;
SELECT * FROM mech.generos;
SELECT * FROM mech.tipos_de_quarto;
SELECT * FROM mech.especialidades;
SELECT * FROM mech.departamentos;

SELECT * FROM mech.medicos;
SELECT * FROM mech.medicos__especialidades;
SELECT * FROM mech.departamentos__medicos;

SELECT * FROM mech.enderecos;
SELECT * FROM mech.pacientes;
SELECT * FROM mech.quartos;
SELECT * FROM mech.estadias;

-------------------------------------------------------------------------------
-- INSERTS
INSERT INTO mech.especialidades (nome) VALUES
('Pediatria'),          -- 6
('Urologia'),           -- 7
('Medicina Esportiva'); -- 8

INSERT INTO mech.medicos (crm, nome) VALUES
('695712/PE', 'Dr. House'); -- 4

INSERT INTO mech.medicos__especialidades (especialidade_id, medico_id) VALUES
(8, 4);

-------------------------------------------------------------------------------
-- UPDATES
UPDATE mech.quartos
SET esta_ocupado = false
WHERE id = 1;

UPDATE mech.especialidades
SET nome = 'Imunologia'
WHERE id = 1;

UPDATE mech.estadias
SET data_da_alta = '2023-11-17 19:30:22'
WHERE id = 1;

-------------------------------------------------------------------------------
-- DELETES
DELETE FROM mech.especialidades
WHERE id IN (6, 7);

-------------------------------------------------------------------------------
-- COMPLEX QUERIES

-- Médicos e suas especialidades
SELECT
	m.id,
	m.nome,
	ARRAY_AGG (e.nome) AS especialidades
FROM
	mech.medicos m
LEFT JOIN
	mech.medicos__especialidades me ON me.medico_id = m.id
LEFT JOIN
	mech.especialidades e ON e.id = me.especialidade_id
WHERE
	e.nome IN ('Imunologia', 'Cardiologia')
GROUP BY
	m.id
ORDER BY
	m.id;

-- Estadias
SELECT
	e.id,
	p.nome AS paciente,
	m.nome AS medico,
	tdq.nome AS quarto,
	e.motivo_da_admissao,
	e.data_da_admissao,
	e.data_da_alta
FROM
	mech.estadias e
INNER JOIN
	mech.pacientes p ON p.id = e.paciente_id
INNER JOIN
	mech.medicos m ON m.id = e.medico_id
INNER JOIN
	mech.quartos q ON q.id = e.quarto_id
INNER JOIN
	mech.tipos_de_quarto tdq ON tdq.id = q.tipo_de_quarto_id
ORDER BY
	e.id;

-- Pacientes
SELECT
	p.id,
	p.cpf,
	p.cns,
	p.nome,
	p.data_de_nascimento,
	g.nome AS genero,
	c.nome AS cidade,
	c.estado_id AS estado,
	e.cep,
	e.rua,
	e.bairro
FROM
	mech.pacientes p
INNER JOIN
	mech.generos g ON g.id = p.genero_id
INNER JOIN
	mech.enderecos e ON e.id = p.endereco_id
INNER JOIN
	mech.cidades c ON c.id = e.cidade_id
ORDER BY
	p.id;

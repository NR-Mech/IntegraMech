using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mech");

            migrationBuilder.CreateTable(
                name: "departamentos",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "especialidades",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_especialidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "generos",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicos",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    crm = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_de_quarto",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipos_de_quarto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cidades",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estado_id = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cidades", x => x.id);
                    table.ForeignKey(
                        name: "fk_cidades_estado_estado_id",
                        column: x => x.estado_id,
                        principalSchema: "mech",
                        principalTable: "estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departamentos__medicos",
                schema: "mech",
                columns: table => new
                {
                    departamento_id = table.Column<long>(type: "bigint", nullable: false),
                    medico_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departamentos__medicos", x => new { x.departamento_id, x.medico_id });
                    table.ForeignKey(
                        name: "fk_departamentos__medicos_departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalSchema: "mech",
                        principalTable: "departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departamentos__medicos_medicos_medico_id",
                        column: x => x.medico_id,
                        principalSchema: "mech",
                        principalTable: "medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicos__especialidades",
                schema: "mech",
                columns: table => new
                {
                    medico_id = table.Column<long>(type: "bigint", nullable: false),
                    especialidade_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medicos__especialidades", x => new { x.medico_id, x.especialidade_id });
                    table.ForeignKey(
                        name: "fk_medicos__especialidades_especialidades_especialidade_id",
                        column: x => x.especialidade_id,
                        principalSchema: "mech",
                        principalTable: "especialidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_medicos__especialidades_medicos_medico_id",
                        column: x => x.medico_id,
                        principalSchema: "mech",
                        principalTable: "medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quartos",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo_id = table.Column<long>(type: "bigint", nullable: false),
                    esta_ocupado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quartos", x => x.id);
                    table.ForeignKey(
                        name: "fk_quartos_tipo_de_quarto_tipo_id",
                        column: x => x.tipo_id,
                        principalSchema: "mech",
                        principalTable: "tipos_de_quarto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cidade_id = table.Column<long>(type: "bigint", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    rua = table.Column<string>(type: "text", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "fk_enderecos_cidades_cidade_id",
                        column: x => x.cidade_id,
                        principalSchema: "mech",
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genero_id = table.Column<long>(type: "bigint", nullable: false),
                    endereco_id = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: false),
                    cns = table.Column<string>(type: "text", nullable: false),
                    data_de_nascimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pacientes", x => x.id);
                    table.ForeignKey(
                        name: "fk_pacientes_endereco_endereco_id",
                        column: x => x.endereco_id,
                        principalSchema: "mech",
                        principalTable: "enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pacientes_generos_genero_id",
                        column: x => x.genero_id,
                        principalSchema: "mech",
                        principalTable: "generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estadias",
                schema: "mech",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    paciente_id = table.Column<long>(type: "bigint", nullable: false),
                    medico_id = table.Column<long>(type: "bigint", nullable: false),
                    quarto_id = table.Column<long>(type: "bigint", nullable: false),
                    motivo_da_admissao = table.Column<string>(type: "text", nullable: false),
                    data_da_admissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_da_alta = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estadias", x => x.id);
                    table.ForeignKey(
                        name: "fk_estadias_medicos_medico_id",
                        column: x => x.medico_id,
                        principalSchema: "mech",
                        principalTable: "medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_estadias_pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalSchema: "mech",
                        principalTable: "pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_estadias_quartos_quarto_id",
                        column: x => x.quarto_id,
                        principalSchema: "mech",
                        principalTable: "quartos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "departamentos",
                columns: new[] { "id", "descricao", "nome" },
                values: new object[,]
                {
                    { 1L, "Departamento de Urgência e Emergência", "Urgência e Emergência" },
                    { 2L, "Departamento de Administração", "Administração" },
                    { 3L, "Departamento de Recursos Humanos", "Recursos Humanos" },
                    { 4L, "Departamento de Apoio Terapêutico", "Apoio Terapêutico" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "especialidades",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1L, "Alergia e Imunologia" },
                    { 2L, "Cardiologia" },
                    { 3L, "Cirurgia Oncológica" },
                    { 4L, "Geriatria" },
                    { 5L, "Homeopatia" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "estados",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { "AC", "Acre" },
                    { "AL", "Alagoas" },
                    { "AM", "Amazonas" },
                    { "AP", "Amapá" },
                    { "BA", "Bahia" },
                    { "CE", "Ceará" },
                    { "DF", "Distrito Federal" },
                    { "ES", "Espirito Santo" },
                    { "GO", "Goiás" },
                    { "MA", "Maranhão" },
                    { "MG", "Minas Gerais" },
                    { "MS", "Mato Grosso do Sul" },
                    { "MT", "Mato Grosso" },
                    { "PA", "Pará" },
                    { "PB", "Paraíba" },
                    { "PE", "Pernambuco" },
                    { "PI", "Piauí" },
                    { "PR", "Paraná" },
                    { "RJ", "Rio de Janeiro" },
                    { "RN", "Rio Grande do Norte" },
                    { "RO", "Rondônia" },
                    { "RR", "Roraima" },
                    { "RS", "Rio Grande do Sul" },
                    { "SC", "Santa Catarina" },
                    { "SE", "Sergipe" },
                    { "SP", "São Paulo" },
                    { "TO", "Tocantins" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "generos",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1L, "Feminino" },
                    { 2L, "Masculino" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "medicos",
                columns: new[] { "id", "crm", "nome" },
                values: new object[,]
                {
                    { 1L, "852456/SP", "Dr. Hans Chucrutes" },
                    { 2L, "159753/PE", "Dr. Chico Science" },
                    { 3L, "354961/RJ", "Dr. Zeca Pagodinho" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "tipos_de_quarto",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1L, "UTI" },
                    { 2L, "Leito Clínico" },
                    { 3L, "Leito Cirúrgico" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "cidades",
                columns: new[] { "id", "estado_id", "nome" },
                values: new object[,]
                {
                    { 1L, "PE", "Caruaru" },
                    { 2L, "PE", "Recife" },
                    { 3L, "SP", "Marília" },
                    { 4L, "PE", "Santa Cruz do Capibaribe" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "departamentos__medicos",
                columns: new[] { "departamento_id", "medico_id" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 1L, 3L },
                    { 2L, 2L }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "medicos__especialidades",
                columns: new[] { "especialidade_id", "medico_id" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L },
                    { 4L, 1L },
                    { 1L, 2L },
                    { 5L, 3L }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "quartos",
                columns: new[] { "id", "esta_ocupado", "tipo_id" },
                values: new object[,]
                {
                    { 1L, true, 1L },
                    { 2L, false, 2L },
                    { 3L, true, 2L },
                    { 4L, false, 3L }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "enderecos",
                columns: new[] { "id", "bairro", "cep", "cidade_id", "rua" },
                values: new object[,]
                {
                    { 1L, "Centenário", "5861618", 1L, "Paulo Afonso" },
                    { 2L, "Janga", "6746816", 2L, "Walter de Afogados" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "pacientes",
                columns: new[] { "id", "cns", "cpf", "data_de_nascimento", "endereco_id", "genero_id", "nome" },
                values: new object[,]
                {
                    { 1L, "4684686781", "05531923023", new DateOnly(1944, 2, 14), 1L, 2L, "Reginaldo Rossi" },
                    { 2L, "6186168168", "29328343046", new DateOnly(1950, 4, 2), 2L, 2L, "Faustão" },
                    { 3L, "8451947367", "48993836060", new DateOnly(1980, 9, 18), 2L, 1L, "Raquel Dos Teclados" }
                });

            migrationBuilder.InsertData(
                schema: "mech",
                table: "estadias",
                columns: new[] { "id", "data_da_admissao", "data_da_alta", "medico_id", "motivo_da_admissao", "paciente_id", "quarto_id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 2, 20, 50, 41, 664, DateTimeKind.Local).AddTicks(6827), null, 1L, "Coma alcoólico / deu PT", 1L, 1L },
                    { 2L, new DateTime(2024, 5, 4, 20, 50, 41, 664, DateTimeKind.Local).AddTicks(6845), new DateTime(2024, 5, 24, 20, 50, 41, 664, DateTimeKind.Local).AddTicks(6845), 2L, "Transplante de coração", 2L, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "ix_cidades_estado_id",
                schema: "mech",
                table: "cidades",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "ix_departamentos__medicos_medico_id",
                schema: "mech",
                table: "departamentos__medicos",
                column: "medico_id");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_cidade_id",
                schema: "mech",
                table: "enderecos",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "ix_estadias_medico_id",
                schema: "mech",
                table: "estadias",
                column: "medico_id");

            migrationBuilder.CreateIndex(
                name: "ix_estadias_paciente_id",
                schema: "mech",
                table: "estadias",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "ix_estadias_quarto_id",
                schema: "mech",
                table: "estadias",
                column: "quarto_id");

            migrationBuilder.CreateIndex(
                name: "ix_medicos__especialidades_especialidade_id",
                schema: "mech",
                table: "medicos__especialidades",
                column: "especialidade_id");

            migrationBuilder.CreateIndex(
                name: "ix_pacientes_endereco_id",
                schema: "mech",
                table: "pacientes",
                column: "endereco_id");

            migrationBuilder.CreateIndex(
                name: "ix_pacientes_genero_id",
                schema: "mech",
                table: "pacientes",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "ix_quartos_tipo_id",
                schema: "mech",
                table: "quartos",
                column: "tipo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departamentos__medicos",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "estadias",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "medicos__especialidades",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "departamentos",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "pacientes",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "quartos",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "especialidades",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "medicos",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "enderecos",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "generos",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "tipos_de_quarto",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "cidades",
                schema: "mech");

            migrationBuilder.DropTable(
                name: "estados",
                schema: "mech");
        }
    }
}

Feature: Listar pacientes

    Scenario: Listar todos os pacientes e seus endereços
        Given que existem pacientes cadastrados
        When eu faço uma requisição GET para "/Pacientes"
        Then a resposta deve ser 200 OK
        And a resposta deve conter uma lista de pacientes
        And cada paciente deve conter "Id", "Cpf", "CNS", "Nome", "DataDeNascimento", "Genero", "Cidade", "Estado", "CEP", "Rua" e "Bairro"
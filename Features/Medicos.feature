Feature: Listar médicos

    Scenario: Listar todos os médicos e suas especialidades
        Given que existem médicos cadastrados
        When eu faço uma requisição GET para "/Medicos"
        Then a resposta deve ser 200 OK
        And a resposta deve conter uma lista de médicos
        And cada médico deve conter "Id", "Nome" e "Especialidades"
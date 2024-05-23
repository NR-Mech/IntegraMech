Feature: Listar departamentos

    Scenario: Listar todos os departamentos
        Given que existem departamentos cadastrados
        When eu faço uma requisição GET para "/Departamentos"
        Then a resposta deve ser 200 OK
        And a resposta deve conter uma lista de departamentos
        And cada departamento deve conter "Id", "Nome" e "Descricao"
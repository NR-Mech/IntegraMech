Feature: Listar estadias

    Scenario: Listar todas as estadias dos pacientes
        Given que existem estadias cadastradas
        When eu faço uma requisição GET para "/Estadias"
        Then a resposta deve ser 200 OK
        And a resposta deve conter uma lista de estadias
        And cada estadia deve conter "Id", "Paciente", "Medico", "Quarto", "MotivoDaAdmissao", "DataDaAdmissao" e "DataDaAlta"
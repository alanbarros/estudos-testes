from estudante import Estudante

class Graduacao(Estudante):
    def __init__(self, nome, email, telefone, endereco, dataNascimento, sexo, curso, tcc, estagio):
        Estudante.__init__(self, nome, email, telefone, endereco, dataNascimento, sexo, curso)
        self.tcc = tcc
        self.estagio = estagio
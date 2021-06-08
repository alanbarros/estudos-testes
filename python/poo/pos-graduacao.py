from estudante import Estudante

class PosGraduacao(Estudante):
    def __init__(self, nome, email, telefone, endereco, dataNascimento, sexo, curso, artigo):
        Estudante.__init__(self, nome, email, telefone, endereco, dataNascimento, sexo, curso)
        self.artigo = artigo
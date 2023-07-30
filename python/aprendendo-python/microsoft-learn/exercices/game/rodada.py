from jogo import Jogo

class Rodada:
    def __init__(self, jogo: Jogo, numero: int):
        self.jogo = jogo
        self.numero = numero
        self.__vencedor = ""

    @property
    def vencedor(self):
        return self.__vencedor

    def iniciar(self) -> None:
        vencedor = self.jogo.jogar()
        if vencedor == 1:
            self.__vencedor = self.jogo.participante1.nome
        elif vencedor == 2:
            self.__vencedor = self.jogo.participante2.nome
        else:
            self.__vencedor = "Ninguem"
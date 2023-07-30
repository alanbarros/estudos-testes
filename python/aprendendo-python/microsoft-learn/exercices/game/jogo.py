from participante import Participante

class Jogo:
    def __init__(self, participante1: Participante, participante2: Participante):
        self.participante1 = participante1
        self.participante2 = participante2
        self.__simbolo_p1 = 0
        self.__simbolo_p2 = 0

    def escolher_simbolo(self, participante: Participante) -> int:
        print("{nome} escolha um simbolo".format(nome=participante.nome))
        print("1 - Pedra")
        print("2 - Papel")
        print("3 - Tesoura")
        simbolo = input()
        match simbolo:
            case '1' | '2' | '3':
                return simbolo
            case _:
                print("Escolha invalida! Tente novamente")
                simbolo = self.escolher_simbolo(participante)
        return simbolo
    
    def definir_vencedor(self) -> int: # 1 > 3, 3 > 2, 2 > 1
        regras = [
            [0, 2, 1],
            [1, 0, 2],
            [2, 1, 0]
        ]
        return regras[self.__simbolo_p1-1][self.__simbolo_p2-1]
    
    def jogar(self) -> int:
        self.__simbolo_p1 = int(self.escolher_simbolo(self.participante1))
        self.__simbolo_p2 = int(self.escolher_simbolo(self.participante2))
        return self.definir_vencedor()

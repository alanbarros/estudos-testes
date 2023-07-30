from participante import Participante

class Jogo:
    def __init__(self, participante1: Participante, participante2: Participante):
        self.participante1 = participante1
        self.participante2 = participante2
        self.__simbolo_p1 = 0
        self.__simbolo_p2 = 0

    def escolher_simbolo(self, participante: Participante) -> int:
        print("{nome} escolha um simbolo".format(nome=participante.nome))
        
        switcher = {
            "1": "Pedra",
            "2": "Papel",
            "3": "Teroura",
            "4": "Lagarto",
            "5": "Spoke"
        }

        for item in switcher:
            print("{key} - {value}".format(key=item, value=switcher[item]))
        
        simbolo = input()

        exist = switcher.get(simbolo, "notFound")
        match exist:
            case "notFound":
                print("Escolha invalida! Tente novamente")
                simbolo = self.escolher_simbolo(participante)
            case _:
                return simbolo
        return simbolo
    
    def definir_vencedor(self) -> int: 
        # http://frontdaciencia.blogspot.com/2016/06/pedra-papel-tesoura-lagarto-spock.html 
        regras = [
            [0, 2, 1, 1, 2],
            [1, 0, 2, 2, 1],
            [2, 1, 0, 1, 2],
            [2, 1, 2, 0, 1],
            [1, 2, 1, 2, 0]
        ]
        return regras[self.__simbolo_p1-1][self.__simbolo_p2-1]
    
    def jogar(self) -> int:
        self.__simbolo_p1 = int(self.escolher_simbolo(self.participante1))
        self.__simbolo_p2 = int(self.escolher_simbolo(self.participante2))
        return self.definir_vencedor()

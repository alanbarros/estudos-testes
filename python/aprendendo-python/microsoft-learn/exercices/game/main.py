from participante import Participante
from jogo import Jogo
from rodada import Rodada

p1 = Participante("Alan")
p2 = Participante("Jessica")

print("Quantas rodadas terá o jogo?")
qtdRodadas = int(input())

rodadas = []
partida = 0

def obter_vencedor() -> str:
    return "Ninguem" if p1.pontos == p2.pontos else (p1.nome if p1.pontos > p2.pontos else p2.nome)

for vezes in range(qtdRodadas):
    jogo = Jogo(p1, p2)
    rodada = Rodada(jogo, partida + 1)
    
    rodada.iniciar()
    rodadas.append(rodada)
    partida += 1

for r in rodadas:
    print("O vencedor da roda " + str(r.numero) + " foi: "  + r.vencedor)
    if r.vencedor == p1.nome:
        p1.pontos += 1
    elif r.vencedor == p2.nome:
        p2.pontos += 1

print("O vencedor do jogo foi: {winner}".format(winner=obter_vencedor()))

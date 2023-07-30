import random

numero = random.randint(0, 10)

print(numero)


# exercicios

def ex_idade():
    idade = int(input("Digite sua idade: 29"))

    if (idade >= 18):
        print("Você é maior de idade")
    else:
        print("Você é menor de idade")

# calculadora


def soma(valor1, valor2):
    return valor1 + valor2


def subtracao(valor1, valor2):
    return valor1 - valor2


def multiplicacao(valor1, valor2):
    return valor1 * valor2


def divisao(valor1, valor2):
    return valor1 / valor2


operacoes_aceitas = {
    "+": soma,
    "-": subtracao,
    "x": multiplicacao,
    "/": divisao}

numeroA = int(input("Digite um número: "))
numeroB = int(input("Digite outro número: "))
operacao = input("Qual operação (+, -, x ou /) deseja fazer?: ")

resultado = operacoes_aceitas[operacao](numeroA, numeroB)

print(f"O resulado é: {resultado}")

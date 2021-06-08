# -*- coding: utf-8 -*-

lista = ["abacaxi", "melnacia", "abacate"]

print(lista)

lista_variada = ["abacate", 1, 3.98, True]

print(lista_variada[2])

lista_variada.append("limão")

del lista_variada[3:]

for item in lista_variada :
    print(item)

if(1 in lista_variada):
    print("1 está na lista")

del lista[:]

print(lista)
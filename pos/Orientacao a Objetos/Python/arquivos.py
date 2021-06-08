# -*- coding: utf-8 -*-

from _typeshed import SupportsDivMod


arquivo = open("file.txt")

linhas = arquivo.readlines()

print(linhas)

w = open("arquivo.txt", "a")

w.write("Teste\n")

w.close()
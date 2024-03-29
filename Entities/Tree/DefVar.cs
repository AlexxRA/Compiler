﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class DefVar : Nodo
    {
        public object Tipo { get; set; }
        public object Id { get; set; }
        public object listaVar { get; set; }

        public DefVar(List<Nodo> elements, int ruleNumber)
        {
            Tipo = elements[7];
            Id = elements[5];
            listaVar = elements[3];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            var tipoDato = ((Nodo)Tipo).Name;
            var ambito = ((Nodo)Id).Name;
            if (listaVar != null)
                ((Nodo)listaVar).ValidaSemantica(tablaSimbolos);
            if (!SimboloExiste(tablaSimbolos, ((Nodo)Id).Name))
                tablaSimbolos.Add(new TablaSimbolos(ambito, tipoDato, "defVar"));
            else
                Console.WriteLine("La variable " + ambito + " ya existe");
            return true;
        }
    }
}

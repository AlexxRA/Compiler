using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ListaParam : Nodo
    {
        public object Tipo { get; set; }
        public object Id { get; set; }
        public object listaParam { get; set; }

        public ListaParam(List<Nodo> elements, int ruleNumber)
        {
            listaParam = elements[1];
            Id = elements[3];
            Tipo = elements[5];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            var tipoDato = ((Nodo)Tipo).Name;
            var ambito = ((Nodo)Id).Name;


            if (!SimboloExiste(tablaSimbolos, ((Nodo)Id).Name, ambito))
                tablaSimbolos.Add(new TablaSimbolos(ambito, tipoDato, ambito));
            else
                Console.WriteLine("La variable " + ambito + " ya fue declarada");

            if (listaParam != null)
                ((Nodo)listaParam).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

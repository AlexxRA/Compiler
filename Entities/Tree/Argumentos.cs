using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Argumentos : Nodo
    {
        public object expresion { get; set; }
        public object listaArgumentos { get; set; }
        public Argumentos(List<Nodo> elements, int ruleNumber)
        {
            listaArgumentos = elements[1];
            expresion = elements[3];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (expresion != null)
                ((Nodo)expresion).ValidaSemantica(tablaSimbolos);
            if (listaArgumentos != null)
                ((Nodo)listaArgumentos).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

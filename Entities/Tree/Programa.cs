using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Programa : Nodo
    {
        public object definiciones { get; set; }
        public Programa(List<Nodo> elements, int ruleNumber)
        {
            definiciones = elements[1];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (definiciones != null)
                ((Nodo)definiciones).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

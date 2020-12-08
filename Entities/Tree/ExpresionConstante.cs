using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ExpresionConstante : Nodo
    {
        public object constante { get; set; }
        public ExpresionConstante(List<Nodo> elements, int ruleNumber)
        {
            constante = elements[1];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (constante != null)
                ((dynamic)constante).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

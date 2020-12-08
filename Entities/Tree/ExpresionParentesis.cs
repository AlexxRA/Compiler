using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ExpresionParentesis : Nodo
    {
        public object expresion { get; set; }
        public ExpresionParentesis(List<Nodo> elements, int ruleNumber)
        {
            expresion = elements[3];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (expresion != null)
                ((dynamic)expresion).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

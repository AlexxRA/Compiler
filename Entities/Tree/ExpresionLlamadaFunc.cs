using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ExpresionLlamadaFunc : Nodo
    {
        public object llamadaFunc { get; set; }
        public ExpresionLlamadaFunc(List<Nodo> elements, int ruleNumber)
        {
            llamadaFunc = elements[1];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (llamadaFunc != null)
                ((Nodo)llamadaFunc).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

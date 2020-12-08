using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class SentenciaLlamadaFunc : Nodo
    {
        public object llamadaFunc { get; set; }
        public SentenciaLlamadaFunc(List<Nodo> elements, int ruleNumber)
        {
            llamadaFunc = elements[3];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (llamadaFunc != null)
                ((dynamic)llamadaFunc).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

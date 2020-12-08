using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Otro : Nodo
    {
        public object sentenciaBloque { get; set; }
        public Otro(List<Nodo> elements, int ruleNumber)
        {
            sentenciaBloque = elements[1];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (sentenciaBloque != null)
                ((Nodo)sentenciaBloque).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

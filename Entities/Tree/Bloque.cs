using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Bloque : Nodo
    {
        public object sentencias { get; set; }
        public Bloque(List<Nodo> elements, int ruleNumber)
        {
            sentencias = elements[3];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (sentencias != null)
                ((dynamic)sentencias).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

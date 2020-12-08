using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ExpresionId : Nodo
    {
        public object Id { get; set; }
        public ExpresionId(List<Nodo> elements, int ruleNumber)
        {
            Id = elements[1];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (Id != null)
                ((dynamic)Id).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

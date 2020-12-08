using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    class DefLocales : Nodo
    {
        public object defLocal { get; set; }
        public object defLocales { get; set; }

        public DefLocales(List<Nodo> elements, int ruleNumber)
        {
            defLocal = elements[3];
            defLocales = elements[1];
            TokenId = ruleNumber;
            Next = elements[1];
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (defLocal != null)
                ((Nodo)defLocal).ValidaSemantica(tablaSimbolos);
            if (defLocales != null)
                ((Nodo)defLocales).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

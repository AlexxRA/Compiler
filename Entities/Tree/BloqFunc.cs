using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class BloqFunc : Nodo
    {
        public object defLocales { get; set; }

        public BloqFunc(List<Nodo> elements, int ruleNumber)
        {
            defLocales = elements[3];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (defLocales != null)
                ((Nodo)defLocales).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

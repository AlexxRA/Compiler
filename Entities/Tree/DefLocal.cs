using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class DefLocal : Nodo
    {
        public object defVar { get; set; }
        public object sentencia { get; set; }
        public DefLocal(List<Nodo> elements, int ruleNumber)
        {
            var type = elements[1].GetType().ToString();
            if (type == "LexicalAnalyzer.Entities.Tree.DefVar")
            {
                defVar = elements[1];
            }
            else
            {
                sentencia = elements[1];
            }
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (defVar != null)
                ((Nodo)defVar).ValidaSemantica(tablaSimbolos);
            if (sentencia != null)
                ((Nodo)sentencia).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

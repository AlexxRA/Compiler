using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Sentencias : Nodo
    {
        public object sentencia { get; set; }
        public object sentencias { get; set; }

        public Sentencias(List<Nodo> elements, int ruleNumber)
        {
            sentencia = elements[3];
            sentencias = elements[1];
            TokenId = ruleNumber;
            Next = elements[1];
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (sentencia != null)
                ((dynamic)sentencia).ValidaSemantica(tablaSimbolos);
            if (sentencias != null)
                ((dynamic)sentencias).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

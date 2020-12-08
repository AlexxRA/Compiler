using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class SentenciaIf : Nodo
    {
        public object expresion { get; set; }
        public object sentenciaBloque { get; set; }
        public object otro { get; set; }
        public SentenciaIf(List<Nodo> elements, int ruleNumber)
        {
            expresion = elements[7];
            sentenciaBloque = elements[3];
            otro = elements[1];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (expresion != null)
                ((dynamic)expresion).ValidaSemantica(tablaSimbolos);
            if (sentenciaBloque != null)
                ((dynamic)sentenciaBloque).ValidaSemantica(tablaSimbolos);
            if (otro != null)
                ((dynamic)otro).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

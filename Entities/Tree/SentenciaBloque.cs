using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class SentenciaBloque : Nodo
    {
        public object sentencia { get; set; }
        public object bloque { get; set; }
        public SentenciaBloque(List<Nodo> elements, int ruleNumber)
        {
            var type = elements[1].GetType().ToString();
            if (type == "LexicalAnalyzer.Entities.Tree.Bloque")
            {
                bloque = elements[1];
            }
            else
            {
                sentencia = elements[1];
            }
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (sentencia != null)
                ((dynamic)sentencia).ValidaSemantica(tablaSimbolos);
            if (bloque != null)
                ((dynamic)bloque).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

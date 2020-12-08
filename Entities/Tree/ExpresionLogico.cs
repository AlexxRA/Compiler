using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ExpresionLogico : Nodo
    {
        public object expresion { get; set; }
        public object opLogico { get; set; }
        public object segundaExpresion { get; set; }
        public ExpresionLogico(List<Nodo> elements, int ruleNumber)
        {
            expresion = elements[5];
            opLogico = elements[3];
            segundaExpresion = elements[1];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if (expresion != null)
                ((dynamic)expresion).ValidaSemantica(tablaSimbolos);
            if (segundaExpresion != null)
                ((dynamic)segundaExpresion).ValidaSemantica(tablaSimbolos);
            return true;
        }
    }
}

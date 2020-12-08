using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Definicion : Nodo
    {
        public object defVar { get; set; }
        public object defFunc { get; set; }
        public Definicion(List<Nodo> elements, int ruleNumber)
        {
            var type = elements[1].GetType().ToString();
            if (type == "LexicalAnalyzer.Entities.Tree.DefFunc")
            {
                defFunc = elements[1];
            }
            else
            {
                defVar = elements[1];
            }
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if(defVar != null) 
                ((Nodo)defVar).ValidaSemantica(tablaSimbolos);
            if (defFunc != null)
                ((Nodo)defFunc).ValidaSemantica(tablaSimbolos);
            //Console.WriteLine("Validasemantica de Definicion");
            return true;
        }
    }
}

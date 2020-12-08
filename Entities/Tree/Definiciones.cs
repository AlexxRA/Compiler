using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Definiciones : Nodo
    {
        public object definicion { get; set; }
        public object definiciones { get; set; }

        public Definiciones(List<Nodo> elements, int ruleNumber)
        {
            definicion = elements[3];
            definiciones = elements[1];
            TokenId = ruleNumber;
            Next = elements[1];
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            if(definicion != null)
                ((Nodo)definicion).ValidaSemantica(tablaSimbolos);
            if (definiciones != null)
                ((Nodo)definiciones).ValidaSemantica(tablaSimbolos);
            //var defFuncValida = ((Nodo)defFunc).ValidaSemantica();
            //Console.WriteLine("Validasemantica de Definiciones");
            return true;
        }
    }
}

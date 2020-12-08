using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ListaArgumentos : Nodo
    {
        public object expresion { get; set; }
        public object listaArgumentos { get; set; }
        public ListaArgumentos(List<Nodo> elements, int ruleNumber)
        {
            listaArgumentos = elements[1];
            expresion = elements[3];
            TokenId = ruleNumber;
        }
    }
}

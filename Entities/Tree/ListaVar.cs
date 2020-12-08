using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ListaVar : Nodo
    {
        public object Id { get; set; }
        public object listaVar { get; set; }
        public ListaVar(List<Nodo> elements, int ruleNumber)
        {
            Id = elements[3];
            listaVar = elements[1];
            TokenId = ruleNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    class SentenciaWhile : Nodo
    {
        public object expresion { get; set; }
        public object sentenciaBloque { get; set; }
        public SentenciaWhile(List<Nodo> elements, int ruleNumber)
        {
            expresion = elements[5];
            sentenciaBloque = elements[1];
            TokenId = ruleNumber;
        }
    }
}

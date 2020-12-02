using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class ListaVar
    {
        public string Id { get; set; }
        public ListaVar ListaVar { get; set; }
    }
}

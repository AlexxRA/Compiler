using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class DefVar : Nodo
    {
        public Nodo Tipo { get; set; }
        public Nodo Id { get; set; }
        public Nodo ListaVar { get; set; }

        public DefVar()
        {
            //hacer stack.pops
        }

        public override void ValidateType()
        {
            
        }
    }
}

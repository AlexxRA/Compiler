using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Nodo
    {
        public string LexemeType { get; set; }
        public string Scope { get; set; }
        public Nodo Next { get; set; }

        public Nodo()
        {
            LexemeType = "";
            Scope = "";
            Next = null;
        }
        public virtual void ValidateType()
        {

        }
    }
}

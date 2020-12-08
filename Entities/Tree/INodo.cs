using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    interface INodo
    {
        int TokenId { get; set; }
        string LexemeType { get; set; }
        string Name { get; set; }
        Nodo Next { get; set; }
    }
}

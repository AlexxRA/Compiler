using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities
{
    class Token
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int TokenId { get; set; }

        public void CleanToken()
        {
            this.Name = "";
            this.Type = "";
            this.TokenId = 0;
        }
    }
}

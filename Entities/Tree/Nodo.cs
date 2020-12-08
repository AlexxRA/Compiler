using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class Nodo : INodo
    {
        public int TokenId { get; set; }
        public string LexemeType { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public Nodo Next { get; set; }

        public Nodo()
        {
            TokenId = 0;
            LexemeType = "";
            Name = "";
            Next = null;
            DataType = "";
        }
        public virtual bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            return true;
        }

        public bool SimboloExiste(List<TablaSimbolos> tablaSimbolos, string id, string ambito=null)
        {
            return tablaSimbolos.Exists(x => x.Id.Equals(id) && x.Ambito.Equals(ambito));
        }
        public string BuscarTipo(List<TablaSimbolos> tablaSimbolos, string id)
        {
            if (id != "print")
                return tablaSimbolos.Where(x => x.Id.Equals(id)).FirstOrDefault()?.Tipo ?? "";
            else
                return "";
        }
        public string BuscarTipoConstante(List<TablaSimbolos> tablaSimbolos, string id)
        {
            if (id.Contains('\''))
                return "char";
            return id.Contains(".") ? "float" : "int";
        }
    }
}

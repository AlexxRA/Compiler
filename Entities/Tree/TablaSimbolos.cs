using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class TablaSimbolos
    {
        public string Id;
        public string Tipo;
        public string Ambito;
        public string CadenaParametros;

        public TablaSimbolos(string id, string tipo, string ambito)
        {
            Id = id;
            Tipo = tipo;
            Ambito = ambito;
        }
        public TablaSimbolos(string id, string tipo, string ambito, string cadenaParametros)
        {
            Id = id;
            Tipo = tipo;
            Ambito = ambito;
            CadenaParametros = cadenaParametros;
        }

    }
}

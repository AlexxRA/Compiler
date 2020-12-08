using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class DefFunc : Nodo
    {
        public object Tipo { get; set; }
        public object Id { get; set; }
        public object parametros { get; set; }
        public object bloqFunc { get; set; }

        public DefFunc(List<Nodo> elements, int ruleNumber)
        {
            bloqFunc = elements[1];
            parametros = elements[5];
            Id = elements[9];
            Tipo = elements[11];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            var tipoDato = ((Nodo)Tipo).Name;
            var ambito = ((Nodo)Id).Name;

            var aux = ((dynamic)parametros).Name.Equals("null") ? null : parametros ;
            var cadena = "";
            while(((dynamic)aux) != null)
            {
                cadena += ((dynamic)aux).Tipo.Name[0];
                aux = ((dynamic)aux).listaParam.Name.Equals("null") ? null : ((dynamic)aux).listaParam;
            }

            if (parametros != null)
                ((Nodo)parametros).ValidaSemantica(tablaSimbolos);

            if (!SimboloExiste(tablaSimbolos, ((Nodo)Id).Name, ambito))
                tablaSimbolos.Add(new TablaSimbolos(ambito, tipoDato, ambito, cadena));
            else
                Console.WriteLine("La funcion "+ambito+" ya existe");

            if (bloqFunc != null)
                ((Nodo)bloqFunc).ValidaSemantica(tablaSimbolos);
            return true;
        }
        public string GetCadenaParametros(Parametros parametros)
        {
            return "";
        }
    }
}

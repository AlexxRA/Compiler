using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class SentenciaAsignacion : Nodo
    {
        public object Id { get; set; }
        public object Igual { get; set; }
        public object expresion { get; set; }

        public SentenciaAsignacion(List<Nodo> elements, int ruleNumber)
        {
            Id = elements[7];
            Igual = elements[5];
            expresion = elements[3];
            TokenId = ruleNumber;
        }

        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            //validar tipos de parametros
            if (((Nodo)expresion).Name.Equals("null"))
            {

            }
            else
            {
                var IdTipoDato = BuscarTipo(tablaSimbolos, ((Nodo)Id).Name);
                string ExpresionTipoDato="";
                if (((dynamic)expresion) is ExpresionConstante)
                {
                    ExpresionTipoDato = BuscarTipoConstante(tablaSimbolos, ((dynamic)expresion).constante.Name);
                }
                else
                {

                }
                

                if (IdTipoDato.Equals("char") && ExpresionTipoDato.Equals("char"))
                {

                }
                else if (IdTipoDato.Equals("int") && ExpresionTipoDato.Equals("int"))
                {

                }
                else if (IdTipoDato.Equals("float") && ExpresionTipoDato.Equals("float"))
                {

                }
                else
                {
                    Console.WriteLine("El tipo de dato de " + ((Nodo)Id).Name + " es diferente al de la expresion");
                }
            }

            if (expresion != null)
                ((dynamic)expresion).ValidaSemantica(tablaSimbolos);

            return true;
        }

    }
}

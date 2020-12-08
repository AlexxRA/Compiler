using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Entities.Tree
{
    public class LlamadaFunc : Nodo
    {
        public object Id { get; set; }
        public object argumentos { get; set; }
        public LlamadaFunc(List<Nodo> elements, int ruleNumber)
        {
            Id = elements[7];
            argumentos = elements[3];
            TokenId = ruleNumber;
        }
        public override bool ValidaSemantica(List<TablaSimbolos> tablaSimbolos)
        {
            var ambito = ((Nodo)Id).Name;
            var tipoDato = BuscarTipo(tablaSimbolos, ((Nodo)Id).Name);
            var aux = ((dynamic)argumentos).Name.Equals("null") ? null : argumentos;

            string cadenaArgumentos="";

            while ((dynamic)aux != null)
            {
                if (((dynamic)aux).expresion is ExpresionConstante)
                {
                    cadenaArgumentos += BuscarTipoConstante(tablaSimbolos, ((dynamic)aux).expresion.constante.Name)[0];
                }
                else
                {
                    cadenaArgumentos += BuscarTipo(tablaSimbolos, ((dynamic)aux).expresion.Id.Name)[0];
                }

                aux = ((dynamic)aux).listaArgumentos.Name.Equals("null") ? null : ((dynamic)aux).listaArgumentos;
            }



            if (argumentos != null)
                ((Nodo)argumentos).ValidaSemantica(tablaSimbolos);

            
            //llamar existeFuncion
            if (ExisteFuncion(tablaSimbolos, ((Nodo)Id).Name, cadenaArgumentos)){
                //Console.WriteLine("Si existe func");
            }
                        
            return true;
        }

        public bool ExisteFuncion(List<TablaSimbolos> tablaSimbolos, string id, string cadenaParametros)
        {
            bool existe = false;
            foreach(var simbolo in tablaSimbolos)
            {
                if (simbolo.Id.Equals(id))
                {
                    existe = true;
                    if (simbolo.CadenaParametros.Equals(cadenaParametros))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Los parametros de la funcion " + id + " son incorrectos");
                    }
                }
            }
            if(!existe)
                Console.WriteLine("La funcion " + id + " no existe");
            return false;
        }
    }
}

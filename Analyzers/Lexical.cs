using LexicalAnalyzer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer.Analyzers
{
    /*
     int main(){
        float a,b;
        a=5;
        if(a==5) a=1;
     }
         */
    class Lexical
    {
        string token;
        int status;
        string type;

        public static List<Token> tokens = new List<Token>();
        Token tkn;
        public List<Token> getTokens(string src)
        {
            int statusTemp=0;
            int i;
            i = 0;
            while (i < src.Length)
            {
                tkn = new Token();
                token = "";
                status = 0;

                while (i < src.Length && status != 20)
                {

                    switch (status)
                    {
                        case 0:
                            if (src[i].Equals(' ') || src[i].Equals('\n') || src[i].Equals('\t') || src[i].Equals('\r'))
                            {
                                i++;
                            }
                            else if (Char.IsLetter(src[i]) || src[i].Equals('_'))
                            {
                                status = 1;
                                token += src[i];
                                i++;

                            }
                            else if (Char.IsDigit(src[i]))
                            {
                                status = 2;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('&'))
                            {
                                status = 4;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals(';') || src[i].Equals(',') || src[i].Equals('+') || src[i].Equals('-') || src[i].Equals('(')
                                || src[i].Equals(')') || src[i].Equals('{') || src[i].Equals('}') || src[i].Equals('*') || src[i].Equals('/') || src[i].Equals(',') || src[i].Equals('$'))
                            {
                                type = getType(src[i].ToString());
                                statusTemp = getStatus(src[i].ToString());
                                    
                                status = 20;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('='))
                            {
                                status = 6;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('>'))
                            {
                                status = 7;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('<'))
                            {
                                status = 8;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('!'))
                            {
                                status = 9;
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('.'))
                            {
                                token += src[i];
                                i++;
                                status = 2;
                            }
                            break;

                        case 1:
                            if (Char.IsLetter(src[i]) || src[i].Equals('_') || Char.IsDigit(src[i]))
                            {
                                token += src[i];
                                i++;
                            }
                            else
                            {
                                type = getType(token);
                                statusTemp = getStatus(token);
                                status = 20;
                                
                            }

                            break;

                        case 2:
                            if (Char.IsDigit(src[i]))
                            {
                                token += src[i];
                                i++;
                            }
                            else if (src[i].Equals('.'))
                            {
                                token += src[i];
                                i++;
                                status = 3;
                            }
                            else
                            {
                                //token += src[i];
                                statusTemp = 13;
                                status = 20;
                                type = "CONSTANTE";
                            }
                            break;

                        case 3:
                            if (Char.IsDigit(src[i]))
                            {
                                token += src[i];
                                i++;
                            }
                            else
                            {
                                statusTemp = 13;
                                status = 20;
                                type = "CONSTANTE";
                            }
                            break;

                        case 4:
                            if (src[i].Equals('&'))
                            {
                                statusTemp = 15;
                                status = 20;
                                token += src[i];
                                type = "AND";
                                i++;
                            }
                            else
                            {
                                token += src[i];
                                statusTemp = -1;
                                status = 20;
                                type = "ERROR";
                            }

                            break;
                        case 7:
                            if (src[i].Equals('='))
                            {
                                statusTemp = 17;
                                status = 20;
                                token += src[i];
                                i++;
                                type = "Mayor o igual"; break;
                                
                            }
                            else
                            {
                                statusTemp = 17;
                                status = 20;
                                type = "Mayor";
                            }
                            break;
                        case 8:
                            if (src[i].Equals('='))
                            {
                                statusTemp = 17;
                                status = 20;
                                token += src[i];
                                i++;
                                type = "Menor o igual"; break;

                            }
                            else
                            {
                                statusTemp = 17;
                                status = 20;
                                type = "Menor";
                            }
                            break;
                        case 6:
                            if (src[i].Equals('='))
                            {
                                statusTemp = 17;
                                status = 20;
                                token += src[i];
                                i++;
                                type = "Doble igual"; break;
                            }
                            else
                            {
                                statusTemp = 8;
                                status = 20;
                                type = "Igual";
                            }
                            break;
                        case 9:
                            if (src[i].Equals('='))
                            {
                                statusTemp = 17;
                                status = 20;
                                token += src[i];
                                i++;
                                type = "Diferente que"; break;
                            }
                            else
                            {
                                token += src[i];
                                statusTemp = -1;
                                status = 20;
                                type = "ERROR";
                            }
                            break;

                        case 20:
                            break;
                    }
                }
                tkn.TokenId = statusTemp;
                tkn.Type = type;
                tkn.Name = token;
                tokens.Add(tkn);
                tkn = null;
                statusTemp = 0;
                type = "";
            }

            return tokens;
        }

        public string getType(string  word)
        {
            string type = "";

            switch (word)
            {
                case ";":   type = "Punto y coma";  break;
                case ",": type = "Coma"; break;
                case "(": type = "Parentesis izquierdo"; break;
                case ")": type = "Parentesis derecho"; break;
                case "{": type = "Llave izquierda"; break;
                case "}": type = "Llave derecha"; break;
                case "$": type = "Signo moneda"; break;
                case "+": type = "Mas"; break;
                case "-": type = "Menos"; break;
                case "/": type = "Division"; break;
                case "*": type = "Multiplicacion"; break;

                case "if": 
                case "while": 
                case "return": 
                case "else": 
                case "const": type = "id"; break;
                case "int":
                case "float":
                case "char":
                case "void": type = "tipo"; break;
                default: type="id"; break;
            }

            return type;
        }

        public int getStatus(string word)
        {
            int status = 0;

            switch (word)
            {
                case "if": status = 9; break;
                case "while": status = 10;  break;
                case "return": status = 11; break;
                case "else": status = 12; break;
                case "const": status = 13; break;
                case "int":
                case "float":
                case "char":
                case "void": status = 0;break;

                case ";": status = 2; break;
                case ",": status = 3; break;
                case "(": status = 4; break;
                case ")": status = 5; break;
                case "{": status = 6; break;
                case "}": status = 7; break;
                case "$": status = 18; break;
                case "+":
                case "-": status = 14; break;
                case "/":
                case "*": status = 16; break;

                default: status = 1;break;
            }

            return status;
        }
       
    }
}

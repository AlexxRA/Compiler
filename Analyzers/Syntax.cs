using LexicalAnalyzer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LexicalAnalyzer.Analyzers
{
    class Syntax
    {
        public List<Token> tokens { get; set; }

        public List<Rule> rules { get; set; } = new List<Rule>(GetRules());

        public List<string> stack { get; set; } = new List<string>();

        public int[,] table { get; set; } = GetTable();

        public Syntax(List<Token> _tokens)
        {
            tokens = _tokens;
        }
        //generate stack to save items
        //if ends at -1, is correct
        //

        public static int[,] GetTable()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "GR2slrTablebien.txt"));
            int[,] table = new int[lines.Count(), 40];

            for (int i = 0; i < 84; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    string[] splittedLine = lines[i].Split('\t');
                    table[i, j] = Int32.Parse(splittedLine[j]);
                }
            }
            return table;
        }

        public static List<Rule> GetRules()
        {
            List<Rule> rules = new List<Rule>();
            string[] lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "GR2slrRulesId.txt"));

            int i = 0;
            foreach(var line in lines)
            {
                var splittedLine = line.Split('\t');
                rules.Add(new Rule
                {
                    RuleNumber = i,
                    RuleIdentifier = Int32.Parse(splittedLine[0]),
                    NumOfItems = Int32.Parse(splittedLine[1])
                });
                i++;
            }

            return rules;
        }

        public string Analize()
        {
            string result = "";
            this.stack.Add("0");
            int item=1;
            int contador = 0;
            while (contador < tokens.Count)
            {
                var last = Int32.Parse(stack.Last());
                item = table[Int32.Parse(stack.Last()), tokens[contador].TokenId + 1];
                if (item > 0)
                {
                    stack.Add(tokens[contador].Type);
                    stack.Add((table[last, tokens[contador].TokenId + 1]).ToString());
                    contador++;
                }
                else
                {
                    if (item == -1)
                    {
                        result = "RESULTADO CORRECTO";
                        break;
                    }
                    if (item == 0)
                    {
                        result = "RESULTADO INCORRECTO CON " + tokens[contador].Name;
                        break;
                    }

                    var ruleNumber = Math.Abs(item) - 1;
                    var rule = rules.Where(r => r.RuleNumber == ruleNumber).FirstOrDefault();
                    var itemsToDrop = rule.NumOfItems * 2;
                    for (int i = 0; i < itemsToDrop; i++)
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                    stack.Add(rule.RuleIdentifier.ToString());

                    item = table[Int32.Parse(stack[stack.Count - 2]), Int32.Parse(stack.Last())+1];
                    stack.Add(item.ToString());
                }
            }

            return result;
        }

        public string AnalizeRefactor()
        {
            string result = "";
            this.stack.Add("0");
            int item = 0;
            int contador = 0;
            while (contador < tokens.Count)
            {
                item = GetItemFromTableAt(Int32.Parse(stack.Last()), tokens[contador].TokenId + 1);
                if (item < 0)//Es regla, hay que sacar de la lista
                {
                    if (item == -1)
                    {
                        result = "RESULTADO CORRECTO";
                        break;
                    }
                    var ruleNumber = Math.Abs(item) - 1;
                    var rule = rules.Where(r => r.RuleNumber == ruleNumber).FirstOrDefault();
                    var itemsToDrop = rule.NumOfItems * 2;

                    var extractedElements = stack.GetRange(stack.Count() - itemsToDrop, stack.Count());

                    //get node element

                    stack = stack.GetRange(0, stack.Count() - itemsToDrop);

                    stack.Add(rule.RuleIdentifier.ToString());

                    item = GetItemFromTableAt(Int32.Parse(stack[stack.Count - 2]), Int32.Parse(stack.Last()) + 1);
                    stack.Add(item.ToString());
                }
                else if (item > 0)//Es desplazamiento
                {
                    stack.Add(tokens[contador].Type);//Agrega el tipo de token
                    stack.Add((GetItemFromTableAt(GetLastItem(stack), tokens[contador].TokenId + 1)).ToString());//Agrega
                    contador++;
                }
                else
                {
                    result = "RESULTADO INCORRECTO CON " + tokens[contador].Name;
                    break;
                }
            }

            return result;
        }

        //Change from int to Node
        public int GetItemFromTableAt(int number, int elementNumber)
        {
            return this.table[number, elementNumber];
        }

        public int GetLastItem(List<string> _stack)
        {
            return Int32.Parse(_stack.Last());
        }
    }
}

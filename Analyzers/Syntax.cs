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

    }
}
